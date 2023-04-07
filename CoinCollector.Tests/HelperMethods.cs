
public class HelperMethods: BaseTest
{
    public HelperMethods(AltDriver driver)
    {
    }
    public void LoadScene()
    {
        altDriver.LoadScene("GameScene");
    }
    public AltObject GameView { get => altDriver.WaitForObject(By.NAME, "GameView", timeout: 10); }
    public AltObject TimeValueText { get => altDriver.WaitForObject(By.NAME, "TimeValueText"); }
    public AltObject CoinValueText { get => altDriver.WaitForObject(By.NAME,"CoinValueText"); }
    public AltObject Player { get => altDriver.WaitForObject(By.NAME, "Player"); }
    public AltObject Hill { get => altDriver.WaitForObject(By.NAME, "Hill"); }
    public AltObject CoinSpawner { get => altDriver.WaitForObject(By.NAME, "CoinSpawner"); }
    public AltObject SpawnPoint { get => altDriver.WaitForObject(By.NAME, "SpawnPoint"); }
    public AltObject SpawnPointSecond { get => altDriver.WaitForObject(By.NAME, "SpawnPoint (2)"); }

    public bool IsDisplayed()
    {
        if (GameView != null && TimeValueText != null && CoinValueText != null
        && Player != null && Hill != null && CoinSpawner != null &&  SpawnPoint != null)
            return true;
        return false;
    }
    public void AssertCoinIsCollected()
    {
        Assert.That(CoinValueText.GetText(), Is.EqualTo("1"));
    }

    public int GetCurrentTime() 
    {
        return TimeValueText.GetComponentProperty<int>("UnityEngine.UI.Text", "text", "UnityEngine.UI");
    }

    public void SetCurrentTime()
    {
        if (TimeValueText != null)
        {
            TimeValueText.SetComponentProperty("UnityEngine.UI.Text", "text", 100, "UnityEngine.UI");
            //TimeValueText.SetText("100", true);
            //TimeValueText.SetComponentProperty("UnityEngine.UI.Text", "m_Text", 100, "UnityEngine.UI");

            //altDriver.SetDelayAfterCommand(5);
            //Console.WriteLine(altDriver.GetDelayAfterCommand());
            Console.WriteLine(GetCurrentTime());
        }
        else
        {
            Console.WriteLine("Could not set Time Value Component");
        }
    }

    public void MovePlayerToPosition(AltObject playerPosition, AltObject coinPosition)
    {
        altDriver.KeyDown(AltKeyCode.LeftArrow);
        while(playerPosition.worldX - 3 > coinPosition.worldX) {
            playerPosition = Player;
        }
        altDriver.KeyUp(AltKeyCode.LeftArrow);
    }

    public void ChangeTimeScale(float value)
    {
        altDriver.SetTimeScale(value);
        var timeScaleFromGame = altDriver.GetTimeScale();
        Assert.That(value, Is.EqualTo(timeScaleFromGame));
    }
}