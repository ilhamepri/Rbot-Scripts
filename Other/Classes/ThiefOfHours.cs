//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
using RBot;

public class ThiefOfHours
{
    public ScriptInterface Bot => ScriptInterface.Instance;

    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        GetToH();

        Core.SetOptions(false);
    }

    public void GetToH(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Thief of Hours"))
            return;

        Farm.ChronoSpanREP();

        Core.BuyItem("thespan", 439, "Thief of Hours");

        if (rankUpClass)
            Farm.rankUpClass("Thief of Hours");
    }
}