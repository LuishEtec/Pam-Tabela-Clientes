using ClienteCrudApp.Models;
using ClienteCrudApp.Services;
using ClienteCrudApp.Views;
using System.Windows.Input;

namespace ClienteCrudApp.ViewModels
{
    public class CadastroViewModel : BaseViewModel
    {
        private readonly ClienteService _clienteService = new();

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICommand CadastrarCommand { get; }

        public CadastroViewModel()
        {
            CadastrarCommand = new Command(async () => await Cadastrar());
        }

        private async Task Cadastrar()
        {
            var cliente = new Cliente
            {
                NomeCliente = Nome,
                EmailCliente = Email,
                SenhaCliente = Senha
            };

            try
            {
                var sucesso = await _clienteService.AddClienteAsync(cliente);

                if (sucesso)
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Cliente cadastrado!", "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new ClientePage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", _clienteService.LastErrorMessage ?? "Erro ao cadastrar cliente.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", $"Exceção: {ex.Message}", "OK");
            }
        }
    }
}
