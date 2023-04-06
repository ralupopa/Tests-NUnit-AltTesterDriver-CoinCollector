using NUnit.Framework;
using Altom.AltDriver;

public class HelperMethods
{
    public static void AssertCoinIsCollected()
    {
        var coinValue = BaseTest.altDriver.FindObject(By.PATH,"//GameController/GameView/Coin/CoinValueText");
        Assert.AreEqual("1", coinValue.GetText());
    }
}