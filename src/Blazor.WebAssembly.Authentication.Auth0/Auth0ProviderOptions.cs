using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{

    /// <summary>
    /// Enhances the <see cref="OidcProviderOptions"/> with Auth0-specific configuration.
    /// </summary>
    public class Auth0ProviderOptions : OidcProviderOptions
    {
        private const string AudienceKey = "audience";

        /// <summary>
        /// Sets the audience of the application.
        /// </summary>
        public string Audience
        {
            get => AdditionalProviderParameters.ContainsKey(AudienceKey) ? AdditionalProviderParameters[AudienceKey] : string.Empty;
            set => AdditionalProviderParameters[AudienceKey] = value;
        }

        /// <summary>
        /// Gets or sets the additional provider parameters to use on the authorization flow.
        /// </summary>
        /// <remarks>
        /// These parameters are for the IdP and not for the application. Using those parameters in the application in any way on the login callback will likely introduce security issues as they should be treated as untrusted input.
        /// </remarks>
        [JsonIgnore]
        [Obsolete("This property is called 'AdditionalProviderParameters' in OidcProviderOptions on .NET 6.0. For future compatibility, " +
            "we've left this property as a pointer to the new one. It will be removed in the next major version.", error: false)]
        public IDictionary<string, string> ExtraQueryParams
        {
            get => AdditionalProviderParameters;
        }

#if !NET6_0_OR_GREATER
        /// <summary>
        /// Gets or sets the additional provider parameters to use on the authorization flow.
        /// </summary>
        /// <remarks>
        /// See https://github.com/IdentityModel/oidc-client-js/blob/dev/src/OidcClient.js#L65.
        /// This property is already available in .NET 6.0, so we're hiding it on .NET 6 and later so it won't break the deserializer.
        /// These parameters are for the IdP and not for the application. Using those parameters in the application in any way on the login callback will likely introduce security issues as they should be treated as untrusted input.
        /// </remarks>
        [JsonPropertyName("extraQueryParams")]
        public IDictionary<string, string> AdditionalProviderParameters { get; set; } = new Dictionary<string, string>();
#endif
    }
}