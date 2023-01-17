//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;

public class KillYoshinoBoss
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new CoreAdvanced();

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        Yoshino();
        Core.SetOptions(false);
    }

    public void Yoshino()
    {
        if (Core.isCompletedBefore(5720))
            return;

        Core.EquipClass(ClassType.Solo);
        Adv.BestGear(GearBoost.dmgAll);
        Core.EnsureAccept(5720);
        Core.KillMonster("yoshino", "r1", "Right", "Xyfrag", "Limited Event Monster Proof");
        Core.EnsureComplete(5720);
        Bot.Wait.ForPickup("Limited Event Coin");

    }
}