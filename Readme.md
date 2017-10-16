Kingensoft Spa Services - Helpers for building single-page applications on ASP.NET MVC Core.
========================================
[![Build status](https://ci.appveyor.com/api/projects/status/vcrew365oubdmiuo?svg=true)](https://ci.appveyor.com/project/DustinKingen/spaservices)

Release Notes
-------------

[Located at dustinkingen.github.io/SpaServices](https://dustinkingen.github.io/SpaServices/)

Features
--------
Kingensoft.AspNetCore.SpaServices.TagHelpers is a [NuGet library](https://www.nuget.org/packages/Kingensoft.AspNetCore.SpaServices.TagHelpers) that contains tag helpers for building single-page applications on ASP.NET Core.

Embed application state into a view or page.
------------------------------------------------------------

```csharp
<application-state initial-state="@YourState">
```
Example usage:

Index.cshtml

```csharp
@page
@model IndexModel

<form id="app">
    {{ message }}
</form>

@section Scripts
{
    <application-state initial-state="@Model">

    <script type="text/javascript">
        var app = new Vue({
            el: '#app',
            data: window.__INITIAL_STATE__
        });
    </script>
}
```

Index.cshtml.cs

```csharp
// Opt in to capture members to output
[JsonObject(MemberSerialization.OptIn)]
public class IndexModel : PageModel
{
    [JsonProperty]
    public string Message { get; set; }
    
    public void OnGet()
    {
        Message = "Hello Vue!";
    }
}
```

Limitations and caveats
---------------------
`ApplicationStateTagHelper` is useful for smaller application (e.g. Razor Pages). Nesting application state (partial views) is not currently supported.

Do you have a comprehensive list of examples?
---------------------
Check out the [samples](https://github.com/DustinKingen/SpaServices/blob/master/samples).
