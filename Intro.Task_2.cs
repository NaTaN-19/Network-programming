// Задание 2. Информация о компьютере
// Разработайте консольное приложение на C#, которое выводит:
// ⦁	Имя компьютера.
// ⦁	Все обнаруженные IP-адреса.
// ⦁	IPv4-адреса отдельно от IPv6.
// ⦁	Семейство адреса для каждого IP-адреса.
// Результат должен быть представлен в удобном для чтения виде.


using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

// Имя компьютера
string hostName = Dns.GetHostName();

Console.WriteLine($"Имя компьютера: {hostName}");
Console.WriteLine();

// Получаем сетевые интерфейсы
NetworkInterface[] interfaces =
    NetworkInterface.GetAllNetworkInterfaces();

Console.WriteLine("Все обнаруженные IP-адреса:");

foreach (NetworkInterface networkInterface in interfaces)
{
    IPInterfaceProperties properties =
        networkInterface.GetIPProperties();

    foreach (UnicastIPAddressInformation addressInfo
             in properties.UnicastAddresses)
    {
        IPAddress ip = addressInfo.Address;

        Console.WriteLine(
            $"{ip} | Семейство: {ip.AddressFamily} | " +
            $"Интерфейс: {networkInterface.Name}");
    }
}

Console.WriteLine();
Console.WriteLine("IPv4-адреса:");

foreach (NetworkInterface networkInterface in interfaces)
{
    foreach (UnicastIPAddressInformation addressInfo
             in networkInterface.GetIPProperties().UnicastAddresses)
    {
        if (addressInfo.Address.AddressFamily ==
            AddressFamily.InterNetwork)
        {
            Console.WriteLine(addressInfo.Address);
        }
    }
}

Console.WriteLine();
Console.WriteLine("IPv6-адреса:");

foreach (NetworkInterface networkInterface in interfaces)
{
    foreach (UnicastIPAddressInformation addressInfo
             in networkInterface.GetIPProperties().UnicastAddresses)
    {
        if (addressInfo.Address.AddressFamily ==
            AddressFamily.InterNetworkV6)
        {
            Console.WriteLine(addressInfo.Address);
        }
    }
}
