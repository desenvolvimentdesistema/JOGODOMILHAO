using JOGODOMILHAO;

public abstract class IAjuda
{
    protected Button ButtonResposta1;
    protected Button ButtonResposta2;
    protected Button ButtonResposta3;
    protected Button ButtonResposta4;
    protected Button ButtonResposta5;
    protected Frame FrameAjuda;

    public void ConfiguraDesenho (Button ButtonResposta1, Button ButtonResposta2, Button ButtonResposta3, Button ButtonResposta4, Button ButtonResposta5)
    {
        this.ButtonResposta1 = ButtonResposta1;
        this.ButtonResposta2 = ButtonResposta2;
        this.ButtonResposta3 = ButtonResposta3;
        this.ButtonResposta4 = ButtonResposta4;
        this.ButtonResposta5 = ButtonResposta5;

    }    
    public void ConfiguraDesenho (Frame FrameAjuda)
    {
        this.FrameAjuda = FrameAjuda;
    }
    public abstract void RealizaAjuda (Questao questao);

}