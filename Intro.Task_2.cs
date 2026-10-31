//Задание 2. Информация о компьютере
//Разработайте консольное приложение на C#, которое выводит:
//⦁	Имя компьютера.
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

//string hostName = Dns.GetHostName();


//Console.WriteLine(hostName);

//Задание 2. Информация о компьютере
//Разработайте консольное приложение на C#, которое выводит:
//⦁	Все обнаруженные IP-адреса.
//⦁	IPv4 - адреса отдельно от IPv6.

NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
foreach (NetworkInterface adapter in adapters)
{
    foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
    {

        //⦁	Все обнаруженные IP-адреса.
        //Console.WriteLine(ip.Address);
        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
        {
            Console.WriteLine("IPv4: " + ip.Address);
        }
        else if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
        {
            Console.WriteLine("IPv6: " + ip.Address);
        }
    }
}
