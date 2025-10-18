using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TwbNET.Import.Extensions;
using TwbNET.Import.Models;
using TwbNET.Resources;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace TwbNET.Import.Services;

public class TwitchInputReaderService
{
    #region Fields

    private readonly TwitchClient client;
    private readonly string channelName;

    private int reconnectTries = 0;
    private readonly int reconnectTriesMAX = 3;
    private readonly int reconnectWaitTime = 120;

    #endregion

    #region Constructor

    public TwitchInputReaderService()
    {
        TwitchSecrets twitchSecrets = TwitchSecretReaderService.ReadSecrets();
        channelName = twitchSecrets.TargetChannel;
        ConnectionCredentials twitchCredentials = twitchSecrets.ToConnectionCredentials();

        client = new TwitchClient();
        client = new TwitchClient();
        client.Initialize(twitchCredentials, channelName);
        client.Connect();

        client.OnJoinedChannel += OnJoinedChannel;
    }

    #endregion

    #region Methods

    private void OnJoinedChannel(object? sender, OnJoinedChannelArgs e)
    {
        Console.WriteLine(MessageResources.TwitchConnectionSuccess, channelName);
        reconnectTries = 0;
    }

    #endregion
}