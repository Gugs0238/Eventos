using Eventos.Views;

namespace Eventos;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new CadastroEventoPage())
        {
            BarBackgroundColor = Color.FromArgb("#BCEAE4"),
            BarTextColor = Colors.Black
        };
    }
}