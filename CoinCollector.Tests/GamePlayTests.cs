using NUnit.Framework;
using Altom.AltDriver;

namespace CoinCollector.Tests;
public class GamePlayTests: BaseTest
{
  HelperMethods helperMethods;

  [OneTimeSetUp]
  public void SetUp()
  {
    altDriver = new AltDriver();
    helperMethods = new HelperMethods(altDriver);
  }

  [OneTimeTearDown]
  public void TearDown()
  {
    altDriver.Stop();
  }

  [Test]
  public void TestStartGame()
  {
    altDriver.LoadScene("GameScene");

    Thread.Sleep(1000);

    // jump to collect the coin using scroll
    altDriver.Scroll(2000, 0.1f, true);

    // verify that the coin was collected
    Thread.Sleep(500);
    HelperMethods.AssertCoinIsCollected();
    
    var timeValue = helperMethods.GetCurrentTime();
    Console.WriteLine("Value of time in seconds: " + timeValue);
  }
}