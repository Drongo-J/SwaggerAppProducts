using ClientSwaggerApp.Services;
using E_CommerceClient.Models;
using System.Collections.ObjectModel;

namespace ClientSwaggerApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<Product> products = new ObservableCollection<Product>();

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public MainWindowViewModel()
        {
            NetworkServices.ConnectToServer();
            NetworkServices.RequestLoop();
        }
    }
}
