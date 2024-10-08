namespace JOGODOMILHAO;

public partial class Creditos : ContentPage
{

    public Creditos()
    {
        InitializeComponent();
    }
    
private void ButtonVoltarButtonClicked(object sender, EventArgs args)
{
	 Application.Current.MainPage = new TelaInicial();
}
}