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

  [Test, Order(1)]
  public void TestGamePlayDisplayedCorrectly()
  {
    Assert.True(helperMethods.IsDisplayed());
  }

  [Test, Order(2)]
  public void TestTimeLeftToPlayIsDisplayed()
  {
    var timeValue = helperMethods.GetCurrentTime();
    Console.WriteLine("Value of time in seconds: " + timeValue);
  }

  [Test, Order(3)]
  public void TestToIncreaseTimeLeftToPlay()
  {
    
    Thread.Sleep(1000);
    altDriver.PressKey(AltKeyCode.Mouse0);
    Thread.Sleep(500);
    helperMethods.AssertCoinIsCollected();

    helperMethods.SetCurrentTime();
  }

  [Test, Order(4)]
  public void TestPlayerChangesPosition()
  {
    var player = helperMethods.Player;
    AltVector3 playerInitialPostion = player.getWorldPosition();

    helperMethods.MovePlayerToPosition(player, helperMethods.SpawnPointSecond);

    // can use UpdateObject() in sdk 1.8.2
    //Assert.AreNotEqual(playerInitialPostion, player.UpdateObject().GetWorldPosition());
    Assert.That(playerInitialPostion, Is.Not.EqualTo(helperMethods.Player.getWorldPosition()));

  }

  [Test, Order(5)]
  public void TestCanSetGameTimeScaleToBeSlow()
  {
    Assert.Multiple(() =>
    {
      helperMethods.ChangeTimeScale(0.1f);
      var timeValue = helperMethods.GetCurrentTime();
      helperMethods.Player.Click();
      Thread.Sleep(2000);
      var timeValueAfter = helperMethods.GetCurrentTime();
      // toDo: fix this
      Assert.That(timeValue, Is.EqualTo(timeValueAfter));
      helperMethods.ChangeTimeScale(1f);
    });
  }

  [Test, Order(6)]
  public void TestToIncreaseCoinsNumber()
  {
    helperMethods.SetCoinsNumber(99);
  }

  [Test, Order(7)]
  public void TestCallComponentTime()
  {
    helperMethods.SetTimeCallComponentMethod();
  }
}