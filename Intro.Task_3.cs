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
