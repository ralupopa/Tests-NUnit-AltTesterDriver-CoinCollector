namespace CoinCollector.Tests;
public class GamePlayTests: BaseTest
{
  HelperMethods helperMethods;

  [OneTimeSetUp]
  public void SetUp()
  {
    altDriver = new AltDriver();
    helperMethods = new HelperMethods(altDriver);
    helperMethods.LoadScene();
  }

  [OneTimeTearDown]
  public void TearDown()
  {
    altDriver.Stop();
  }

  [Test]
  public void TestGamePlayDisplayedCorrectly()
  {
    Assert.True(helperMethods.IsDisplayed());
  }

  [Test]
  public void TestTimeLeftToPlayIsDisplayed()
  {
    var timeValue = helperMethods.GetCurrentTime();
    Console.WriteLine("Value of time in seconds: " + timeValue);
  }

  [Test]
  public void TestToIncreaseTimeLeftToPlay()
  {
    
    Thread.Sleep(1000);
    altDriver.PressKey(AltKeyCode.Mouse0);
    Thread.Sleep(500);
    helperMethods.AssertCoinIsCollected();

    helperMethods.SetCurrentTime();
  }
}