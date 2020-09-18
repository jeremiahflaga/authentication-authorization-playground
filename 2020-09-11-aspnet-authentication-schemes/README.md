# Code for ["Experimenting with ASP.NET Core Authentication Schemes"](https://odetocode.com/blogs/scott/archive/2019/01/02/experimenting-with-asp-net-core-authentication-schemes.aspx) by Scott Allen

Was trying to have an answer to this question: https://github.com/dotnet-architecture/eShopOnContainers/issues/1423

<blockquote markdown="1">
I can see this in the `AccountController` of the Web MVC project

``` csharp
[Authorize(AuthenticationSchemes = "OpenIdConnect")]
public class AccountController : Controller
{
    ...
```

I tried to search for an explanation for that and found this: https://docs.microsoft.com/en-us/aspnet/core/security/authorization/limitingidentitybyscheme?view=aspnetcore-3.1

But the example there uses constant strings, like `JwtBearerDefaults.AuthenticationScheme`, instead of a literal string, like `"OpenIdConnect"`.

May I ask why that is the case? Is there no string constant for `"OpenIdConnect"`? How would one know which strings to put in there?

Thanks.
</blockquote>