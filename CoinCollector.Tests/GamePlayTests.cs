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
    altDriver.Scroll(2000, 0.1f, true);

    Thread.Sleep(500);
    helperMethods.AssertCoinIsCollected();

    var timeValue = helperMethods.GetCurrentTime();
    Console.WriteLine("Value of time in seconds: " + timeValue);
  }

  [Test]
  public void TestGeneratedWithRecorder()
  {
    altDriver.LoadScene("GameScene");

    Thread.Sleep(1000);
    altDriver.PressKey(AltKeyCode.Mouse0);
    Thread.Sleep(500);
    helperMethods.AssertCoinIsCollected();
    // altDriver.KeyDown(AltKeyCode.Mouse0,1);
    // altDriver.MoveMouse(new AltVector2(968.0593f,227.4916f),0.01f);
    // altDriver.KeyUp(AltKeyCode.Mouse0);
    // altDriver.KeyDown(AltKeyCode.Mouse0,1);
    // altDriver.KeyUp(AltKeyCode.Mouse0);
    // altDriver.MoveMouse(new AltVector2(1102.335f,235.5524f),0.01f);
    // altDriver.KeyUp(AltKeyCode.RightArrow);
    // altDriver.KeyDown(AltKeyCode.UpArrow,1);
    // altDriver.KeyUp(AltKeyCode.UpArrow);
    // altDriver.KeyDown(AltKeyCode.Mouse0,1);
    // altDriver.KeyUp(AltKeyCode.Mouse0);
    // altDriver.KeyDown(AltKeyCode.RightArrow,1);
    // altDriver.KeyDown(AltKeyCode.Mouse0,1);
    // altDriver.KeyUp(AltKeyCode.Mouse0);
  }
}