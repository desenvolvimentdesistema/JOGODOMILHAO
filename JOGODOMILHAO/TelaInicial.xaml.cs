namespace JOGODOMILHAO;

public partial class TelaInicial : ContentPage
{

    public TelaInicial()
    {
        InitializeComponent();
    }
    private void OnButtonIniciarJogoButtonClicked(object sender, EventArgs args)
    {

        Application.Current.MainPage = new MainPage();
    }
    private void OnButtonCreditosJogoButtonClicked(object sender, EventArgs args)
    {
         Application.Current.MainPage = new Creditos();
    }

}