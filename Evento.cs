namespace Eventos.Models;

public class Evento
{
    public string Nome { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public int NumeroParticipantes { get; set; }
    public string Local { get; set; } = string.Empty;
    public double CustoPorParticipante { get; set; }

    public int DuracaoDias => (int)(DataFim - DataInicio).TotalDays;
    public double CustoTotal => NumeroParticipantes * CustoPorParticipante;
}