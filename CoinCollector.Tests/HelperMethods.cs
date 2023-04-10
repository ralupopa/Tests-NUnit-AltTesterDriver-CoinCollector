
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
        Assert.NotNull(TimeValueText);
        var valueTime = GetCurrentTime();
        Console.WriteLine("Get time value Before: " + valueTime);

        int valueToSet = 99;
        TimeValueText.SetComponentProperty("UnityEngine.UI.Text", "text", valueToSet, "UnityEngine.UI");

        valueTime = GetCurrentTime();
        Console.WriteLine("Get time value After: " + valueTime);
    }

    public void SetCoinsNumber(int valueToSet)
    {
        Assert.NotNull(CoinValueText);
        var valueCoins = CoinValueText.GetComponentProperty<int>("UnityEngine.UI.Text", "text", "UnityEngine.UI");
        Console.WriteLine("Get coins value Before: " + valueCoins);

        CoinValueText.SetComponentProperty("UnityEngine.UI.Text", "text", valueToSet, "UnityEngine.UI");

        valueCoins = CoinValueText.GetComponentProperty<int>("UnityEngine.UI.Text", "text", "UnityEngine.UI");
        Console.WriteLine("Get coins value After: " + valueCoins);
        Assert.That(valueCoins, Is.EqualTo(valueToSet));
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