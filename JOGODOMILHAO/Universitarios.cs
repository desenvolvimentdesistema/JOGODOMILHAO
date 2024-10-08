namespace JOGODOMILHAO
{
    public class Universitarios : IAjuda
    {
        public override void RealizaAjuda(Questao questao)
        {
            var porcentagem = 100;
            for (int i = 0; i < 5; i++)
            {
                int numRandomico = 0;
                if (porcentagem > 0)
                {
                    numRandomico = Random.Shared.Next(0, porcentagem);
                    porcentagem -= numRandomico;

                }
                switch (i)
                {
                    case 0:
                        ButtonResposta1.Text += "-" + numRandomico.ToString() + "%";
                        break;
                    case 1:
                        ButtonResposta2.Text += "-" + numRandomico.ToString() + "%";
                        break;
                    case 2:
                        ButtonResposta3.Text += "-" + numRandomico.ToString() + "%";
                        break;
                    case 3:
                        ButtonResposta4.Text += "-" + numRandomico.ToString() + "%";
                        break;
                    case 4:
                        ButtonResposta5.Text += "-" + numRandomico.ToString() + "%";
                        break;


                }
            }
        }
    }
}