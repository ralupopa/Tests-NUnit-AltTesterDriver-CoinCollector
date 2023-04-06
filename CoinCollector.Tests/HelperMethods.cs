
public class HelperMethods: BaseTest
{
    public HelperMethods(AltDriver driver)
    {
    }
    public AltObject TimeValueText { get => BaseTest.altDriver.WaitForObject(By.NAME, "TimeValueText"); }
    public AltObject CoinValueText { get => BaseTest.altDriver.WaitForObject(By.NAME,"CoinValueText"); }
    public void AssertCoinIsCollected()
    {
        Assert.AreEqual("1", CoinValueText.GetText());
    }

    public int GetCurrentTime() 
    {
        return TimeValueText.GetComponentProperty<int>("UnityEngine.UI.Text", "text", "UnityEngine.UI");
    }
}