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


//Задание 3. Работа с DNS
//Разработайте приложение, которое:
//1.Запрашивает у пользователя доменное имя.
Console.Write("Enter Domain Name: ");
string? domainName = Console.ReadLine();
if (string.IsNullOrWhiteSpace(domainName))
{
    Console.WriteLine("Domain name cannot be empty.");
    return;
}

//2.	Получает информацию об этом домене с помощью средств .NET.

try
{
    //2.	Получает информацию об этом домене с помощью средств .NET.
    IPHostEntry hostInfo = Dns.GetHostEntry(domainName);

    Console.WriteLine("Resolved IP addresses:");

    //3.	Выводит найденные IP-адреса.
    foreach (IPAddress ipAddressHostInfo in hostInfo.AddressList)
    {
        Console.WriteLine(ipAddressHostInfo);
    }
}
//4.	Корректно обрабатывает ошибки,
//если доменное имя не удалось разрешить.
catch (SocketException)
{
    Console.WriteLine("Unable to resolve the domain name.");
}
catch (ArgumentException)
{
    Console.WriteLine("Invalid domain name.");
}
//Примеры доменов для проверки: google.com, microsoft.com, github.com.
