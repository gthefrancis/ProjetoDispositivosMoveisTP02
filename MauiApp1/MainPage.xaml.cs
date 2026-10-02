using System.Collections.ObjectModel;
using TarefasApp.Models;

namespace TarefasApp
{
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<Tarefa> Tarefas { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();
            TarefasCollection.ItemsSource = Tarefas;
        }

        private async void OnAdicionarClicked(object sender, EventArgs e)
        {
            var modal = new NavigationPage(new TarefaEditPage(new Tarefa(), true))
            {
                BarBackgroundColor = Colors.Black,
                BarTextColor = Colors.White
            };
            await Navigation.PushModalAsync(modal);
        }

        private async void OnTarefaTapped(object sender, TappedEventArgs e)
        {

            if (sender is Grid gridClicado && gridClicado.BindingContext is Tarefa tarefaSelecionada)
            {
                await gridClicado.FadeToAsync(0.5, 100);
                await gridClicado.FadeToAsync(1, 100);
                await Navigation.PushAsync(new TarefaDetailPage(tarefaSelecionada));
            }
        }
    }
}
