# TagHelperPack ![CI](https://github.com/DamianEdwards/TagHelperPack/actions/workflows/ci.yml/badge.svg) [![NuGet](https://img.shields.io/nuget/v/TagHelperPack?logo=nuget)](https://www.nuget.org/packages/TagHelperPack/)

A set of useful, and possibly opinionated, Tag Helpers for ASP.NET Core (all versions).

## Included Tag Helpers & Examples

See the examples page at https://taghelperpack.net

Supports ASP.NET Core 8.0.x.

## Installing

1. Add a reference to the package from the cmd line:

    ```shell
    MyGreatProject> dotnet add package TagHelperPack
    ```

1. Restore:

    ```shell
    MyGreatProject> dotnet restore
    ```

1. Register the Tag Helpers in your application's `_ViewImports.cshtml` file:

    ```cshtml
   @addTagHelper *, TagHelperPack
    ```

1. Optional: Register optimizations in `Program.cs`

    ```csharp
    services.AddTagHelperPack();
    ```
