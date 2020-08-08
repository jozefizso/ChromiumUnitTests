# Chromium Unit Tests

> Sample projects for running CefSharp Chromium inside unit test projects.

## Getting Started

1. Download the `nunit3-console` from [NUnit Console and Engine 3.11.1](https://github.com/nunit/nunit-console/releases/tag/v3.11.1)
2. Extract it to `C:\tools`
3. Set the `%PATH%` variable to include the `c:\tools\NUnit.Console-3.11.1\bin\net35` directory

### ChromiumTests64 Sample

> Requires Windows 64-bit operating system.

The **ChromiumTests64** project shows how to run CefSharp in unit tests library
on Windows 64-bit.

The solution and project must target the **x64** platform. This is a limitation
of CefSharp that whole solution must use **x64** platform.

The `ChromiumTests64.dll` can be executed in `nunit3-console.exe`.
As the console runs in 64-bit mode, this will ensure the whole process can
load CefSharp correctly.

Use **nunit3-console.exe** to run tests without isolation:

```powershell
$env:Path="c:\tools\NUnit.Console-3.11.1\bin\net35;"+$env:path
cd ChromiumTests64\bin\Debug
nunit3-console.exe --inprocess --domain=None .\ChromiumTests64.dll
```

To run tests using MS Test, use the **vstest.console.exe** application from
_Visual Studio 2019 Developer Prompt_. (Running tests using MS Test is broken for now)

```cmd
vstest.console.exe ChromiumTests64.dll /Settings:DisableAppDomain.runsettings
```

## License

Licensed under [MIT License](LICENSE.txt).

Copyright © 2020 Jozef Izso
