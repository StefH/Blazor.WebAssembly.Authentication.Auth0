using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public static class WebAssemblyAuth0ServiceCollectionExtensions
{
    /// <summary>
    /// Adds support for Auth0 authentication for SPA applications using <see cref="Auth0ProviderOptions"/> and the <see cref="RemoteAuthenticationState"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="configure">An action that will configure the <see cref="RemoteAuthenticationOptions{TProviderOptions}"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/> where the services were registered.</returns>
    public static IRemoteAuthenticationBuilder<RemoteAuthenticationState, RemoteUserAccount> AddAuth0Authentication(this IServiceCollection services, Action<RemoteAuthenticationOptions<Auth0ProviderOptions>> configure)
    {
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<RemoteAuthenticationOptions<Auth0ProviderOptions>>, DefaultAuth0ProviderOptionsConfiguration>());

        return services.AddRemoteAuthentication<RemoteAuthenticationState, RemoteUserAccount, Auth0ProviderOptions>(configure);
    }
}