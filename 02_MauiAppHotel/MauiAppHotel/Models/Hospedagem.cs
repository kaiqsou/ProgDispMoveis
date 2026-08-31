using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel.Models;

internal class Hospedagem
{
    public Quarto QuartoSelecionado { get; set; }
    public int QntdAdultos { get; set; }
    public int QntdCriancas { get; set; }
    public DateTime DataCheckIn {  get; set; }
    public DateTime DataCheckout { get; set; }
    public int Estadia
    {
        get => DataCheckout.Subtract(DataCheckIn).Days;
    }
    public double ValorTotal
    {
        get
        {
            double valor_adultos = QntdAdultos * QuartoSelecionado.ValorDiariaAdulto;
            double valor_criancas = QntdCriancas * QuartoSelecionado.ValorDiariaCrianca;
            double total = (valor_adultos + valor_criancas) * Estadia;

            return total;
        }
    }
}
