namespace ClienteCrudApp.Views;
using ClienteCrudApp.ViewModels;

public partial class CadastroPage : ContentPage
{
	public CadastroPage()
	{
		InitializeComponent();
        BindingContext = new CadastroViewModel();
    }
}