using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace TwbNET.Import.Models;

internal sealed class TwitchCatchSuccessMessage
{
    #region Fields

    private readonly string chatMessage;

    #endregion

    #region Constructor

    public TwitchCatchSuccessMessage(string chatMessage)
    {
        this.chatMessage = chatMessage;

        Pokemon = GetPokemonName();
        CatcherUsernames = GetCatchers();

    }

    #endregion

    #region Properties

    public IReadOnlyCollection<string> CatcherUsernames { get; private set; }

    public string Pokemon { get; set; }

    #endregion

    #region Methods

    private string GetPokemonName()
    {
        try
        {
            Regex regex_PKM = new Regex("dadurch (.*) fangen");
            Match match = regex_PKM.Match(chatMessage);
            return match.Groups[1].Value;
        }
        catch (Exception e)
        {
            return "Error when parsing pokemon name " + e.Message;
        }
    }

    private IReadOnlyCollection<string> GetCatchers()
    {
        List<string> result = new List<string>();

        //Der Kampf ist vorbei, die gotti1Pika von folgenden Trainern haben es überstanden und konnten dadurch Tragosso fangen: sokrates_333 (300),gotti1337 (300),benniii (300)
        Regex regex_PKM = new Regex("(: .*)");
        MatchCollection matches = regex_PKM.Matches(chatMessage);

        //First Catcher
        result.Add(matches[0].Value.Split(new[] { ' ' })[1]);

        //All others
        if (matches[0].Value.Contains(','))
        {
            string[] commaSeparatedCatchers = matches[0].Value.Replace(", ", ",").Split(new[] { ',' });

            for (int i = 1; i < commaSeparatedCatchers.Length; i++)
            {
                result.Add(commaSeparatedCatchers[i].Split(new[] { ' ' })[0]);
            }
        }

        return result.ToImmutableList();
    }

    #endregion
}