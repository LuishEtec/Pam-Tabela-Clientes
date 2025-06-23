
using ClienteCrudApp.Models;
using ClienteCrudApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ClienteCrudApp.ViewModels
{
    public class ClientesViewModel : BaseViewModel
    {
        private ClienteService _clienteService = new ClienteService();

        public ObservableCollection<Cliente> Clientes { get; set; } = new ObservableCollection<Cliente>();

        private Cliente _clienteSelecionado;
        public Cliente ClienteSelecionado
        {
            get => _clienteSelecionado;
            set
            {
                _clienteSelecionado = value;
                OnPropertyChanged();
            }
        }

        public ICommand CarregarClientesCommand { get; }
        public ICommand AdicionarClienteCommand { get; }
        public ICommand AtualizarClienteCommand { get; }
        public ICommand DeletarClienteCommand { get; }

        public ClientesViewModel()
        {
            CarregarClientesCommand = new Command(async () => await CarregarClientes());
            AdicionarClienteCommand = new Command(async () => await AdicionarCliente());
            AtualizarClienteCommand = new Command(async () => await AtualizarCliente());
            DeletarClienteCommand = new Command(async () => await DeletarCliente());
        }

        private async Task CarregarClientes()
        {
            Clientes.Clear();
            var lista = await _clienteService.GetClientesAsync();
            foreach (var cliente in lista)
                Clientes.Add(cliente);
        }

        private async Task AdicionarCliente()
        {
            if (ClienteSelecionado != null)
            {
                await _clienteService.AddClienteAsync(ClienteSelecionado);
                await CarregarClientes();
            }
        }

        private async Task AtualizarCliente()
        {
            if (ClienteSelecionado != null)
            {
                await _clienteService.UpdateClienteAsync(ClienteSelecionado);
                await CarregarClientes();
            }
        }

        private async Task DeletarCliente()
        {
            if (ClienteSelecionado != null)
            {
                await _clienteService.DeleteClienteAsync(ClienteSelecionado.id_cliente);
                await CarregarClientes();
            }
        }
    }
}
