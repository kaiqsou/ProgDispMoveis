using MauiAppHotel2.Models;
using System.Collections.ObjectModel;

namespace MauiAppHotel2.Views;

public partial class Contratacao : ContentPage
{
    // Definindo lista de quartos e as informações de cada quarto, como o valor da diária para crianças e adultos
    ObservableCollection<Quarto> lista_quartos = new()
	{
		new Quarto()
		{
			Descricao = "Suite Master",
			ValorDiariaAdulto = 200,
			ValorDiariaCrianca = 100
		},

        new Quarto()
        {
            Descricao = "Suite Premium",
            ValorDiariaAdulto = 170,
            ValorDiariaCrianca = 50
        },

        new Quarto()
        {
            Descricao = "Suite Plus",
            ValorDiariaAdulto = 100,
            ValorDiariaCrianca = 50
        },

        new Quarto()
        {
            Descricao = "Suite Comum",
            ValorDiariaAdulto = 90,
            ValorDiariaCrianca = 40
        }
    };

    public Contratacao()
    {
        InitializeComponent();

        // Define os itens que aparecem no seletor de quartos
        pck_quarto.ItemsSource = lista_quartos;

        // Define a data mínima do check-in
        dtpck_checkin.MinimumDate = DateTime.Now;
    }

    // Evento que define a data mínima do check-out, com base na data do check-in
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
    }

    // Função de logout
    private async void BtnSair_Clicked(object sender, EventArgs e)
    {
        try
        {
            bool confirmacao = await DisplayAlert("Atenção!", "Deseja realmente sair?", "Sim", "Não");

            if (confirmacao)
            {
                SecureStorage.Remove("usuario_logado");
                App.Current.MainPage = new AppShell();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    // Evento de quando o botão "Avançar" é clicado
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Verifica se o tipo do quarto foi selecionado
            if (pck_quarto.SelectedItem is not Quarto quarto)
            {
                await DisplayAlert("Erro", "Selecione uma suíte.", "OK");
                return;
            }

            // Verifica se a data do check-out é menor ou igual a data do check-in
            if (dtpck_checkout.Date <= dtpck_checkin.Date)
            {
                await DisplayAlert("Erro", "O check-out deve ser após o check-in.", "OK");
                return;
            }

            // Cria uma nova hospedagem com as informações coletadas
            Hospedagem h = new()
            {
                QtdAdultos = Convert.ToInt16(stp_adultos.Value),
                QtdCriancas = Convert.ToInt16(stp_criancas.Value),
                QuartoSelecionado = quarto,
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date
            };

            // Cria um texto de resumo das informações
            string resumo =
                $"Suíte: {quarto.Descricao}\n" +
                $"Adultos: {h.QtdAdultos}\n" +
                $"Crianças: {h.QtdCriancas}\n" +
                $"Check-in: {h.DataCheckIn:dd/MM/yyyy}\n" +
                $"Check-out: {h.DataCheckOut:dd/MM/yyyy}\n" +
                $"Estadia: {h.Estadia} diária(s)";

            // Alerta de confirmação de reserva, exibindo as informações de resumo
            bool confirmada = await DisplayAlert("Confirmar reserva", resumo, "Sim", "Não");

            if (!confirmada) return;

            // Abre uma nova página HospedagemContratada, enviando os dados do objeto (h) para ela
            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}