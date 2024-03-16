using System;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication;

internal class DefaultAuth0ProviderOptionsConfiguration : IPostConfigureOptions<RemoteAuthenticationOptions<Auth0ProviderOptions>>
{
    private readonly NavigationManager _navigationManager;

    public DefaultAuth0ProviderOptionsConfiguration(NavigationManager navigationManager) => _navigationManager = navigationManager;

    public void Configure(RemoteAuthenticationOptions<Auth0ProviderOptions> options)
    {
        options.UserOptions.AuthenticationType ??= options.ProviderOptions.ClientId;

        var redirectUri = options.ProviderOptions.RedirectUri;
        if (redirectUri == null || !Uri.TryCreate(redirectUri, UriKind.Absolute, out _))
        {
            redirectUri ??= "authentication/login-callback";
            options.ProviderOptions.RedirectUri = _navigationManager
                .ToAbsoluteUri(redirectUri).AbsoluteUri;
        }

        var logoutUri = options.ProviderOptions.PostLogoutRedirectUri;
        if (logoutUri == null || !Uri.TryCreate(logoutUri, UriKind.Absolute, out _))
        {
            logoutUri ??= "authentication/logout-callback";
            options.ProviderOptions.PostLogoutRedirectUri = _navigationManager
                .ToAbsoluteUri(logoutUri).AbsoluteUri;
        }
    }

    public void PostConfigure(string? name, RemoteAuthenticationOptions<Auth0ProviderOptions> options)
    {
        if (string.Equals(name, Options.DefaultName))
        {
            Configure(options);
        }
    }
}