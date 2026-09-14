using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel.Models;

internal class Hospedagem
{
    // Campo (privado por padrão) onde o dado será efetivamente guardado.
    Quarto _quarto_selecionado;

    // Propriedade que regula o acesso ao campo.
    public Quarto QuartoSelecionado 
    { 
        get => _quarto_selecionado; 
        set
        {
            if (value == null) throw new Exception("Faz favor, selecione o quarto.");

            _quarto_selecionado = value;
        } 
    }
    int _qtd_adultos;
    public int QntdAdultos 
    { 
        get => _qtd_adultos; 
        set
        {
            if (value <= 0) throw new Exception("Faz favor, quantos adultos serão?");

            _qtd_adultos = value;
        }
    }
    public int QntdCriancas { get; set; }
    DateTime? _data_checkin;
    public DateTime? DataCheckIn 
    { 
        get => _data_checkin; 
        set
        {
            if (value == null) throw new Exception("Faz favor, selecione a data de entrada no hotel.");

            _data_checkin = value;
        }
    }
    DateTime? _data_checkout;
    public DateTime? DataCheckout 
    { 
        get => _data_checkout; 
        set
        {
            if (value == null) throw new Exception("Faz favor, selecione a data de saída no hotel.");

            _data_checkout = value;
        }
    }
    public int Estadia
    {
        get => DataCheckout.Value.Subtract(DataCheckIn.Value).Days;
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
