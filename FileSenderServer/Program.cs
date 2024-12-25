using System.Net.Sockets;
using System.Net;
using System.Text;

using FileInfoLib;


namespace FileSenderServer
{
    internal class Program
    {
        private static void Main(string[] args) => new Program().Run();
        private void Run()
        {
            
            Listen().Wait();
        }

        private IList<TcpClient> clients = []; 
        private async Task Listen()
        {
            TcpListener listen = new TcpListener(IPAddress.Any, 2024);
            listen.Start();
            Console.WriteLine("Сервер запущен");
            while (true)
            {
                TcpClient client = await listen.AcceptTcpClientAsync();
                lock (clients)
                    clients.Add(client);

                ListenToClient(client);

            }
        }
        CustomFileInfo customFileInfo;

        private async void ListenToClient(TcpClient client)
        {
            //string dir = "C:\\Games\\Test\\Server";
            string dir = Directory.GetCurrentDirectory();
            while (true)
            {
                
                customFileInfo = await CustomFileInfo.CustomReceiveFile(client, dir);
                customFileInfo.Path = dir;
                await SendToAll();  
            }

        }

        private async Task SendToAll()
        {           

            List<Task> sendings = new List<Task>();
            List<TcpClient> copyClients;
            lock (clients)
                copyClients = clients.ToList();
            foreach (var client in copyClients)
            {
                Task sending = CustomFileInfo.CustomSendFile (client, customFileInfo);
                sendings.Add(sending);
            }
            await Task.WhenAll(sendings);
        }        
    }
}
