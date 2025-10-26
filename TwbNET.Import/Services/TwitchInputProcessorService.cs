using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwbNET.Import.Models;
using TwitchLib.Client.Models;

namespace TwbNET.Import.Services;

public class TwitchInputProcessorService
{
    public async Task ProcessChatMessageAsync(ChatMessage chatMessage)
    {
        //TODO: 1 - Username auslagern
        //TODO: 2 - Nachricht auslagern
        //TODO: 3 - In Objekt auslagern bestehend aus Username und Nachricht
        if (!(chatMessage.Username.Equals("gottisminion_") && chatMessage.Message.Contains("Der Kampf ist vorbei,")))
        {
            return;
        }

        TwitchCatchSuccessMessage catchSuccessMessage = new TwitchCatchSuccessMessage(chatMessage.Message);
    }
}