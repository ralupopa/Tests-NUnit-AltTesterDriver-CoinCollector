echo "==> Start application"

start "" "AppCoinCollector\CoinCollectorStandalone.exe"

echo "==> Wait for app to start"
sleep 5
cd CoinCollector.Tests

echo "==> Run tests with dotnet CLI and generate output"
dotnet test --results-directory allure-results

echo "==> Generate HTML test report"
allure serve allure-results

echo "==> Kill app"
taskkill //IM "CoinCollectorStandalone.exe" //T //F