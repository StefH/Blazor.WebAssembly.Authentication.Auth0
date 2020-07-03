using System.Collections.Generic;
using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class Auth0ProviderOptions : OidcProviderOptions
    {
        private const string AudienceKey = "audience";

        /// <summary>
        /// Sets the audience of the application.
        /// </summary>
        public string? Audience { get; set; }

        /// <summary>
        /// Extra Query Parameters
        /// 
        /// See https://github.com/IdentityModel/oidc-client-js/blob/dev/src/OidcClient.js#L65
        /// </summary>
        [JsonPropertyName("extraQueryParams")]
        public IDictionary<string, string> ExtraQueryParams
        {
            get
            {
                var dictionary = new Dictionary<string, string>();
                if (!string.IsNullOrWhiteSpace(Audience))
                {
                    dictionary.Add(AudienceKey, Audience);
                }

                return dictionary;
            }
        }
    }
}