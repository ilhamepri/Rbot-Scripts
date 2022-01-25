//cs_include Scripts/CoreBots.cs
//cs_include Scripts/Story/Originul.cs

using RBot;

public class Fiendshard_Story
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public Originul_Story Originul = new Originul_Story();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        Fiendshard_Questline();

        Core.SetOptions(false);
    }

    public void Fiendshard_Questline()
    {

        // if (Bot.Quests.IsUnlocked(7901)) // Does not work: This will return even if Destroy the Fiend Shard is not done.
        // {
        //     Core.Logger("You have already finished the Fiendshard questline.");
        //     return;
        // }

        if (!Bot.Quests.IsUnlocked(7892))
        {
            Core.Logger("Doing Originul questline to unlock Fiendshard.");
            Originul.Originul_Questline();
        }

        // Sneak Attack
        Core.EnsureAccept(7892);
        Core.Jump("r6", "Left");
        Core.KillQuest(7892, "Fiendshard", "Rogue Fiend");
        // Fiend-terrogation
        Core.KillQuest(7893, "Fiendshard", "Paladin Fiend|Rogue Fiend");
        // Key Difference Between Human and Fiend
        Core.KillQuest(7894, "Fiendshard", "Paladin Fiend|Rogue Fiend");
        // Unlock the Door
        Core.KillQuest(7895, "Fiendshard", new[] { "Rogue Fiend", "Paladin Fiend", "Void Knight" });
        Core.GetMapItem(7984); // %xt%zm%getMapItem%1266931%7984%
        // Dirtlicking Guards
        Core.KillQuest(7896, "Fiendshard", "Paladin Fiend|Void Knight");
        // Defeat Dirtlicker
        Core.KillQuest(7897, "Fiendshard", new[] { "Fiend Shard", "Dirtlicker" });

        // Destroy the Fiend Shard
        // Archfiend DeathLord quests can be done without finishing this quest.
        Core.KillQuest(7898, "Fiendshard", "Nulgath's Fiend Shard", hasFollowup: false);
        Core.EnsureAccept(7898);
        Core.Join("Fiendshard", "r9", "Left");
        while (!Bot.Quests.CanComplete(7898))
        {
            Bot.Player.Kill("Paladin Fiend");
            Bot.Player.Kill("Void Knight");
        }
        Core.EnsureComplete(7898);

        Core.Logger("Questline completed.");
    }

}