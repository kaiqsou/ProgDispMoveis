using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel2.Models
{
    public class Usuarios
    {
        // Campos (privados por padrão) onde os dados serão guardados
        string? nome, email, senha;

        // Propriedades que regulam o acesso aos campos
        public string? Nome
        {
            get => nome;
            set
            {
                // Se o valor for nulo, dispara a mensagem
                if (string.IsNullOrEmpty(value)) throw new Exception("Please, coloca o nome, fi.");

                // Caso não seja nulo, é atribuído o valor real ao campo
                nome = value;
            }
        }


        public string? Email
        {
            get => email;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Please, coloca o email, fi.");
                email = value;
            }
        }


        public string? Senha
        {
            get => senha;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Please, coloca a senha, fi.");
                senha = value;
            }
        }
    }
}