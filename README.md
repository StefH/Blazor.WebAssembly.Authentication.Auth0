# Blazor.WebAssembly.Authentication.Auth0
Blazor WebAssembly Auth0 Oidc Authentication with support for `Audience`.

#### Install the NuGet

```
PM> Install-Package WebAssembly.Authentication.Auth0
```

#### Add the required dependency injections
``` diff
public void ConfigureServices(IServiceCollection services)
{
+    services.AddScoped<IHowl, Howl>();
+    services.AddScoped<IHowlGlobal, HowlGlobal>();
}
```
