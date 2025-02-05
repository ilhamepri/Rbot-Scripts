//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
using RBot;

public class ImperialChunin
{
    public ScriptInterface Bot => ScriptInterface.Instance;

    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        GetIC();

        Core.SetOptions(false);
    }

    public void GetIC(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Imperial Chunin"))
            return;

        Farm.YokaiREP();

        Core.BuyItem("dragonkoiz", 95, "Imperial Chunin");

        if (rankUpClass)
            Farm.rankUpClass("Imperial Chunin");
    }
}