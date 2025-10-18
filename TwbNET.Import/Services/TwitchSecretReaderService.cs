using Newtonsoft.Json;
using TwbNET.Import.Models;

namespace TwbNET.Import.Services
{
    internal static class TwitchSecretReaderService
    {
        public static TwitchSecrets ReadSecrets()
        {
            return JsonConvert.DeserializeObject<TwitchSecrets>(File.ReadAllText("Models/twitchSecrets.json"))
                   ?? throw new InvalidOperationException("Could not read Twitch secrets from twitch_secrets.json");
        }
    }
}
