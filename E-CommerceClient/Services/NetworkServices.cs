using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using E_CommerceClient;
using Newtonsoft.Json;
using E_CommerceClient.Models;
using System.Reflection;

namespace ClientSwaggerApp.Services
{
    public class NetworkServices
    {
        private static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private static readonly IPAddress ServerIPAddress = IPAddress.Parse(NetworkServices.GetLocalIpAddress());

        private const int PORT = 27001;

        public static void ConnectToServer()
        {
            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    // Change IPAddress.Loopback to a remote IP to connect to a remote host.
                    ClientSocket.Connect(ServerIPAddress, PORT);
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            MessageBox.Show("Connected");
            SendString(@"Product\All");
            //var buffer = new byte[2048];
            //int received = ClientSocket.Receive(buffer, SocketFlags.None);
            //if (received == 0) return;
            //var data = new byte[received];
            //Array.Copy(buffer, data, received);
            //string text = Encoding.ASCII.GetString(data);
            //App.Current.Dispatcher.Invoke(() =>
            //{
            //    // Integrate to view
            //});
        }

        public static void RequestLoop()
        {
            var receiver = Task.Run(() =>
            {
                while (true)
                {
                    ReceiveResponse();
                }
            });
        }

        /// <summary>
        /// Sends a string to the server with ASCII encoding.
        /// </summary>
        private static void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private static void ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            if (text != string.Empty)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    try
                    {
                        dynamic products = JsonConvert.DeserializeObject(text);
                        foreach (var p in products)
                        {
                            var product = new Product(); 
                            product.Category = GetDynamicValue(p.Category, GetPropertyType("Category"));
                            product.CategoryID = GetDynamicValue(p.CategoryID, GetPropertyType("CategoryID"));
                            product.ProductID = GetDynamicValue(p.ProductID, GetPropertyType("ProductID"));
                            product.ProductName = GetDynamicValue(p.ProductName , GetPropertyType("ProductName"));
                            product.UnitPrice = GetDynamicValue(p.UnitPrice , GetPropertyType("UnitPrice"));
                            product.UnitsInStock = GetDynamicValue(p.UnitsInStock , GetPropertyType("UnitsInStock"));

                            App.DataContext.Products.Add(product);
                        }

                    }
                    catch (Exception)
                    {

                    }


                    //App.DataContext.Products.Add();
                });
            }
        }

        public static Type GetPropertyType(string propertyName)
        {
            Type type = typeof(Product);
            PropertyInfo property = type.GetProperty(propertyName);
            Type propertyType = property.PropertyType;
            return propertyType;
        }

        private static dynamic GetDynamicValue(object value, Type type)
        {
            if (value != null)
            {
                return value;
            }
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        public static string GetLocalIpAddress()
        {
            UnicastIPAddressInformation mostSuitableIp = null;
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;
                var properties = network.GetIPProperties();
                if (properties.GatewayAddresses.Count == 0)
                    continue;
                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;
                    if (IPAddress.IsLoopback(address.Address))
                        continue;
                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }
                    // The best IP is the IP got from DHCP server
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }
                    return address.Address.ToString();
                }
            }
            return mostSuitableIp != null
                ? mostSuitableIp.Address.ToString()
                : "";
        }


    }
}
