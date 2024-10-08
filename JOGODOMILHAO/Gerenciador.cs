namespace JOGODOMILHAO
{
    public class Gerenciador
    {
        List<Questao> ListaTodasQuestoes = new List<Questao>();
        List<Questao> ListaTodasQuestoesRespondidas = new List<Questao>();
        public int Pontuacao { get; private set; }
        Label LabelPontuacao;
        Label LabelNivel;
        Questao QuestaoAtual;

        void AdicionaPontuacao(int n)
        {
            if (n == 1)
                Pontuacao = 1000;
            else if (n == 2)
                Pontuacao = 2000;
            else if (n == 3)
                Pontuacao = 5000;
            else if (n == 4)
                Pontuacao = 10000;
            else if (n == 5)
                Pontuacao = 20000;
            else if (n == 6)
                Pontuacao = 50000;
            else if (n == 7)
                Pontuacao = 10000;
            else if (n == 8)
                Pontuacao = 20000;
            else if (n == 9)
                Pontuacao = 500000;
            else if (n == 10)
                Pontuacao = 1000000;
        }
        public Questao GetQuestaoAtual()
        {
            return QuestaoAtual;
        }
        public void ProximaQuestao()
        {
            var ListaQuestoes = ListaTodasQuestoes.Where(d => d.Nivelresposta == NivelAtual).ToList();
            var numRandomico = Random.Shared.Next(0, ListaQuestoes.Count - 1);

            QuestaoAtual = ListaQuestoes[numRandomico];

            while (ListaTodasQuestoesRespondidas.Contains(QuestaoAtual))
            {
                numRandomico = Random.Shared.Next(0, ListaQuestoes.Count - 1);
                QuestaoAtual = ListaQuestoes[numRandomico];
            }

            ListaTodasQuestoesRespondidas.Add(QuestaoAtual);

            QuestaoAtual.Desenhar();
        }

        public async void VerfiicaCorreto(int RespostaSelecionada)
        {
            if (QuestaoAtual.VerificaResposta(RespostaSelecionada))
            {
                await Task.Delay(1500);
                if (NivelAtual == 10)
                {


                    await App.Current.MainPage.DisplayAlert("Você ganhou!!", "Parabéns!", "Ok");
                    Application.Current.MainPage = new TelaInicial();
                }
                else 
                {
                    AdicionaPontuacao(NivelAtual);
                    NivelAtual++;
                    ProximaQuestao();
                    LabelPontuacao.Text = "Pontuação:R$" + Pontuacao.ToString();
                    LabelNivel.Text = "Nível:" + NivelAtual.ToString();
                }



            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Você errou!", "Tente novamente", "Ok");
                Inicializar();
            }

        }
        

        int NivelAtual = 1;

        void Inicializar()
        {
            Pontuacao = 0;
            NivelAtual = 1;
            ListaTodasQuestoesRespondidas.Clear();
            ProximaQuestao();

        }
        public Gerenciador(Label LabelPergunta, Button Button1, Button Button2, Button Button3, Button Button4, Button Button5, Label LabelPontuacao, Label LabelNivel)
        {
            CriarQuestoes(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            LabelPontuacao = LabelPontuacao;
            this.LabelNivel = LabelNivel;

        }
        void CriarQuestoes(Label LabelPergunta, Button Button1, Button Button2, Button Button3, Button Button4, Button Button5)
        {
            var Q1 = new Questao();
            Q1.Nivelresposta = 1;
            Q1.Pergunta = "Qual é o planeta mais próximo do Sol?";
            Q1.Resposta01 = "Vênus";
            Q1.Resposta02 = "Marte";
            Q1.Resposta03 = "Júpiter";
            Q1.Resposta04 = "Mercúrio";
            Q1.Resposta05 = "Saturno";
            Q1.RespostaCorreta = 4;
            Q1.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q1);

            var Q2 = new Questao();
            Q2.Nivelresposta = 1;
            Q2.Pergunta = "Quem escreveu 'Dom Quixote'?";
            Q2.Resposta01 = "William Shakespeare";
            Q2.Resposta02 = "Miguel de Cervantes";
            Q2.Resposta03 = "Gabriel García Márquez";
            Q2.Resposta04 = "Jorge Amado";
            Q2.Resposta05 = "Machado de Assis";
            Q2.RespostaCorreta = 2;
            Q2.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q2);

            var Q3 = new Questao();
            Q3.Nivelresposta = 1;
            Q3.Pergunta = "Qual é a capital da Austrália?";
            Q3.Resposta01 = "Sydney";
            Q3.Resposta02 = "Melbourne";
            Q3.Resposta03 = "Canberra";
            Q3.Resposta04 = "Perth";
            Q3.Resposta05 = "Brisbane";
            Q3.RespostaCorreta = 3;
            Q3.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q3);

            var Q4 = new Questao();
            Q4.Nivelresposta = 1;
            Q4.Pergunta = "Quem foi o primeiro presidente do Brasil?";
            Q4.Resposta01 = "Getúlio Vargas";
            Q4.Resposta02 = "Juscelino Kubitschek";
            Q4.Resposta03 = "Marechal Deodoro da Fonseca";
            Q4.Resposta04 = "Dom Pedro II";
            Q4.Resposta05 = "Epitácio Pessoa";
            Q4.RespostaCorreta = 3;
            Q4.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q4);

            var Q5 = new Questao();
            Q5.Nivelresposta = 1;
            Q5.Pergunta = "Qual é a fórmula química da água?";
            Q5.Resposta01 = "H2O2";
            Q5.Resposta02 = "CO2";
            Q5.Resposta03 = "H2O";
            Q5.Resposta04 = "O2";
            Q5.Resposta05 = "CH4";
            Q5.RespostaCorreta = 3;
            Q5.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q5);

            var Q6 = new Questao();
            Q6.Nivelresposta = 1;
            Q6.Pergunta = "Quem pintou a Mona Lisa?";
            Q6.Resposta01 = "Pablo Picasso";
            Q6.Resposta02 = "Leonardo da Vinci";
            Q6.Resposta03 = "Vincent van Gogh";
            Q6.Resposta04 = "Michelangelo";
            Q6.Resposta05 = "Salvador Dalí";
            Q6.RespostaCorreta = 2;
            Q6.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q6);

            var Q7 = new Questao();
            Q7.Nivelresposta = 1;
            Q7.Pergunta = "Qual o maior país em extensão territorial?";
            Q7.Resposta01 = "China";
            Q7.Resposta02 = "Canadá";
            Q7.Resposta03 = "Estados Unidos";
            Q7.Resposta04 = "Brasil";
            Q7.Resposta05 = "Rússia";
            Q7.RespostaCorreta = 5;
            Q7.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q7);

            var Q8 = new Questao();
            Q8.Nivelresposta = 1;
            Q8.Pergunta = "Qual a principal moeda do Japão?";
            Q8.Resposta01 = "Dólar";
            Q8.Resposta02 = "Euro";
            Q8.Resposta03 = "Yuan";
            Q8.Resposta04 = "Iene";
            Q8.Resposta05 = "Won";
            Q8.RespostaCorreta = 4;
            Q8.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q8);

            var Q9 = new Questao();
            Q9.Nivelresposta = 1;
            Q9.Pergunta = "Quem é o autor da teoria da evolução?";
            Q9.Resposta01 = "Isaac Newton";
            Q9.Resposta02 = "Albert Einstein";
            Q9.Resposta03 = "Charles Darwin";
            Q9.Resposta04 = "Gregor Mendel";
            Q9.Resposta05 = "Galileo Galilei";
            Q9.RespostaCorreta = 3;
            Q9.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q9);

            var Q10 = new Questao();
            Q10.Nivelresposta = 1;
            Q10.Pergunta = "Qual a camada da atmosfera responsável pela proteção contra raios UV?";
            Q10.Resposta01 = "Estratosfera";
            Q10.Resposta02 = "Troposfera";
            Q10.Resposta03 = "Exosfera";
            Q10.Resposta04 = "Mesosfera";
            Q10.Resposta05 = "Ionosfera";
            Q10.RespostaCorreta = 1;
            Q10.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q10);

            var Q11 = new Questao();
            Q11.Nivelresposta = 2;
            Q11.Pergunta = "Qual é o maior oceano do mundo?";
            Q11.Resposta01 = "Oceano Atlântico";
            Q11.Resposta02 = "Oceano Índico";
            Q11.Resposta03 = "Oceano Ártico";
            Q11.Resposta04 = "Oceano Pacífico";
            Q11.Resposta05 = "Oceano Antártico";
            Q11.RespostaCorreta = 4;
            Q11.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q11);

            var Q12 = new Questao();
            Q12.Nivelresposta = 2;
            Q12.Pergunta = "Qual país é conhecido por ter o formato de uma bota?";
            Q12.Resposta01 = "Espanha";
            Q12.Resposta02 = "Grécia";
            Q12.Resposta03 = "França";
            Q12.Resposta04 = "Itália";
            Q12.Resposta05 = "Portugal";
            Q12.RespostaCorreta = 4;
            Q12.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q12);

            var Q13 = new Questao();
            Q13.Nivelresposta = 2;
            Q13.Pergunta = "Qual desses animais é um mamífero?";
            Q13.Resposta01 = "Cobra";
            Q13.Resposta02 = "Golfinho";
            Q13.Resposta03 = "Galinha";
            Q13.Resposta04 = "Sapo";
            Q13.Resposta05 = "Crocodilo";
            Q13.RespostaCorreta = 2;
            Q13.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q13);

            var Q14 = new Questao();
            Q14.Nivelresposta = 2;
            Q14.Pergunta = "Quem descobriu o Brasil?";
            Q14.Resposta01 = "Cristóvão Colombo";
            Q14.Resposta02 = "Pedro Álvares Cabral";
            Q14.Resposta03 = "Vasco da Gama";
            Q14.Resposta04 = "Fernando de Magalhães";
            Q14.Resposta05 = "Amerigo Vespucci";
            Q14.RespostaCorreta = 2;
            Q14.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q14);

            var Q15 = new Questao();
            Q15.Nivelresposta = 2;
            Q15.Pergunta = "Qual é o menor estado do Brasil em extensão territorial?";
            Q15.Resposta01 = "Alagoas";
            Q15.Resposta02 = "Rio de Janeiro";
            Q15.Resposta03 = "Espírito Santo";
            Q15.Resposta04 = "Sergipe";
            Q15.Resposta05 = "Acre";
            Q15.RespostaCorreta = 4;
            Q15.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q15);

            var Q16 = new Questao();
            Q16.Nivelresposta = 2;
            Q16.Pergunta = "Em que ano ocorreu a Proclamação da República no Brasil?";
            Q16.Resposta01 = "1808";
            Q16.Resposta02 = "1822";
            Q16.Resposta03 = "1889";
            Q16.Resposta04 = "1900";
            Q16.Resposta05 = "1922";
            Q16.RespostaCorreta = 3;
            Q16.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q16);

            var Q17 = new Questao();
            Q17.Nivelresposta = 2;
            Q17.Pergunta = "Qual desses elementos químicos é um metal?";
            Q17.Resposta01 = "Hélio";
            Q17.Resposta02 = "Oxigênio";
            Q17.Resposta03 = "Enxofre";
            Q17.Resposta04 = "Ferro";
            Q17.Resposta05 = "Cloro";
            Q17.RespostaCorreta = 4;
            Q17.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q17);

            var Q18 = new Questao();
            Q18.Nivelresposta = 2;
            Q18.Pergunta = "Qual é o maior deserto do mundo?";
            Q18.Resposta01 = "Saara";
            Q18.Resposta02 = "Kalahari";
            Q18.Resposta03 = "Deserto da Arábia";
            Q18.Resposta04 = "Deserto de Gobi";
            Q18.Resposta05 = "Antártida";
            Q18.RespostaCorreta = 5;
            Q18.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q18);

            var Q19 = new Questao();
            Q19.Nivelresposta = 2;
            Q19.Pergunta = "Quem é conhecido como o 'pai da aviação' no Brasil?";
            Q19.Resposta01 = "Alberto Santos Dumont";
            Q19.Resposta02 = "Irmãos Wright";
            Q19.Resposta03 = "Bartolomeu de Gusmão";
            Q19.Resposta04 = "Charles Lindbergh";
            Q19.Resposta05 = "Leonardo da Vinci";
            Q19.RespostaCorreta = 1;
            Q19.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q19);

            var Q20 = new Questao();
            Q20.Nivelresposta = 2;
            Q20.Pergunta = "Qual é o nome da maior floresta tropical do mundo?";
            Q20.Resposta01 = "Floresta Amazônica";
            Q20.Resposta02 = "Floresta Negra";
            Q20.Resposta03 = "Taiga";
            Q20.Resposta04 = "Floresta do Congo";
            Q20.Resposta05 = "Floresta de Borneo";
            Q20.RespostaCorreta = 1;
            Q20.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q20);

            var Q21 = new Questao();
            Q21.Nivelresposta = 3;
            Q21.Pergunta = "Qual a capital da França?";
            Q21.Resposta01 = "Berlim";
            Q21.Resposta02 = "Paris";
            Q21.Resposta03 = "Roma";
            Q21.Resposta04 = "Madri";
            Q21.Resposta05 = "Lisboa";
            Q21.RespostaCorreta = 2;
            Q21.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q21);

            var Q22 = new Questao();
            Q22.Nivelresposta = 3;
            Q22.Pergunta = "Quem desenvolveu a teoria da relatividade?";
            Q22.Resposta01 = "Isaac Newton";
            Q22.Resposta02 = "Nikola Tesla";
            Q22.Resposta03 = "Albert Einstein";
            Q22.Resposta04 = "Stephen Hawking";
            Q22.Resposta05 = "Marie Curie";
            Q22.RespostaCorreta = 3;
            Q22.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q22);

            var Q23 = new Questao();
            Q23.Nivelresposta = 3;
            Q23.Pergunta = "Qual a montanha mais alta do mundo?";
            Q23.Resposta01 = "K2";
            Q23.Resposta02 = "Everest";
            Q23.Resposta03 = "Kangchenjunga";
            Q23.Resposta04 = "Makalu";
            Q23.Resposta05 = "Lhotse";
            Q23.RespostaCorreta = 2;
            Q23.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q23);

            var Q24 = new Questao();
            Q24.Nivelresposta = 3;
            Q24.Pergunta = "Qual é o país mais populoso do mundo?";
            Q24.Resposta01 = "Índia";
            Q24.Resposta02 = "Estados Unidos";
            Q24.Resposta03 = "Brasil";
            Q24.Resposta04 = "China";
            Q24.Resposta05 = "Indonésia";
            Q24.RespostaCorreta = 4;
            Q24.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q24);

            var Q25 = new Questao();
            Q25.Nivelresposta = 3;
            Q25.Pergunta = "Qual é o maior animal terrestre?";
            Q25.Resposta01 = "Elefante Africano";
            Q25.Resposta02 = "Girafa";
            Q25.Resposta03 = "Rinoceronte";
            Q25.Resposta04 = "Hipopótamo";
            Q25.Resposta05 = "Leão";
            Q25.RespostaCorreta = 1;
            Q25.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q25);

            var Q26 = new Questao();
            Q26.Nivelresposta = 3;
            Q26.Pergunta = "Qual a capital da Argentina?";
            Q26.Resposta01 = "Santiago";
            Q26.Resposta02 = "Lima";
            Q26.Resposta03 = "Buenos Aires";
            Q26.Resposta04 = "Caracas";
            Q26.Resposta05 = "Bogotá";
            Q26.RespostaCorreta = 3;
            Q26.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q26);

            var Q27 = new Questao();
            Q27.Nivelresposta = 3;
            Q27.Pergunta = "Quem pintou o teto da Capela Sistina?";
            Q27.Resposta01 = "Leonardo da Vinci";
            Q27.Resposta02 = "Vincent van Gogh";
            Q27.Resposta03 = "Michelangelo";
            Q27.Resposta04 = "Claude Monet";
            Q27.Resposta05 = "Pablo Picasso";
            Q27.RespostaCorreta = 3;
            Q27.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q27);

            var Q28 = new Questao();
            Q28.Nivelresposta = 3;
            Q28.Pergunta = "Qual é o metal cujo símbolo químico é Fe?";
            Q28.Resposta01 = "Ouro";
            Q28.Resposta02 = "Prata";
            Q28.Resposta03 = "Ferro";
            Q28.Resposta04 = "Cobre";
            Q28.Resposta05 = "Mercúrio";
            Q28.RespostaCorreta = 3;
            Q28.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q28);

            var Q29 = new Questao();
            Q29.Nivelresposta = 3;
            Q29.Pergunta = "Quem foi o primeiro homem a pisar na Lua?";
            Q29.Resposta01 = "Yuri Gagarin";
            Q29.Resposta02 = "Buzz Aldrin";
            Q29.Resposta03 = "Neil Armstrong";
            Q29.Resposta04 = "Michael Collins";
            Q29.Resposta05 = "Alan Shepard";
            Q29.RespostaCorreta = 3;
            Q29.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q29);

            var Q30 = new Questao();
            Q30.Nivelresposta = 3;
            Q30.Pergunta = "Qual é o maior país da América do Sul?";
            Q30.Resposta01 = "Argentina";
            Q30.Resposta02 = "Peru";
            Q30.Resposta03 = "Colômbia";
            Q30.Resposta04 = "Brasil";
            Q30.Resposta05 = "Chile";
            Q30.RespostaCorreta = 4;
            Q30.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q30);

            var Q31 = new Questao();
            Q31.Nivelresposta = 4;
            Q31.Pergunta = "Qual é a língua mais falada no mundo?";
            Q31.Resposta01 = "Espanhol";
            Q31.Resposta02 = "Chinês";
            Q31.Resposta03 = "Inglês";
            Q31.Resposta04 = "Francês";
            Q31.Resposta05 = "Árabe";
            Q31.RespostaCorreta = 2;
            Q31.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q31);

            var Q32 = new Questao();
            Q32.Nivelresposta = 4;
            Q32.Pergunta = "Quantos continentes existem na Terra?";
            Q32.Resposta01 = "4";
            Q32.Resposta02 = "5";
            Q32.Resposta03 = "6";
            Q32.Resposta04 = "7";
            Q32.Resposta05 = "8";
            Q32.RespostaCorreta = 4;
            Q32.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q32);

            var Q33 = new Questao();
            Q33.Nivelresposta = 4;
            Q33.Pergunta = "Qual é a maior ilha do mundo?";
            Q33.Resposta01 = "Madagascar";
            Q33.Resposta02 = "Groenlândia";
            Q33.Resposta03 = "Austrália";
            Q33.Resposta04 = "Islândia";
            Q33.Resposta05 = "Nova Zelândia";
            Q33.RespostaCorreta = 2;
            Q33.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q33);

            var Q34 = new Questao();
            Q34.Nivelresposta = 4;
            Q34.Pergunta = "Qual é o país mais extenso da Europa?";
            Q34.Resposta01 = "França";
            Q34.Resposta02 = "Alemanha";
            Q34.Resposta03 = "Espanha";
            Q34.Resposta04 = "Rússia";
            Q34.Resposta05 = "Itália";
            Q34.RespostaCorreta = 4;
            Q34.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q34);

            var Q35 = new Questao();
            Q35.Nivelresposta = 4;
            Q35.Pergunta = "Qual é o estado brasileiro conhecido como 'Terra da Garoa'?";
            Q35.Resposta01 = "Rio de Janeiro";
            Q35.Resposta02 = "Minas Gerais";
            Q35.Resposta03 = "Espírito Santo";
            Q35.Resposta04 = "São Paulo";
            Q35.Resposta05 = "Paraná";
            Q35.RespostaCorreta = 4;
            Q35.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q35);

            var Q36 = new Questao();
            Q36.Nivelresposta = 4;
            Q36.Pergunta = "Quem foi o primeiro imperador do Brasil?";
            Q36.Resposta01 = "Dom Pedro I";
            Q36.Resposta02 = "Dom Pedro II";
            Q36.Resposta03 = "Getúlio Vargas";
            Q36.Resposta04 = "Juscelino Kubitschek";
            Q36.Resposta05 = "Floriano Peixoto";
            Q36.RespostaCorreta = 1;
            Q36.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q36);

            var Q37 = new Questao();
            Q37.Nivelresposta = 4;
            Q37.Pergunta = "Quantos estados o Brasil tem?";
            Q37.Resposta01 = "24";
            Q37.Resposta02 = "25";
            Q37.Resposta03 = "26";
            Q37.Resposta04 = "27";
            Q37.Resposta05 = "28";
            Q37.RespostaCorreta = 3;
            Q37.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q37);

            var Q38 = new Questao();
            Q38.Nivelresposta = 4;
            Q38.Pergunta = "Qual é a menor unidade estrutural dos organismos vivos?";
            Q38.Resposta01 = "Molécula";
            Q38.Resposta02 = "Célula";
            Q38.Resposta03 = "Átomo";
            Q38.Resposta04 = "Tecido";
            Q38.Resposta05 = "Organelo";
            Q38.RespostaCorreta = 2;
            Q38.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q38);

            var Q39 = new Questao();
            Q39.Nivelresposta = 4;
            Q39.Pergunta = "Em qual país se localiza o rio Nilo?";
            Q39.Resposta01 = "Índia";
            Q39.Resposta02 = "Egito";
            Q39.Resposta03 = "China";
            Q39.Resposta04 = "México";
            Q39.Resposta05 = "Brasil";
            Q39.RespostaCorreta = 2;
            Q39.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q39);

            var Q40 = new Questao();
            Q40.Nivelresposta = 4;
            Q40.Pergunta = "Qual o número do átomo de carbono na tabela periódica?";
            Q40.Resposta01 = "4";
            Q40.Resposta02 = "6";
            Q40.Resposta03 = "8";
            Q40.Resposta04 = "10";
            Q40.Resposta05 = "12";
            Q40.RespostaCorreta = 2;
            Q40.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q40);

            var Q41 = new Questao();
            Q41.Nivelresposta = 5;
            Q41.Pergunta = "Em que ano o homem chegou à Lua pela primeira vez?";
            Q41.Resposta01 = "1959";
            Q41.Resposta02 = "1965";
            Q41.Resposta03 = "1969";
            Q41.Resposta04 = "1972";
            Q41.Resposta05 = "1975";
            Q41.RespostaCorreta = 3;
            Q41.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q41);

            var Q42 = new Questao();
            Q42.Nivelresposta = 5;
            Q42.Pergunta = "Qual é o nome do processo de divisão celular que resulta em duas células idênticas?";
            Q42.Resposta01 = "Meiose";
            Q42.Resposta02 = "Metabolismo";
            Q42.Resposta03 = "Mitose";
            Q42.Resposta04 = "Fermentação";
            Q42.Resposta05 = "Fusão nuclear";
            Q42.RespostaCorreta = 3;
            Q42.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q42);

            var Q43 = new Questao();
            Q43.Nivelresposta = 5;
            Q43.Pergunta = "Em que ano ocorreu a Revolução Francesa?";
            Q43.Resposta01 = "1759";
            Q43.Resposta02 = "1776";
            Q43.Resposta03 = "1789";
            Q43.Resposta04 = "1804";
            Q43.Resposta05 = "1848";
            Q43.RespostaCorreta = 3;
            Q43.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q43);

            var Q44 = new Questao();
            Q44.Nivelresposta = 5;
            Q44.Pergunta = "Quem foi o primeiro presidente dos Estados Unidos?";
            Q44.Resposta01 = "Thomas Jefferson";
            Q44.Resposta02 = "Abraham Lincoln";
            Q44.Resposta03 = "George Washington";
            Q44.Resposta04 = "John Adams";
            Q44.Resposta05 = "Franklin D. Roosevelt";
            Q44.RespostaCorreta = 3;
            Q44.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q44);

            var Q45 = new Questao();
            Q45.Nivelresposta = 5;
            Q45.Pergunta = "Qual é o órgão responsável por bombear o sangue no corpo humano?";
            Q45.Resposta01 = "Pulmões";
            Q45.Resposta02 = "Fígado";
            Q45.Resposta03 = "Coração";
            Q45.Resposta04 = "Cérebro";
            Q45.Resposta05 = "Rins";
            Q45.RespostaCorreta = 3;
            Q45.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q45);

            var Q46 = new Questao();
            Q46.Nivelresposta = 5;
            Q46.Pergunta = "Qual é o menor planeta do sistema solar?";
            Q46.Resposta01 = "Vênus";
            Q46.Resposta02 = "Marte";
            Q46.Resposta03 = "Mercúrio";
            Q46.Resposta04 = "Netuno";
            Q46.Resposta05 = "Plutão";
            Q46.RespostaCorreta = 3;
            Q46.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q46);

            var Q47 = new Questao();
            Q47.Nivelresposta = 5;
            Q47.Pergunta = "Em que cidade fica localizado o Coliseu?";
            Q47.Resposta01 = "Paris";
            Q47.Resposta02 = "Londres";
            Q47.Resposta03 = "Atenas";
            Q47.Resposta04 = "Roma";
            Q47.Resposta05 = "Istambul";
            Q47.RespostaCorreta = 4;
            Q47.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q47);

            var Q48 = new Questao();
            Q48.Nivelresposta = 5;
            Q48.Pergunta = "Quem descobriu o Brasil em 1500?";
            Q48.Resposta01 = "Pedro Álvares Cabral";
            Q48.Resposta02 = "Cristóvão Colombo";
            Q48.Resposta03 = "Vasco da Gama";
            Q48.Resposta04 = "Fernão de Magalhães";
            Q48.Resposta05 = "Bartolomeu Dias";
            Q48.RespostaCorreta = 1;
            Q48.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q48);

            var Q49 = new Questao();
            Q49.Nivelresposta = 5;
            Q49.Pergunta = "Qual o símbolo químico do ouro?";
            Q49.Resposta01 = "Ag";
            Q49.Resposta02 = "Au";
            Q49.Resposta03 = "Fe";
            Q49.Resposta04 = "Hg";
            Q49.Resposta05 = "Pb";
            Q49.RespostaCorreta = 2;
            Q49.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q49);

            var Q50 = new Questao();
            Q50.Nivelresposta = 5;
            Q50.Pergunta = "Qual é o maior oceano do mundo?";
            Q50.Resposta01 = "Oceano Atlântico";
            Q50.Resposta02 = "Oceano Índico";
            Q50.Resposta03 = "Oceano Pacífico";
            Q50.Resposta04 = "Oceano Ártico";
            Q50.Resposta05 = "Oceano Antártico";
            Q50.RespostaCorreta = 3;
            Q50.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q50);

            var Q51 = new Questao();
            Q51.Nivelresposta = 6;
            Q51.Pergunta = "Qual é o maior planeta do sistema solar?";
            Q51.Resposta01 = "Terra";
            Q51.Resposta02 = "Saturno";
            Q51.Resposta03 = "Urano";
            Q51.Resposta04 = "Júpiter";
            Q51.Resposta05 = "Netuno";
            Q51.RespostaCorreta = 4;
            Q51.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q51);

            var Q52 = new Questao();
            Q52.Nivelresposta = 6;
            Q52.Pergunta = "Em que ano começou a Primeira Guerra Mundial?";
            Q52.Resposta01 = "1912";
            Q52.Resposta02 = "1914";
            Q52.Resposta03 = "1916";
            Q52.Resposta04 = "1918";
            Q52.Resposta05 = "1920";
            Q52.RespostaCorreta = 2;
            Q52.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q52);

            var Q53 = new Questao();
            Q53.Nivelresposta = 6;
            Q53.Pergunta = "Qual é o estado brasileiro conhecido como 'Terra dos Pampas'?";
            Q53.Resposta01 = "Rio de Janeiro";
            Q53.Resposta02 = "Paraná";
            Q53.Resposta03 = "Santa Catarina";
            Q53.Resposta04 = "Rio Grande do Sul";
            Q53.Resposta05 = "Mato Grosso do Sul";
            Q53.RespostaCorreta = 4;
            Q53.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q53);

            var Q54 = new Questao();
            Q54.Nivelresposta = 6;
            Q54.Pergunta = "Qual é a estrela mais próxima da Terra?";
            Q54.Resposta01 = "Estrela Polar";
            Q54.Resposta02 = "Sirius";
            Q54.Resposta03 = "Sol";
            Q54.Resposta04 = "Betelgeuse";
            Q54.Resposta05 = "Proxima Centauri";
            Q54.RespostaCorreta = 3;
            Q54.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q54);

            var Q55 = new Questao();
            Q55.Nivelresposta = 6;
            Q55.Pergunta = "Qual é o órgão responsável pela digestão no corpo humano?";
            Q55.Resposta01 = "Coração";
            Q55.Resposta02 = "Pulmões";
            Q55.Resposta03 = "Estômago";
            Q55.Resposta04 = "Fígado";
            Q55.Resposta05 = "Rins";
            Q55.RespostaCorreta = 3;
            Q55.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q55);

            var Q56 = new Questao();
            Q56.Nivelresposta = 6;
            Q56.Pergunta = "Em que cidade foram realizados os primeiros Jogos Olímpicos modernos?";
            Q56.Resposta01 = "Paris";
            Q56.Resposta02 = "Londres";
            Q56.Resposta03 = "Atenas";
            Q56.Resposta04 = "Roma";
            Q56.Resposta05 = "Berlim";
            Q56.RespostaCorreta = 3;
            Q56.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q56);

            var Q57 = new Questao();
            Q57.Nivelresposta = 6;
            Q57.Pergunta = "Em que ano caiu o Muro de Berlim?";
            Q57.Resposta01 = "1985";
            Q57.Resposta02 = "1987";
            Q57.Resposta03 = "1989";
            Q57.Resposta04 = "1991";
            Q57.Resposta05 = "1993";
            Q57.RespostaCorreta = 3;
            Q57.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q57);

            var Q58 = new Questao();
            Q58.Nivelresposta = 6;
            Q58.Pergunta = "Qual é o símbolo químico da água?";
            Q58.Resposta01 = "H2O";
            Q58.Resposta02 = "O2";
            Q58.Resposta03 = "CO2";
            Q58.Resposta04 = "NaCl";
            Q58.Resposta05 = "CH4";
            Q58.RespostaCorreta = 1;
            Q58.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q58);

            var Q59 = new Questao();
            Q59.Nivelresposta = 6;
            Q59.Pergunta = "Em que continente fica a Austrália?";
            Q59.Resposta01 = "Ásia";
            Q59.Resposta02 = "Europa";
            Q59.Resposta03 = "América do Norte";
            Q59.Resposta04 = "Oceania";
            Q59.Resposta05 = "África";
            Q59.RespostaCorreta = 4;
            Q59.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q59);

            var Q60 = new Questao();
            Q60.Nivelresposta = 6;
            Q60.Pergunta = "Qual é o planeta conhecido como o 'Planeta Vermelho'?";
            Q60.Resposta01 = "Vênus";
            Q60.Resposta02 = "Marte";
            Q60.Resposta03 = "Júpiter";
            Q60.Resposta04 = "Saturno";
            Q60.Resposta05 = "Mercúrio";
            Q60.RespostaCorreta = 2;
            Q60.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q60);

            var Q61 = new Questao();
            Q61.Nivelresposta = 7;
            Q61.Pergunta = "Qual o nome do compositor da famosa obra 'A Nona Sinfonia'?";
            Q61.Resposta01 = "Ludwig van Beethoven";
            Q61.Resposta02 = "Johann Sebastian Bach";
            Q61.Resposta03 = "Wolfgang Amadeus Mozart";
            Q61.Resposta04 = "Frédéric Chopin";
            Q61.Resposta05 = "Antonio Vivaldi";
            Q61.RespostaCorreta = 1;
            Q61.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q61);

            var Q62 = new Questao();
            Q62.Nivelresposta = 7;
            Q62.Pergunta = "Qual é a moeda oficial do Japão?";
            Q62.Resposta01 = "Iene";
            Q62.Resposta02 = "Dólar";
            Q62.Resposta03 = "Euro";
            Q62.Resposta04 = "Libra Esterlina";
            Q62.Resposta05 = "Yuan";
            Q62.RespostaCorreta = 1;
            Q62.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q62);

            var Q63 = new Questao();
            Q63.Nivelresposta = 7;
            Q63.Pergunta = "Qual é a fórmula química do gás carbônico?";
            Q63.Resposta01 = "CO";
            Q63.Resposta02 = "CO2";
            Q63.Resposta03 = "O2";
            Q63.Resposta04 = "H2O";
            Q63.Resposta05 = "CH4";
            Q63.RespostaCorreta = 2;
            Q63.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q63);

            var Q64 = new Questao();
            Q64.Nivelresposta = 7;
            Q64.Pergunta = "Em que ano ocorreu o Descobrimento do Brasil?";
            Q64.Resposta01 = "1400";
            Q64.Resposta02 = "1450";
            Q64.Resposta03 = "1500";
            Q64.Resposta04 = "1550";
            Q64.Resposta05 = "1600";
            Q64.RespostaCorreta = 3;
            Q64.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q64);

            var Q66 = new Questao();
            Q66.Nivelresposta = 7;
            Q66.Pergunta = "Quem pintou a obra 'Mona Lisa'?";
            Q66.Resposta01 = "Vincent van Gogh";
            Q66.Resposta02 = "Pablo Picasso";
            Q66.Resposta03 = "Leonardo da Vinci";
            Q66.Resposta04 = "Claude Monet";
            Q66.Resposta05 = "Salvador Dalí";
            Q66.RespostaCorreta = 3;
            Q66.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q66);

            var Q67 = new Questao();
            Q67.Nivelresposta = 7;
            Q67.Pergunta = "Em que ano foi declarada a independência dos Estados Unidos?";
            Q67.Resposta01 = "1776";
            Q67.Resposta02 = "1789";
            Q67.Resposta03 = "1812";
            Q67.Resposta04 = "1848";
            Q67.Resposta05 = "1865";
            Q67.RespostaCorreta = 1;
            Q67.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q67);

            var Q68 = new Questao();
            Q68.Nivelresposta = 7;
            Q68.Pergunta = "Qual é o elemento mais abundante no universo?";
            Q68.Resposta01 = "Oxigênio";
            Q68.Resposta02 = "Hidrogênio";
            Q68.Resposta03 = "Nitrogênio";
            Q68.Resposta04 = "Carbono";
            Q68.Resposta05 = "Hélio";
            Q68.RespostaCorreta = 2;
            Q68.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q68);

            var Q69 = new Questao();
            Q69.Nivelresposta = 7;
            Q69.Pergunta = "Quem escreveu 'Dom Quixote'?";
            Q69.Resposta01 = "Miguel de Cervantes";
            Q69.Resposta02 = "Gabriel García Márquez";
            Q69.Resposta03 = "William Shakespeare";
            Q69.Resposta04 = "Jorge Luis Borges";
            Q69.Resposta05 = "Mario Vargas Llosa";
            Q69.RespostaCorreta = 1;
            Q69.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q69);

            var Q70 = new Questao();
            Q70.Nivelresposta = 7;
            Q70.Pergunta = "Qual é o maior deserto do mundo?";
            Q70.Resposta01 = "Deserto de Gobi";
            Q70.Resposta02 = "Deserto do Saara";
            Q70.Resposta03 = "Deserto da Arábia";
            Q70.Resposta04 = "Deserto da Antártica";
            Q70.Resposta05 = "Deserto de Kalahari";
            Q70.RespostaCorreta = 2;
            Q70.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q70);

            var Q71 = new Questao();
            Q71.Nivelresposta = 8;
            Q71.Pergunta = "Qual é o idioma mais falado no mundo?";
            Q71.Resposta01 = "Inglês";
            Q71.Resposta02 = "Chinês mandarim";
            Q71.Resposta03 = "Espanhol";
            Q71.Resposta04 = "Hindi";
            Q71.Resposta05 = "Árabe";
            Q71.RespostaCorreta = 2;
            Q71.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q71);

            var Q72 = new Questao();
            Q72.Nivelresposta = 8;
            Q72.Pergunta = "Qual é o maior oceano da Terra?";
            Q72.Resposta01 = "Oceano Atlântico";
            Q72.Resposta02 = "Oceano Índico";
            Q72.Resposta03 = "Oceano Pacífico";
            Q72.Resposta04 = "Oceano Ártico";
            Q72.Resposta05 = "Oceano Antártico";
            Q72.RespostaCorreta = 3;
            Q72.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q72);

            var Q73 = new Questao();
            Q73.Nivelresposta = 8;
            Q73.Pergunta = "Qual é a principal fonte de energia do Sol?";
            Q73.Resposta01 = "Fissão nuclear";
            Q73.Resposta02 = "Combustão química";
            Q73.Resposta03 = "Fusão nuclear";
            Q73.Resposta04 = "Reação ácido-base";
            Q73.Resposta05 = "Oxidação";
            Q73.RespostaCorreta = 3;
            Q73.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q73);

            var Q74 = new Questao();
            Q74.Nivelresposta = 8;
            Q74.Pergunta = "Quem escreveu 'O Senhor dos Anéis'?";
            Q74.Resposta01 = "J.R.R. Tolkien";
            Q74.Resposta02 = "J.K. Rowling";
            Q74.Resposta03 = "George R.R. Martin";
            Q74.Resposta04 = "C.S. Lewis";
            Q74.Resposta05 = "H.P. Lovecraft";
            Q74.RespostaCorreta = 1;
            Q74.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q74);

            var Q75 = new Questao();
            Q75.Nivelresposta = 8;
            Q75.Pergunta = "Qual é o maior animal do planeta?";
            Q75.Resposta01 = "Elefante";
            Q75.Resposta02 = "Tubarão-baleia";
            Q75.Resposta03 = "Baleia Azul";
            Q75.Resposta04 = "Orca";
            Q75.Resposta05 = "Girafa";
            Q75.RespostaCorreta = 3;
            Q75.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q75);

            var Q76 = new Questao();
            Q76.Nivelresposta = 8;
            Q76.Pergunta = "Qual é o país mais populoso do mundo?";
            Q76.Resposta01 = "Índia";
            Q76.Resposta02 = "China";
            Q76.Resposta03 = "Estados Unidos";
            Q76.Resposta04 = "Indonésia";
            Q76.Resposta05 = "Paquistão";
            Q76.RespostaCorreta = 2;
            Q76.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q76);

            var Q77 = new Questao();
            Q77.Nivelresposta = 8;
            Q77.Pergunta = "Qual é a língua oficial do Brasil?";
            Q77.Resposta01 = "Espanhol";
            Q77.Resposta02 = "Português";
            Q77.Resposta03 = "Inglês";
            Q77.Resposta04 = "Francês";
            Q77.Resposta05 = "Italiano";
            Q77.RespostaCorreta = 2;
            Q77.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q77);

            var Q78 = new Questao();
            Q78.Nivelresposta = 8;
            Q78.Pergunta = "Quem é conhecido como o 'Pai da Psicanálise'?";
            Q78.Resposta01 = "Sigmund Freud";
            Q78.Resposta02 = "Carl Jung";
            Q78.Resposta03 = "Wilhelm Wundt";
            Q78.Resposta04 = "Ivan Pavlov";
            Q78.Resposta05 = "Erik Erikson";
            Q78.RespostaCorreta = 1;
            Q78.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q78);

            var Q79 = new Questao();
            Q79.Nivelresposta = 8;
            Q79.Pergunta = "Qual é a fórmula química do metano?";
            Q79.Resposta01 = "CH4";
            Q79.Resposta02 = "C2H6";
            Q79.Resposta03 = "C3H8";
            Q79.Resposta04 = "C4H10";
            Q79.Resposta05 = "C5H12";
            Q79.RespostaCorreta = 1;
            Q79.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q79);

            var Q80 = new Questao();
            Q80.Nivelresposta = 8;
            Q80.Pergunta = "Qual é a capital da França?";
            Q80.Resposta01 = "Paris";
            Q80.Resposta02 = "Londres";
            Q80.Resposta03 = "Madri";
            Q80.Resposta04 = "Roma";
            Q80.Resposta05 = "Berlim";
            Q80.RespostaCorreta = 1;
            Q80.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q80);

            var Q81 = new Questao();
            Q81.Nivelresposta = 9;
            Q81.Pergunta = "Qual é o maior deserto quente do mundo?";
            Q81.Resposta01 = "Deserto do Saara";
            Q81.Resposta02 = "Deserto da Arábia";
            Q81.Resposta03 = "Deserto de Gobi";
            Q81.Resposta04 = "Deserto de Kalahari";
            Q81.Resposta05 = "Deserto de Mojave";
            Q81.RespostaCorreta = 1;
            Q81.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q81);

            var Q82 = new Questao();
            Q82.Nivelresposta = 9;
            Q82.Pergunta = "Quem inventou o telefone?";
            Q82.Resposta01 = "Alexander Graham Bell";
            Q82.Resposta02 = "Thomas Edison";
            Q82.Resposta03 = "Nikola Tesla";
            Q82.Resposta04 = "Michael Faraday";
            Q82.Resposta05 = "James Clerk Maxwell";
            Q82.RespostaCorreta = 1;
            Q82.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q82);

            var Q83 = new Questao();
            Q82.Nivelresposta = 9;
            Q83.Pergunta = "Qual é a segunda maior cidade dos Estados Unidos em termos de população?";
            Q83.Resposta01 = "New York";
            Q83.Resposta02 = "Los Angeles";
            Q83.Resposta03 = "Chicago";
            Q83.Resposta04 = "Houston";
            Q83.Resposta05 = "Philadelphia";
            Q83.RespostaCorreta = 2;
            Q83.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q83);

            var Q84 = new Questao();
            Q84.Nivelresposta = 9;
            Q84.Pergunta = "Qual é o metal mais leve conhecido?";
            Q84.Resposta01 = "Lítio";
            Q84.Resposta02 = "Boro";
            Q84.Resposta03 = "Hélio";
            Q84.Resposta04 = "Sódio";
            Q84.Resposta05 = "Magnésio";
            Q84.RespostaCorreta = 1;
            Q84.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q84);

            var Q85 = new Questao();
            Q85.Nivelresposta = 9;
            Q85.Pergunta = "Qual é o continente mais seco do mundo?";
            Q85.Resposta01 = "África";
            Q85.Resposta02 = "Antártica";
            Q85.Resposta03 = "Ásia";
            Q85.Resposta04 = "América do Sul";
            Q85.Resposta05 = "Oceania";
            Q85.RespostaCorreta = 2;
            Q85.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q85);

            var Q86 = new Questao();
            Q86.Nivelresposta = 9;
            Q86.Pergunta = "Qual é a principal função do sistema circulatório?";
            Q86.Resposta01 = "Respiração";
            Q86.Resposta02 = "Digestão";
            Q86.Resposta03 = "Transporte de nutrientes e oxigênio";
            Q86.Resposta04 = "Produção de hormônios";
            Q86.Resposta05 = "Excreção de resíduos";
            Q86.RespostaCorreta = 3;
            Q86.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q86);

            var Q87 = new Questao();
            Q87.Nivelresposta = 9;
            Q87.Pergunta = "Quem é o autor da teoria da relatividade?";
            Q87.Resposta01 = "Isaac Newton";
            Q87.Resposta02 = "Albert Einstein";
            Q87.Resposta03 = "Niels Bohr";
            Q87.Resposta04 = "Galileo Galilei";
            Q87.Resposta05 = "Michael Faraday";
            Q87.RespostaCorreta = 2;
            Q87.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q87);

            var Q88 = new Questao();
            Q88.Nivelresposta = 9;
            Q88.Pergunta = "Qual é a capital da Itália?";
            Q88.Resposta01 = "Roma";
            Q88.Resposta02 = "Milão";
            Q88.Resposta03 = "Veneza";
            Q88.Resposta04 = "Florença";
            Q88.Resposta05 = "Nápoles";
            Q88.RespostaCorreta = 1;
            Q88.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q88);

            var Q89 = new Questao();
            Q89.Nivelresposta = 9;
            Q89.Pergunta = "Qual é o maior lago da África?";
            Q89.Resposta01 = "Lago Vitória";
            Q89.Resposta02 = "Lago Tanganica";
            Q89.Resposta03 = "Lago Malawi";
            Q89.Resposta04 = "Lago Chad";
            Q89.Resposta05 = "Lago Edward";
            Q89.RespostaCorreta = 1;
            Q89.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q89);

            var Q90 = new Questao();
            Q90.Nivelresposta = 9;
            Q90.Pergunta = "Qual é o principal gás responsável pelo efeito estufa?";
            Q90.Resposta01 = "Oxigênio";
            Q90.Resposta02 = "Hidrogênio";
            Q90.Resposta03 = "Dióxido de carbono";
            Q90.Resposta04 = "Metano";
            Q90.Resposta05 = "Nitrogênio";
            Q90.RespostaCorreta = 3;
            Q90.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q90);

            var Q91 = new Questao();
            Q91.Nivelresposta = 10;
            Q91.Pergunta = "Qual é o maior sistema montanhoso do mundo?";
            Q91.Resposta01 = "Montanhas Rochosas";
            Q91.Resposta02 = "Andes";
            Q91.Resposta03 = "Himalaia";
            Q91.Resposta04 = "Alpes";
            Q91.Resposta05 = "Apalaches";
            Q91.RespostaCorreta = 3;
            Q91.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q91);

            var Q92 = new Questao();
            Q92.Nivelresposta = 10;
            Q92.Pergunta = "Quem escreveu '1984'?";
            Q92.Resposta01 = "George Orwell";
            Q92.Resposta02 = "Aldous Huxley";
            Q92.Resposta03 = "Ray Bradbury";
            Q92.Resposta04 = "Margaret Atwood";
            Q92.Resposta05 = "H.G. Wells";
            Q92.RespostaCorreta = 1;
            Q92.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q92);

            var Q93 = new Questao();
            Q93.Nivelresposta = 10;
            Q93.Pergunta = "Qual é a fórmula química da água?";
            Q93.Resposta01 = "H2O";
            Q93.Resposta02 = "CO2";
            Q93.Resposta03 = "NaCl";
            Q93.Resposta04 = "CH4";
            Q93.Resposta05 = "O2";
            Q93.RespostaCorreta = 1;
            Q93.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q93);

            var Q94 = new Questao();
            Q94.Nivelresposta = 10;
            Q94.Pergunta = "Qual é o primeiro mês do ano no calendário gregoriano?";
            Q94.Resposta01 = "Janeiro";
            Q94.Resposta02 = "Fevereiro";
            Q94.Resposta03 = "Março";
            Q94.Resposta04 = "Abril";
            Q94.Resposta05 = "Maio";
            Q94.RespostaCorreta = 1;
            Q94.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q94);

            var Q95 = new Questao();
            Q95.Nivelresposta = 10;
            Q95.Pergunta = "Qual é o país que mais produz café no mundo?";
            Q95.Resposta01 = "Brasil";
            Q95.Resposta02 = "Colômbia";
            Q95.Resposta03 = "Vietnã";
            Q95.Resposta04 = "Honduras";
            Q95.Resposta05 = "Etiópia";
            Q95.RespostaCorreta = 1;
            Q95.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q95);

            var Q96 = new Questao();
            Q96.Nivelresposta = 10;
            Q96.Pergunta = "Qual é a unidade de medida da temperatura no sistema internacional?";
            Q96.Resposta01 = "Fahrenheit";
            Q96.Resposta02 = "Kelvin";
            Q96.Resposta03 = "Celsius";
            Q96.Resposta04 = "Réaumur";
            Q96.Resposta05 = "Rankine";
            Q96.RespostaCorreta = 2;
            Q96.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q96);

            var Q97 = new Questao();
            Q97.Nivelresposta = 10;
            Q97.Pergunta = "Qual é o nome do sistema solar em que a Terra está localizada?";
            Q97.Resposta01 = "Sistema Alpha";
            Q97.Resposta02 = "Sistema Andromeda";
            Q97.Resposta03 = "Sistema Sigma";
            Q97.Resposta04 = "Sistema Solar";
            Q97.Resposta05 = "Sistema Galáctico";
            Q97.RespostaCorreta = 4;
            Q97.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q97);

            var Q98 = new Questao();
            Q98.Nivelresposta = 10;
            Q98.Pergunta = "Qual é o principal ingrediente do guacamole?";
            Q98.Resposta01 = "Tomate";
            Q98.Resposta02 = "Cebola";
            Q98.Resposta03 = "Abacate";
            Q98.Resposta04 = "Pimentão";
            Q98.Resposta05 = "Cenoura";
            Q98.RespostaCorreta = 3;
            Q98.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q98);

            var Q99 = new Questao();
            Q99.Nivelresposta = 10;
            Q99.Pergunta = "Qual é o nome do dispositivo usado para medir a pressão arterial?";
            Q99.Resposta01 = "Termômetro";
            Q99.Resposta02 = "Esfigmomanômetro";
            Q99.Resposta03 = "Oximetro";
            Q99.Resposta04 = "Estetoscópio";
            Q99.Resposta05 = "Glicosímetro";
            Q99.RespostaCorreta = 2;
            Q99.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q99);

            var Q100 = new Questao();
            Q100.Nivelresposta = 10;
            Q100.Pergunta = "Qual é o animal conhecido por ter o pescoço mais longo?";
            Q100.Resposta01 = "Girafa";
            Q100.Resposta02 = "Elefante";
            Q100.Resposta03 = "Zebra";
            Q100.Resposta04 = "Cavalo";
            Q100.Resposta05 = "Camelo";
            Q100.RespostaCorreta = 1;
            Q100.ConfiguraEstruturaDesenho(LabelPergunta, Button1, Button2, Button3, Button4, Button5);
            ListaTodasQuestoes.Add(Q100);

            ProximaQuestao();

        }


    }
}