
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

    public bool IsDisplayed()
    {
        if (GameView != null && TimeValueText != null && CoinValueText != null
        && Player != null && Hill != null && CoinSpawner != null &&  SpawnPoint != null)
            return true;
        return false;
    }
    public void AssertCoinIsCollected()
    {
        Assert.AreEqual("1", CoinValueText.GetText());
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
            Console.WriteLine(GetCurrentTime());
        }
        else
        {
            Console.WriteLine("Could not set Time Value Component");
        }
    }
}