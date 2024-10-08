namespace JOGODOMILHAO;

public partial class MainPage : ContentPage
{
	Gerenciador gerenciador;

	public MainPage()
	{
		InitializeComponent();
		gerenciador = new Gerenciador(LabelPergunta, Button1, Button2, Button3, Button4, Button5, LabelPontuacao, LabelNivel);

	}

	void OnButtonResposta01ButtonClicked(object sender, EventArgs args)
	{
		gerenciador.VerfiicaCorreto(1);
	}
	void OnButtonResposta02ButtonClicked(object sender, EventArgs args)
	{
		gerenciador.VerfiicaCorreto(2);
	}
	void OnButtonResposta03ButtonClicked(object sender, EventArgs args)
	{
		gerenciador.VerfiicaCorreto(3);
	}
	void OnButtonResposta04ButtonClicked(object sender, EventArgs args)
	{
		gerenciador.VerfiicaCorreto(4);
	}
	void OnButtonResposta05ButtonClicked(object sender, EventArgs args)
	{
		gerenciador.VerfiicaCorreto(5);
	}
	private void ButtonVoltarButtonClicked(object sender, EventArgs args)
	{

		Application.Current.MainPage = new TelaInicial();

	}

	int pulou = 0;
	async void OnAjudaPulaClicked(object s, EventArgs E)
	{
		if (await DisplayAlert("PULAR QUESTÃO!", "Deseja mesmo pular a questão, depois este recurso não estará mais disponível!!", "PULAR QUESTÃO", "CANCELAR"))
		{
			if (pulou == 2)
				(s as Button). IsVisible = false;
			else
			{
				gerenciador.LoadFromXaml ProximaQuestao();
				pulou ++;
			}
			Button AjudaPula.Text = "pula" + (3 - pula) + "x";
		}

	}
	async void OnAjudaRetirarClicked(object s, EventArgs e)
	{
		if (await DisplayAlert("CARTAS!!","Deseja mesmo usar o recurso das cartas, depois este recurso não estará mais disponível!!", "USAR AS CARTAS", "CANCELAR"))
		{
			var ajuda = new RetiraErradas();
			ajuda.ConfiguraDesenho(Button1, Button2, Button3, Button4, Button5);
			ajuda.RealizaAjuda(gerenciador.GetQuestaoAtual());
			(s as ImageButton).IsVisible = false;
		}

	}
	async void OnAjudaUniversitariosClicked(object s, EventArgs e)
	{
		if (await DisplayAlert("UNIVERSITÁRIOS!", "Deseja mesmo usar o recurso dos universitários, depois este recurso não estará mais disponível!!", "USAR AJUDA DOS UNIVERSITÁRIOS", "CANCELAR"))
		{
			var ajuda = new Universitarios();
			ajuda.ConfiguraDesenho(Button1, Button2, Button3, Button4, Button5);
			ajuda.RealizaAjuda(gerenciador.GetQuestaoAtual());
			(s as ImageButton).IsVisible = false;
		}

	}
}
