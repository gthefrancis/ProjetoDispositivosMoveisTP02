using TarefasApp.Models;
using System.Collections.ObjectModel;

namespace TarefasApp
{
    public partial class TarefaDetailPage : ContentPage
    {
        private Tarefa _tarefa;

        public TarefaDetailPage(Tarefa tarefa)
        {
            InitializeComponent();
            _tarefa = tarefa;
            PreencherDados();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PreencherDados();
        }

        private void PreencherDados()
        {
            LblTitulo.Text = _tarefa.Titulo;
            LblDescricao.Text = _tarefa.Descricao;
            LblData.Text = _tarefa.DataCriacao.HasValue ? _tarefa.DataCriacao.Value.ToString("dd/MM/yyyy") : "Sem data";
            LblPrioridade.Text = _tarefa.Prioridade ?? "Média";
        }

        private async void OnEditarClicked(object sender, EventArgs e)
        {
            var modal = new NavigationPage(new TarefaEditPage(_tarefa, false))
            {
                BarBackgroundColor = Colors.Black,
                BarTextColor = Colors.White
            };
            await Navigation.PushModalAsync(modal);
        }

        private async void OnExcluirClicked(object sender, EventArgs e)
        {
            bool confirma = await DisplayAlertAsync("Excluir", "Tem certeza que deseja excluir esta tarefa?", "Sim", "Não");

            if (confirma)
            {
                MainPage.Tarefas.Remove(_tarefa);
                await Navigation.PopAsync();
            }
        }
    }
}
