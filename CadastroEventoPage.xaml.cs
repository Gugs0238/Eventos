using Eventos.Models;

namespace Eventos.Views;

public partial class CadastroEventoPage : ContentPage
{
    private Evento evento;

    public CadastroEventoPage()
    {
        InitializeComponent();

        evento = new Evento
        {
            DataInicio = DateTime.Today,
            DataFim = DateTime.Today.AddDays(1)
        };

        BindingContext = evento;

        // Define restrição inicial
        pickerFim.MinimumDate = evento.DataInicio;

        // Atualiza restrição sempre que a data de início mudar
        pickerInicio.DateSelected += (s, e) =>
        {
            pickerFim.MinimumDate = e.NewDate;
            if (pickerFim.Date < e.NewDate)
                pickerFim.Date = e.NewDate;
        };
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(evento.Nome) || string.IsNullOrWhiteSpace(evento.Local))
        {
            await DisplayAlert("Erro", "Preencha todos os campos obrigatórios.", "OK");
            return;
        }

        if (evento.DataFim < evento.DataInicio)
        {
            await DisplayAlert("Erro", "A data de término deve ser posterior à data de início.", "OK");
            return;
        }

        await Navigation.PushAsync(new ResumoEventoPage(evento));
    }
}