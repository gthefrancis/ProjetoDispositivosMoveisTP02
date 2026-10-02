using TarefasApp.Models;
using System.Collections.ObjectModel;

namespace TarefasApp
{
    public partial class TarefaEditPage : ContentPage
    {
        private Tarefa _tarefa;
        private bool _isNovaTarefa;

        public TarefaEditPage(Tarefa tarefa, bool isNovaTarefa)
        {
            InitializeComponent();
            _tarefa = tarefa;
            _isNovaTarefa = isNovaTarefa;

            Title = _isNovaTarefa ? "Nova Tarefa" : "Editar Tarefa";

            // 1. Carrega as opções do Picker diretamente via C#
            PickerPrioridade.ItemsSource = new List<string> { "Baixa", "Média", "Alta" };

            // 2. Preenche os campos
            EntryTitulo.Text = _tarefa.Titulo;
            EditorDescricao.Text = _tarefa.Descricao;
            PickerPrioridade.SelectedItem = string.IsNullOrEmpty(_tarefa.Prioridade) ? "Média" : _tarefa.Prioridade;

            // 3. Lida com a data
            if (_tarefa.DataCriacao.HasValue)
            {
                SwitchUsarData.IsToggled = true;
                DatePickerCriacao.Date = _tarefa.DataCriacao.Value;
                DatePickerCriacao.IsEnabled = true;
            }
            else
            {
                SwitchUsarData.IsToggled = false;
                DatePickerCriacao.Date = DateTime.Now;
                DatePickerCriacao.IsEnabled = false;
            }
        }

        private void OnSwitchDataToggled(object sender, ToggledEventArgs e)
        {
            DatePickerCriacao.IsEnabled = e.Value;
        }

        private async void OnSalvarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EntryTitulo.Text))
            {
                await DisplayAlertAsync("Erro", "O título é obrigatório.", "OK");
                return;
            }

            _tarefa.Titulo = EntryTitulo.Text;
            _tarefa.Descricao = EditorDescricao.Text;
            _tarefa.Prioridade = PickerPrioridade.SelectedItem?.ToString() ?? "Média";
            _tarefa.DataCriacao = SwitchUsarData.IsToggled ? DatePickerCriacao.Date : null;

            if (_isNovaTarefa)
            {
                MainPage.Tarefas.Add(_tarefa);
            }

            await Navigation.PopModalAsync();
        }

        private async void OnCancelarClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
