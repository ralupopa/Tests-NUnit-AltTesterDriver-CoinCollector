echo "==> Start application"

start "" "AppCoinCollector\CoinCollectorStandalone.exe"
sleep 5

cd CoinCollector.Tests

echo "==> Restore test project and run tests"
dotnet test

echo "==> Kill app"
taskkill //IM "CoinCollectorStandalone.exe" //T //F

sleep 10