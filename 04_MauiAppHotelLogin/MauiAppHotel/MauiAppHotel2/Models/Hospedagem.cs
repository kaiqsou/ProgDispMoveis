using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel2.Models
{
    public class Hospedagem
    {
        // Campo (privado por padrão) onde o dado será guardado
        Quarto _quarto_selecionado;

        // Propriedade que regula o acesso ao campo
        public Quarto QuartoSelecionado { 
            get => _quarto_selecionado;
            set
            {
                // Se o valor for nulo, dispara a mensagem
                if (value == null) throw new Exception("Faz favor, seleciona o quarto.");

                // Caso não seja nulo, é atribuído o valor real ao campo
                _quarto_selecionado = value;        
            }
        }

        int _qtd_adultos;
        public int QtdAdultos 
        { 
            get => _qtd_adultos;
            set
            {
                if(value <= 0) throw new Exception("Faz favor, quantos adultos terão?");
                _qtd_adultos = value;
            }
        }

        public int QtdCriancas { get; set; }

        DateTime? _data_checkin;

        public DateTime? DataCheckIn 
        { 
            get => _data_checkin;
            set
            {
                if (value == null) throw new Exception("Faz favor, selecione a data de entrada do hotel.");
                _data_checkin = value;
            }
        }

        DateTime? _date_checkout;

        public DateTime? DataCheckOut 
        {
            get => _date_checkout;
            set
            {
                if (value == null) throw new Exception("Faz favor, selecione a data de saída do hotel.");
                _date_checkout = value;
            }
        }

        // Define a estadia em dias, usando o check-in e check-out
        public int Estadia
        {
            get => DataCheckOut.Value.Subtract(DataCheckIn.Value).Days;
        }

        // Coleta todas as informações para definir o valor total da estadia
        public double ValorTotal
        {
            get
            {
                double valor_adultos = QtdAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_criancas = QtdCriancas * QuartoSelecionado.ValorDiariaCrianca;
                double total = (valor_adultos + valor_criancas) * Estadia;

                return total;
            }
        }
    }
}