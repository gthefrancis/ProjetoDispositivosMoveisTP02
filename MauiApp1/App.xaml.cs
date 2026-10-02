using Microsoft.Extensions.DependencyInjection;

// Desenvolvido por Guilherme Francisco

namespace TarefasApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}