namespace MauiAppHotel2.Views;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		Task.Run(async () =>
        {
            // Coleta o usuário logado
            var usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

            // Define a label
            if (lbl_boasvindas != null)
            {
                lbl_boasvindas.Text = $"Bem-vindo, {usuario_logado}!";
            }
        });
	}

    // Evento de Logout
    private async void Button_Clicked(object sender, EventArgs e)
    {
        // Boolean de confirmação
        bool confirmacao = await DisplayAlert("Atenção!", "Deseja realmente sair?", "Sim", "Não");

        // Se a resposta for "sim", o usuário é deslogado e levado para o Login
        if (confirmacao)
        {
            await SecureStorage.Default.SetAsync("usuario_logado", string.Empty);

            App.Current.MainPage = new Login();
        }
    }
}

