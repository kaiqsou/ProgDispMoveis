using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppLogin.Models
{
    public class Usuario
    {
        string? nome, email, senha;
        public string? Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Faz favor, informe o nome");

                nome = value;
            }
        }

        public string? Email
        {
            get => email;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Faz favor, informe o e-mail");

                email = value;
            }
        }

        public string? Senha
        {
            get => senha;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Faz favor, informe a senha");

                senha = value;
            }
        }
    }
}
