// Задание 3. Работа с DNS
// Разработайте приложение, которое:
// 1.	Запрашивает у пользователя доменное имя.
// 2.	Получает информацию об этом домене с помощью средств .NET.
// 3.	Выводит найденные IP-адреса.
// 4.	Корректно обрабатывает ошибки, если доменное имя не удалось разрешить.
// Примеры доменов для проверки: google.com, microsoft.com, github.com.
// Пишет в Console.WriteLine(“Hello world”)


using System;
using System.Net;
using System.Net.Sockets;

Console.WriteLine("DNS Lookup");
Console.Write("Введите доменное имя: ");

string? domain = Console.ReadLine();

if (string.IsNullOrWhiteSpace(domain))
{
    Console.WriteLine("Ошибка: доменное имя не введено.");
}
else
{
    try
    {
        IPAddress[] addresses = Dns.GetHostAddresses(domain);

        Console.WriteLine($"IP-адреса домена {domain}:");

        foreach (IPAddress address in addresses)
        {
            Console.WriteLine($"{address} ({address.AddressFamily})");
        }

        Console.WriteLine("Hello world");
    }
    catch (SocketException ex)
    {
        Console.WriteLine($"Не удалось разрешить доменное имя: {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Некорректное доменное имя: {ex.Message}");
    }
}
