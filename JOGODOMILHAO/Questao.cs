namespace JOGODOMILHAO
{
    public class Questao : IEquatable<Questao>
    {
        public bool Equals (Questao q)
        {
            return this.Nivelresposta == q.Nivelresposta &&
            this.Pergunta == q.Pergunta;
        }
        public string Pergunta;
        public string Resposta01;
        public string Resposta02;
        public string Resposta03;
        public string Resposta04;
        public string Resposta05;
        public int RespostaCorreta;
        public int Nivelresposta;
        private Label LabelPergunta;
        private Button ButtonResposta1;
        private Button ButtonResposta2;
        private Button ButtonResposta3;
        private Button ButtonResposta4;
        private Button ButtonResposta5;



        public void ConfiguraEstruturaDesenho(Label LabelPergunta, Button Button1, Button Button2, Button Button3, Button Button4, Button Button5)
        {
            LabelPergunta = LabelPergunta;
            ButtonResposta1 = Button1;
            ButtonResposta2 = Button2;
            ButtonResposta3 = Button3;
            ButtonResposta4 = Button4;
            ButtonResposta5 = Button5;
        }
        public void Desenhar()
        {
            LabelPergunta.Text = Pergunta;
            ButtonResposta1.Text = Resposta01;
            ButtonResposta2.Text = Resposta02;
            ButtonResposta3.Text = Resposta03;
            ButtonResposta4.Text = Resposta04;
            ButtonResposta5.Text = Resposta05;

            ButtonResposta1.BackgroundColor = Color.FromRgba("#0a4afa");
            ButtonResposta2.BackgroundColor = Color.FromRgba("#0a4afa");
            ButtonResposta3.BackgroundColor = Color.FromRgba("#0a4afa");
            ButtonResposta4.BackgroundColor = Color.FromRgba("#0a4afa");
            ButtonResposta5.BackgroundColor = Color.FromRgba("#0a4afa");

            ButtonResposta1.IsVisible=true;
            ButtonResposta2.IsVisible=true;
            ButtonResposta3.IsVisible=true;
            ButtonResposta4.IsVisible=true;
            ButtonResposta5.IsVisible=true;
            

        }

        private Button QualBTN(int RespostaSelecionada)
        {
            if (RespostaSelecionada == 1)
                return ButtonResposta1;
            else if (RespostaSelecionada == 2)
                return ButtonResposta2;
            else if (RespostaSelecionada == 3)
                return ButtonResposta3;
            else if (RespostaSelecionada == 4)
                return ButtonResposta4;
            else if (RespostaSelecionada == 5)
                return ButtonResposta5;
            else
                return null;

        }
        public bool VerificaResposta(int RespostaSelecionada)
        {
            if (RespostaCorreta == RespostaSelecionada)
            {
                var Button = QualBTN(RespostaSelecionada);
                Button.BackgroundColor = Colors.Green;
                return true;
            }
            else
            {
                var ButtonCorreto = QualBTN(RespostaCorreta);
                var ButtonIncorreto = QualBTN(RespostaSelecionada);
                ButtonCorreto.BackgroundColor = Colors.Yellow;
                ButtonIncorreto.BackgroundColor = Colors.Red;
                return false;
            }
        }

        public Questao()
        {

        }
        public Questao(Label LabelPergunta, Button Button1, Button Button2, Button Button3, Button Button4, Button Button5)
        {
            LabelPergunta = LabelPergunta;
            ButtonResposta1 = Button1;
            ButtonResposta2 = Button2;
            ButtonResposta3 = Button3;
            ButtonResposta4 = Button4;
            ButtonResposta5 = Button5;
        }




    }
}