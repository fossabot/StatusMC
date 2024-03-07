using MCQuery;

dynamic GetIp()
{
    Console.Write("Input server IP: ");
    dynamic ip = Console.ReadLine();
    return ip;
}

while (true)
{
    dynamic ip = GetIp();
    try
    {
        Console.Clear();
        Console.WriteLine(ip + "\n");
        MCServer srv = new MCServer(ip, 25565);
        ServerStatus status = srv.Status();
        Console.WriteLine($"Ping {Math.Round(srv.Ping())}ms");
        Console.WriteLine($"{status.Players.Online}/{status.Players.Max} players");
        Console.WriteLine($"Version {status.Version.Name}\n");
        Console.ReadKey();
        Console.Clear();
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Incorrect IP");
        Console.ReadKey();
        Console.Clear();
    }
    catch (TimeoutException)
    {
        Console.WriteLine("Incorrect IP or server is offline");
        Console.ReadKey();
        Console.Clear();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}
