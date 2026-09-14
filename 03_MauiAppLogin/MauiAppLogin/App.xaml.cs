using Microsoft.Extensions.DependencyInjection;

namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var x = new Window(new AppShell());
            x.Width = 400;
            x.Height = 750;

            return x;
        }
    }
}