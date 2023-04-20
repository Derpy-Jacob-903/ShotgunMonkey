using MelonLoader;
using BTD_Mod_Helper;
using ShotgunMonkey;

[assembly: MelonInfo(typeof(ShotgunMonkey.ShotgunMonkey), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace ShotgunMonkey;

public class ShotgunMonkey : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<ShotgunMonkey>("ShotgunMonkey loaded!");
    }
}