using ClienteCrudApp.Views;

namespace ClienteCrudApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new CadastroPage());
    }
}
