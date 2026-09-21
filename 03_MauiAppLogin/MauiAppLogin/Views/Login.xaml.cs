using MauiAppLogin.Models;

namespace MauiAppLogin.Views;

public partial class Login : ContentPage
{
	List<Usuario> arr_usuarios = new()
	{
		new Usuario { Nome = "SpeedBlue", Email = "speed@blue.com", Senha = "123" },
		new Usuario { Nome = "Master", Email = "master@tora.com", Senha = "456" }
	};

	public Login()
	{
		InitializeComponent();

        string? usuario_logado = null;

        Task.Run(async () =>
        {
            usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

            if(usuario_logado)
        });
    }



    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			Usuario dados_digitados = new()
			{
				Email = txt_email.Text,
				Senha = txt_senha.Text
			};

			bool encontrou = arr_usuarios.Any(i =>
			(i.Email == dados_digitados.Email && i.Senha == dados_digitados.Senha));

			if (encontrou)
			{
                await DisplayAlertAsync("Oba!", "Entrouuu", "OK");

				// Fazendo a persistencia do "token" do usuário no SecureStorage
				await SecureStorage.SetAsync("usuario_logado", dados_digitados.Email);

				// Trocando a tela inicial, raiz, do app
				App.Current.MainPage = new Protegido();
            }
			else           
				await DisplayAlertAsync("Ops!", "Usuário ou Senha incorretos.", "OK");
		}
		catch (Exception ex)
		{
			DisplayAlertAsync("Ops", ex.Message, "OK");
		}
    }
}