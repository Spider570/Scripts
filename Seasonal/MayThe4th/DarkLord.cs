//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/MayThe4th/MurderMoonStory.cs
//cs_include Scripts/Seasonal/MayThe4th/MurderMoonMerge.cs
using RBot;

public class DarkLord
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreAdvanced Adv = new();
    public MurderMoonMerge Merge = new();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        GetDL();

        Core.SetOptions(false);
    }

    public void GetDL(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Dark Lord"))
        {
            if (rankUpClass)
                Adv.rankUpClass("Dark Lord");
            return;
        }

        Core.AddDrop("Cyber Crystal", "S Ring", "Fifth Lord's Filtrinator", "Dark Helmet", "Dotty");

        //Cyber Crystal x66
        Merge.CyberCrystal(66);

        //S Ring x15
        Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("murdermoon", "Fifth Sepulchure", "S Ring", 15);

        //Fifth Lord's Filtrinator x15
        Core.HuntMonster("murdermoon", "Fifth Sepulchure", "Fifth Lord's Filtrinator", 15);

        //Dark Helmet x1
        Bot.Quests.UpdateQuest(7484);
        Core.HuntMonster("zorbaspalace", "Zorba the Bakk", "Dark Helmet", 1);

        //Dotty x15
        Core.HuntMonster("zorbaspalace", "Zorba the Bakk", "Dotty", 15);

        //Gold Voucher 25k x4
        Core.BuyItem("murdermoon", 1998, "Gold Voucher", 4);

        //Buying the Dark Lord
        Core.BuyItem("murdermoon", 1998, "Dark Lord");
        Bot.Wait.ForItemBuy();

        if (rankUpClass)
            Adv.rankUpClass("Dark Lord");
    }


}
