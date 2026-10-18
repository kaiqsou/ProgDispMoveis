using MauiAppHotel2.Models;

namespace MauiAppHotel2.Views;

public partial class Cadastro : ContentPage
{
	public Cadastro()
	{
		InitializeComponent();
	}

	// Função de quando o botão "cadastrar" é clicado
	private async void BtnCadastrar_Clicked(object sender, EventArgs e)
	{
		try
		{
			// Coleta as informações declaradas e armazenadas nos campos txt_nome, txt_email e txt_senha
			var nome = txt_nome.Text?.Trim();
			var email = txt_email.Text?.Trim();
			var senha = txt_senha.Text;

			// Verifica se nome/email/senha estão preenchidos
			if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
			{
				await DisplayAlert("Erro", "Preencha nome, email e senha.", "OK");

				return;
			}

			// Cria um novo usuário
			var usuario = new Usuarios
			{
				Nome = nome,
				Email = email,
				Senha = senha
			};

			// Cria uma lista de usuários
			var lista = await SecureStorage.GetAsync("usuarios") ?? string.Empty;
			var usuarios = string.IsNullOrEmpty(lista) ? new List<Usuarios>() : System.Text.Json.JsonSerializer.Deserialize<List<Usuarios>>(lista) ?? new List<Usuarios>();

			// Verifica se o e-mail já está cadastrado
			if (usuarios.Any(u => string.Equals(u.Email, usuario.Email, StringComparison.OrdinalIgnoreCase)))
			{
				await DisplayAlert("Erro", "Email já cadastrado.", "OK");

				return;
			}

			// Adiciona o usuário na lista de usuários
			usuarios.Add(usuario);
			var json = System.Text.Json.JsonSerializer.Serialize(usuarios);
			await SecureStorage.SetAsync("usuarios", json);

			await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "OK");

			await Navigation.PopAsync();
		}
		catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "OK");
		}
	}

	// Evento que leva o usuário para a tela de Login
	private async void BtnIrParaLogin_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}

