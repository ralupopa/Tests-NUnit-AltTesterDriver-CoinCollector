
[Allure](https://docs.qameta.io/allure/) framework is a popular multi-language test report tool.

To run commandline application, [*Java Runtime Environment*](https://www.oracle.com/java/technologies/downloads/#jre8-windows) must be installed and JAVA_HOME set as environment variable.

Setup for running Allure with .NET language support can be consulted on [official documentation](https://docs.qameta.io/allure-report/#_nunit_3). For more explicit steps:

# 1. Install [Allure](https://github.com/allure-framework/allure2/releases)

From Assets download archive and extract it.

! After installation, add path to exe in environment variable PATH.

# 2. Install [Allure NUnit](https://www.nuget.org/packages/Allure.NUnit/2.9.5-preview.1) adapter

```
dotnet add package Allure.NUnit --version 2.9.5-preview.1
```

Check that package reference was added in `CoinCollector.Tests.csproj`

# 3. Create folders `allure-results` and `allure-report`

`allure-results` will be the output folder for tests execution; because of Allure.NUnit adapter this output will be in format useful for Allure to interpret and use further when creating the HTML report.

`allure-report` will be the output folder for HTML report served by allure.

# 4. Create `allureConfig.json` at same level with `CoinCollector.Tests.dll`

E.g.: `CoinCollector.Tests.dll` is found in `/bin/Debug/net7.0`

Create `allureConfig.json` file with content as exemplified in [allure-csharp repository](https://github.com/allure-framework/allure-csharp/blob/main/Allure.NUnit/allureConfig.json)

Important to provide a FULL path to the `allure-results` folder. On windows use the double "\\".

eg: 
```
D:\\projects\\alttester\\Tests-NUnit-AltTesterDriver-CoinCollector\\CoinCollector.Tests\\allure-results
```

# 5. In a test class add Allure import and related attributes
- import Allure NUnit adapter (eg: `using NUnit.Allure.Core`)
- Set `[TestFixture]` above test class declaration
- Set `[AllureNUnit]` attribute under [TestFixture]

See [more examples](https://github.com/allure-framework/allure-csharp/tree/main/Allure.NUnit.Examples) for other attributes

# 6. Execute tests and generate output folder `allure-results`

```
dotnet test --results-directory allure-results
```

# 7. Generate test results report

```
allure serve allure-results
```
