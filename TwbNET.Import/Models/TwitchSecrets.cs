using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwbNET.Import.Models;

public record TwitchSecrets(string Username, string OAuthToken, string TargetChannel);