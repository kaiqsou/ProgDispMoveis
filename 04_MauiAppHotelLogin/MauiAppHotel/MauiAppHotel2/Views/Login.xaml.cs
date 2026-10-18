using MauiAppHotel2.Models;
using System.Text.Json;

namespace MauiAppHotel2.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

	// Evento de quando o botão de Login é clicado
	private async void Button_Clicked(object sender, EventArgs e)
	{
		try 
		{
			// Coleta as informações declaradas no Login e armazena-as
			var email = txt_email.Text?.Trim();
			var senha = txt_senha.Text;

			// Verifica se há algum campo em branco
			if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
			{
				await DisplayAlert("Erro", "Preencha email e senha.", "OK");

				return;
			}

			// Cria uma lista dos usuários
			var lista = await SecureStorage.GetAsync("usuarios");
			List<Usuarios> usuarios = new();

			// Verifica se a lista está vazia
			if (!string.IsNullOrEmpty(lista))
			{
				try
				{
					// Desserializa a lista de usuários ou cria uma nova lista de usuários
					usuarios = JsonSerializer.Deserialize<List<Usuarios>>(lista) ?? new List<Usuarios>();
				}
				catch
				{
					usuarios = new List<Usuarios>();
				}
			}

			// Busca o usuário na lista, com e-mail e senha correspondentes
			var usuario = usuarios.FirstOrDefault(u =>  string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase) && u.Senha == senha);

			// Se o usuário for encontrado, entra aqui
			if (usuario != null)
            {
				// Envia um alerta de sucesso
                await DisplayAlert("Sucesso", "Login realizado com sucesso!", "OK");

				// Mantém a sessão
                await SecureStorage.SetAsync("usuario_logado", usuario.Email);

				// Declara a página principal
                App.Current.MainPage = new AppShell();

				// Leva o usuário para /Contratacao
                await Shell.Current.GoToAsync("//Contratacao");
            }
            else
			{
                await DisplayAlert("Erro", "Email ou senha incorretos.", "OK");
			}
		}
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

	// Evento que leva para a página de cadastro
	private async void BtnIrParaCadastro_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Cadastro());
	}
}

