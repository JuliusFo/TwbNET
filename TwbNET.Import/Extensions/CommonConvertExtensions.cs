using TwbNET.Import.Models;
using TwitchLib.Client.Models;

namespace TwbNET.Import.Extensions;

internal static class CommonConvertExtensions
{
    public static ConnectionCredentials ToConnectionCredentials(this TwitchSecrets twitchSecrets)
    {
        return new ConnectionCredentials(twitchSecrets.Username, twitchSecrets.OAuthToken);
    }
}