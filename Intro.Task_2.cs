//Задание 2. Информация о компьютере
//Разработайте консольное приложение на C#, которое выводит:

using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

//⦁	Имя компьютера.
string hostName = Dns.GetHostName();
Console.WriteLine("___________ Computer Information ___________");
Console.WriteLine($"Computer name: {hostName}");



NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
Console.WriteLine("\n___________ IP Adresses ___________");
foreach (NetworkInterface adapter in adapters)
{
    foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
    {
        //⦁	Все обнаруженные IP-адреса.
        Console.WriteLine($"IP Address: {ip.Address}");

        //⦁	IPv4 - адреса отдельно от IPv6.
        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
        {
            Console.WriteLine("Type: IPv4");
        }
        else if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
        {
            Console.WriteLine("Type: IPv6");
        }

        //⦁	Семейство адреса для каждого IP-адреса.
        Console.WriteLine($"Address Family: {ip.Address.AddressFamily}");
        Console.WriteLine("___________________________________________");
    }
}
