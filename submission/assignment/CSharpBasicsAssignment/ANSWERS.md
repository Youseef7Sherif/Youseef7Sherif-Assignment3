# Part G — Short Answers

## Q1. `.csproj` Contents

The `.csproj` file contains the following four required properties:

* **OutputType:** `Exe`
* **TargetFramework:** `net10.0`
* **ImplicitUsings:** `enable`
* **Nullable:** `enable`

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

## Q2. `#region / #endregion`

No, `#region` and `#endregion` do not change the compiled output. They are used to organize code in the editor and allow sections of code to be collapsed or expanded for easier navigation.

## Q3. XML Documentation Comments

I would use `///` XML documentation comments instead of `//` when documenting public classes, methods, or other members. They provide a clear description of what the member does and can be used to create documentation for the code.

## Q4. Global Variables

C# has no true global variables because variables are kept within a defined scope, such as a class, method, or block. The closest equivalent is a `public static` field inside a class, which can be accessed from different parts of the program.
