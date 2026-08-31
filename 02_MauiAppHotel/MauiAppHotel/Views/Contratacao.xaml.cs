using System.Collections.ObjectModel;
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Contratacao : ContentPage
{
	ObservableCollection<Quarto> lista_quartos = new()
	{
		new Quarto()
		{
			Descricao = "Suíte Master",
			ValorDiariaAdulto = 200,
			ValorDiariaCrianca = 100
		},
        new Quarto()
        {
            Descricao = "Suíte Premium",
            ValorDiariaAdulto = 150,
            ValorDiariaCrianca = 75
        },
        new Quarto()
        {
            Descricao = "Suíte Plus",
            ValorDiariaAdulto = 100,
            ValorDiariaCrianca = 50
        },
        new Quarto()
        {
            Descricao = "Suíte Crise",
            ValorDiariaAdulto = 50,
            ValorDiariaCrianca = 25
        }
    };
	public Contratacao()
	{
		InitializeComponent();

        pck_quarto.ItemsSource = lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
	}

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Hospedagem h = new()
        {
            QntdAdultos = Convert.ToInt16(stp_adultos.Value),
            QntdCriancas = Convert.ToInt16(stp_criancas.Value),
            QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
            DataCheckIn = dtpck_checkin.Date.Value,
            DataCheckout = dtpck_checkout.Date.Value
        };

        Navigation.PushAsync(new HospedagemContratada()
        {
            BindingContext = h
        });
    }
}