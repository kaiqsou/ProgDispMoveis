namespace MauiAppHotel2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Definindo largura e altura da janela de exibição
            var w = new Window(new AppShell());
            w.Height = 700;
            w.Width = 350;

            return w;
        }
    }
}

