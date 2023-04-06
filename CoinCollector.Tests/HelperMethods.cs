using NUnit.Framework;
using Altom.AltDriver;

public class HelperMethods: BaseTest
{
    public HelperMethods(AltDriver driver)
    {
    }
    public AltObject TimeValueText { get => BaseTest.altDriver.WaitForObject(By.NAME, "TimeValueText"); }
    public static void AssertCoinIsCollected()
    {
        var coinValue = BaseTest.altDriver.FindObject(By.PATH,"//GameController/GameView/Coin/CoinValueText");
        Assert.AreEqual("1", coinValue.GetText());
    }

    public int GetCurrentTime() 
    {
        return TimeValueText.GetComponentProperty<int>("UnityEngine.UI.Text", "text", "UnityEngine.UI");
    }
}