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

  [Test]
  public void TestPlayerChangesPosition()
  {
    var player = helperMethods.Player;
    AltVector3 playerInitialPostion = player.getWorldPosition();

    helperMethods.MovePlayerToPosition(player, helperMethods.SpawnPointSecond);

    // can use UpdateObject() in sdk 1.8.2
    //Assert.AreNotEqual(playerInitialPostion, player.UpdateObject().GetWorldPosition());
    Assert.That(playerInitialPostion, Is.Not.EqualTo(helperMethods.Player.getWorldPosition()));

  }

  [Test]
  public void TestCanSetGameTimeScaleToBeSlow()
  {
    helperMethods.ChangeTimeScale(0.1f);
    var timeValue = helperMethods.GetCurrentTime();
    helperMethods.Player.Click();
    Thread.Sleep(3000);
    var timeValueAfter = helperMethods.GetCurrentTime();
    Assert.That(timeValue, Is.EqualTo(timeValueAfter));
  }
}