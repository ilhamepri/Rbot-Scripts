//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Story/DarkAlly.cs
using RBot;

public class TheEdgeofanEra
{

    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();
    public CoreLegion Legion = new CoreLegion();
    public DarkAlly_Story DarkAlly = new DarkAlly_Story();

     public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        YokaiSwordScroll();

        Core.SetOptions(false);
    }

    public void YokaiSwordScroll(int quant = 1)
    {
        if (Core.CheckInventory("Yokai Sword Scroll", quant))
            return;
        DarkAlly.DarkAlly_Questline();
        Core.AddDrop("Yami no Ronin Katana", "Yokai Sword Scroll");
        Core.EnsureAccept(7445);
        Core.HuntMonster("shadowfortress", "1st Head of Orochi", "Perfect Orochi Scales", 888, false);
        Core.KillMonster("shadowrealmpast", "Enter", "Spawn", "*", "Darkened Essence", 600, false);
        Core.BuyItem("akiba", 131, "Oni Skull Charm", 1);
        ShadowKatanaBlade(1);
        Core.EnsureComplete(7445);
    }

    public void Yami(int quant = 10)
    {
        if (Core.CheckInventory("yami", quant))
            return;
        Core.AddDrop("yami");
        while (!Core.CheckInventory("yami", quant))
        {
            Core.EnsureAccept(7409);
            Core.KillMonster("darkally","r2","Left","*","Dark Wisp",444,false);
            Core.EnsureComplete(7409);
        }
    }

    public void FoldedSteel(int quant = 1)
    {
        if (Core.CheckInventory("Folded Steel", quant))
            return;
        Core.AddDrop("Folded Steel");
        Core.EnsureAccept(7444);
        Core.HuntMonster("fotia", "Amia the Cult Leader", "Eternity Flame", 1, false);
        Core.HuntMonster("shadowfortress", "Jaaku", "Shadow Katana Blueprint", 1, false);
        Legion.SoulForgeHammer(1);
        if (!Core.CheckInventory("Obsidian Rock", 108))
        {
            Legion.FarmLegionToken(220);
            Core.BuyItem("underworld", 577, "Obsidian Rock", 108);
        }
        FlameForgedMetal(13);
        if (!Core.CheckInventory("Weapon Imprint", 15))
        {
            Core.Logger("Farm Manually Weapon Imprint x15 by killing Undead Raxgore /doomvaultb");
            Core.SetOptions(false);
        }
        else Core.EnsureComplete(7444);
    }

    public void FlameForgedMetal(int quant = 13)
    {
        if (Core.CheckInventory("Flame-Forged Metal", quant))
            return;
        Core.AddDrop("Flame-Forged Metal");
        while (!Core.CheckInventory("Flame-Forged Metal", quant))
        {
            Core.EnsureAccept(6975);
            Core.HuntMonster("Underworld", "Frozen Pyromancer", "Stolen Flame", 1, true);
            Core.EnsureComplete(6975);
        }
    }

    public void ShadowKatanaBlade(int quant = 1)
    {
        if (Core.CheckInventory("Shadow Katana Blade"))
            return;
        Yami(10);
        FoldedSteel(1);
        if (!Core.CheckInventory("Platinum Paragon Medal", 15))
        {
            Farm.Gold(15000000);
            Core.BuyItem("underworld", 238, "Platinum Paragon Medal", 15);
        }
        Farm.YokaiREP(10);
        Core.BuyItem("underworld", 577, "Shadow Katana Blade", 1);
    }

}