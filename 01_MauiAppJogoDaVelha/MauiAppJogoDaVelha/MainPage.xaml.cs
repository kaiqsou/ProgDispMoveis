namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        String vez = "";
        int jogadas = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button botao_pressionado = (Button) sender;
            botao_pressionado.IsEnabled = true;
            jogadas++;

            if (vez == "X")
            {
                botao_pressionado.Text = "X";
                botao_pressionado.IsEnabled = false;
                vez = "O";
            }
            else
            {
                botao_pressionado.Text = "O";
                botao_pressionado.IsEnabled = false;
                vez = "X";
            }

            // HORIZONTAL
            if (btn10.Text == "X" && btn11.Text == "X" & btn12.Text == "X")
            {
                DisplayAlertAsync("Parabéns!", "X ganhou", "OK");
                Zerar();
            }
            else if (btn20.Text == "X" && btn21.Text == "X" & btn22.Text == "X")
            {
                DisplayAlertAsync("Parabéns!", "X ganhou", "OK");
                Zerar();
            }
            else if (btn30.Text == "X" && btn31.Text == "X" & btn32.Text == "X")
            {
                DisplayAlertAsync("Parabéns!", "X ganhou", "OK");
                Zerar();
            }

            if (btn10.Text == "O" && btn11.Text == "O" & btn12.Text == "O")
            {
                DisplayAlertAsync("Parabéns!", "O ganhou", "OK");
                Zerar();
            }
            else if (btn20.Text == "O" && btn21.Text == "O" & btn22.Text == "O")
            {
                DisplayAlertAsync("Parabéns!", "O ganhou", "OK");
                Zerar();
            }
            else if (btn30.Text == "O" && btn31.Text == "O" & btn32.Text == "O")
            {
                DisplayAlertAsync("Parabéns!", "O ganhou", "OK");
                Zerar();
            }

            // VERTICAL
            else if (btn10.Text == "X" && btn20.Text == "X" & btn30.Text == "X")
            {
                DisplayAlertAsync("Parabéns!", "X ganhou", "OK");
                Zerar();
            }
            else if (btn11.Text == "X" && btn21.Text == "X" & btn31.Text == "X")
            {
                DisplayAlertAsync("Parabéns!", "X ganhou", "OK");
                Zerar();
            }
            else if (btn12.Text == "X" && btn22.Text == "X" & btn32.Text == "X")
            {
                DisplayAlertAsync("Parabéns!", "X ganhou", "OK");
                Zerar();
            }

            else if (btn10.Text == "O" && btn20.Text == "O" & btn30.Text == "O")
            {
                DisplayAlertAsync("Parabéns!", "O ganhou", "OK");
                Zerar();
            }
            else if (btn11.Text == "O" && btn21.Text == "O" & btn31.Text == "O")
            {
                DisplayAlertAsync("Parabéns!", "O ganhou", "OK");
                Zerar();
            }
            else if (btn12.Text == "O" && btn22.Text == "O" & btn32.Text == "O")
            {
                DisplayAlertAsync("Parabéns!", "O ganhou", "OK");
                Zerar();
            }

            // DIAGONAL
            else if (btn10.Text == "X" && btn21.Text == "X" & btn32.Text == "X")
            {
                DisplayAlertAsync("Parabéns!", "X ganhou", "OK");
                Zerar();
            }
            else if (btn12.Text == "X" && btn21.Text == "X" & btn30.Text == "X")
            {
                DisplayAlertAsync("Parabéns!", "X ganhou", "OK");
                Zerar();
            }

            else if (btn10.Text == "O" && btn21.Text == "O" & btn32.Text == "O")
            {
                DisplayAlertAsync("Parabéns!", "O ganhou", "OK");
                Zerar();
            }
            else if (btn12.Text == "O" && btn21.Text == "O" & btn30.Text == "O")
            {
                DisplayAlertAsync("Parabéns!", "O ganhou", "OK");
                Zerar();
            }

            // VELHA
            if (jogadas == 9)
            {
                DisplayAlertAsync("Empate!", "Deu velha", "OK");
                Zerar();
            }

            void Zerar()
            {
                btn10.Text = "";
                btn11.Text = "";
                btn12.Text = "";
                btn20.Text = "";
                btn21.Text = "";
                btn22.Text = "";
                btn30.Text = "";
                btn31.Text = "";
                btn32.Text = "";

                btn10.IsEnabled = true;
                btn11.IsEnabled = true;
                btn12.IsEnabled = true;
                btn20.IsEnabled = true;
                btn21.IsEnabled = true;
                btn22.IsEnabled = true;
                btn30.IsEnabled = true;
                btn31.IsEnabled = true;
                btn32.IsEnabled = true;

                jogadas = 0;
            }
        }
    }
}
