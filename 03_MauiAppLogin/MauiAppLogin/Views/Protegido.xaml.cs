namespace MauiAppLogin.Views;

public partial class Protegido : ContentPage
{
	public Protegido()
	{
		InitializeComponent();

		string? usuario_logado = null;

		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
			lbl_boasvindas.Text = $"Bem-vindo(a) {usuario_logado}";
		});
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool confirmacao = await DisplayAlertAsync("Tem certeza?", "Sair da conta?", "Sim", "Não");

		if(confirmacao)
		{
			SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new Login();
		}
    }
}