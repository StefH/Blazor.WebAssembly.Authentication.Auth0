# Usage
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