## Prerequisite

1. Download and install [.NET SDK](https://dotnet.microsoft.com/en-us/download)
2. Have a game [instrumented with AltTester Unity SDK](https://alttester.com/docs/sdk/pages/get-started.html#instrument-your-game-with-alttester-unity-sdk)
3. Have [AltTester Desktop app](https://alttester.com/alttester/) installed (to be able to inspect game)

# Tests created with NUnit & AltTester-Driver for a game developed w/ Unity (CoinCollector)

This repository is a test project that uses NUnit as the test library. It was generated using following command (as suggested in [documentation](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit#creating-the-test-project))

```
dotnet new nunit
```

[AltTester Unity SDK framework](https://alttester.com/docs/sdk/) contains `AltDriver` class used to connect to the instrumented game developed w/ Unity. AltTester-Driver for C# is available as a nuget package. Install [AltTester-Driver nuget package](https://www.nuget.org/packages/AltTester-Driver#versions-body-tab)

```
dotnet add package AltTester-Driver --version 1.8.0
```

# Run tests manually (with [dotnet CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test))

1. Launch game
2. From `CoinCollector.Tests` execute all tests:

```
dotnet test
```

! **Make sure to have the Alttester Desktop App closed, otherwise the test won't be able to connect to proper port.**

### Run all tests from a specific class / file

```
dotnet test --filter <test_class_name>
```

### Run only one test from a class

```
dotnet test --filter <test_class_name>.<test_name>
```

# Run tests and generate HTML test report

## Using [Allure](https://docs.qameta.io/allure-report/)

Read [Setup Allure](setup_allure.md) as pre-requisite.

### [Automatic script](allure_run_tests_generate_report.sh)

```
allure_run_tests_generate_report.sh
```

### Manual Steps

1. Launch game from `AppCoinCollector\CoinCollectorStandalone.exe`

2. Move to `CoinCollector.Tests`

3. Execute all tests and generate output specific for Allure NUnit adapter

```
dotnet test --results-directory allure-results
```

4. Generate test results report

```
allure serve allure-results
```

### Save Allure report in one HTML file (easy to share)

After generating allure-report, when we need to save everything into one html file (to share it): install an external package which builds allure generated folder into one html file.

Requirements: Python 3.6+

```
pip install allure-combine
```

[allure-combine package implementation and documentation](https://github.com/MihanEntalpo/allure-single-html-file)

Then each time after running test, when want to save allure-report in one sharable HTML file:
```
allure generate -o allure-report
```

```
allure-combine ./allure-report
```