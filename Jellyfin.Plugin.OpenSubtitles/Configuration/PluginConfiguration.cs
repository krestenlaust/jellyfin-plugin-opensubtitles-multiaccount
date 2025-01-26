using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.OpenSubtitles.Configuration;

/// <summary>
/// The plugin configuration.
/// </summary>
public class PluginConfiguration : BasePluginConfiguration
{
    /// <summary>
    /// Gets the username.
    /// </summary>
    public string Username => CurrentCredentials.Username;

    /// <summary>
    /// Gets the password.
    /// </summary>
    public string Password => CurrentCredentials.Password;

    /// <summary>
    /// Gets or sets a value indicating whether the credentials are invalid.
    /// </summary>
    public bool CredentialsInvalid
    {
        get => CurrentCredentials.CredentialsInvalid;
        set
        {
            CurrentCredentials.CredentialsInvalid = value;
        }
    }

    /// <summary>
    /// Gets a list of credentials.
    /// </summary>
    public Collection<Credentials> Credentials { get; } = new ();

    private Credentials CurrentCredentials =>
        Credentials.FirstOrDefault((elem) => !elem.CredentialsInvalid) ?? Credentials.First();
}
