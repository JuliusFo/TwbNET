using TwbNET.Import.Services;

Console.WriteLine("Booting TwbNet.Application");
TwitchInputReaderService twitchInputReaderService = new TwitchInputReaderService();
twitchInputReaderService.Connect();

while (true)
{
    string? input = Console.ReadLine();
    if (input?.ToLower() == "exit")
    {
        twitchInputReaderService.Disconnect();
        break;
    }
}