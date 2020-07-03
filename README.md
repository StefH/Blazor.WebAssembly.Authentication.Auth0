# Blazor.WebAssembly.Authentication.Auth0
Blazor WebAssembly Auth0 Oidc Authentication with support for *Audience*, because the default AddOidcAuthentication does not support setting the Audience.

### Install the NuGet

```
PM> Install-Package WebAssembly.Authentication.Auth0
```

### Define app.settings
``` json
{
  "auth0": {
    "Authority": "https://***.eu.auth0.com/",
    "Audience": "***",
    "ClientId": "***",
    "ResponseType": "token id_token",
    "DefaultScopes": "email"
  }
}
```

### Add the required services
Support for authenticating users is registered in the service container with the `AddAuth0Authentication` extension method provided by the this package.
This method sets up the services required for the app to interact with the Identity Provider (IP).
``` c#
builder.Services.AddAuth0Authentication(options =>
{
    builder.Configuration.Bind("auth0", options.ProviderOptions);
});
```

---
### References
- [Example : BlazorWasmGrpcWithAuth0](https://github.com/StefH/BlazorWasmGrpcWithAuth0)
- [Secure an ASP.NET Core Blazor WebAssembly standalone app with the Authentication library](https://docs.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/standalone-with-authentication-library?view=aspnetcore-3.1)