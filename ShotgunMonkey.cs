using MelonLoader;
using BTD_Mod_Helper;
using ShotgunMonkey;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using static ShotgunMonkey.ShotgunMonkeyMod.TowerDisplays;

[assembly: MelonInfo(typeof(ShotgunMonkey.ShotgunMonkeyMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace ShotgunMonkey;
public class ShotgunMonkeyMod : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<ShotgunMonkeyMod>("ShotgunMonkey loaded!");
    }

    public class ShotgunMonkey : ModTower
    {
        public override string Name => "Shotgun Monkey";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 450; //400+250-
        public override string Description => "Shotgun Monkey.";
        public override string DisplayName => "Shotgun Monkey";
        public override int TopPathUpgrades => 1;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        //public override ParagonMode ParagonMode => ParagonMode.Base555;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<TowerDisplays.BaseFarmerDisplay>();
            towerModel.GetBehavior<DisplayModel>().display = towerModel.display;

            towerModel.range = 15;

            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 15;
            
            attackModel.weapons[0] = Game.instance.model.GetTowerFromId("Druid-010").GetAttackModel().weapons[0].Duplicate();
            //attackModel.AddWeapon(Game.instance.model.GetTowerFromId("Sauda").GetAttackModel().weapons[0].Duplicate());
            towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 8, 0, 45, null, false);
            ///
            "emission": {
            "angle": 35.0,
            "count": 8,
            "startOffset": 0.0,
            "useSpeedMultiplier": false,
            "speedMultiplierMin": 0.0,
            "speedMultiplierMax": 0.0,
            "ejectPointRandomness": 0.0,
            "useMainAttackRotation": false,
            "behaviors": null,
            "name": "RandomEmissionModel_",
            "ImplementationType": "Assets.Scripts.Simulation.Towers.Emissions.RandomEmission, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"
          },
            ///
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();

            var projectile = attackModel.weapons[0].projectile;
            // TODO: Find the shrapnel projectile
            //attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("???").GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.ApplyDisplay<ShrapnelDisplay>();

            //projectileModel1.weapons[1].GetDamageModel().immuneBloonProperties = BloonProperties.Black;



        }

        public override bool IsValidCrosspath(int[] tiers) => ModHelper.HasMod("Ultimate Crosspathing") ? true : base.IsValidCrosspath(tiers);
    }
    public class TowerDisplays
    {
        
        public class ShrapnelDisplay : ModDisplay
        {
            public override string BaseDisplay => "4f037aa86b2789a448901265ade0bff4";
        }
        public class BaseFarmerDisplay : ModDisplay
        {
            public override string BaseDisplay => TowerType.SniperMonkey;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }
    }
namespace ShotgunMonkey.Upgrades
{
    public class FMJ : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    { 
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 360; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeyAce").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Pellets can pop Lead Bloons";
        //public override string DisplayName => "FMJ";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Lead;
        }
    }
    public class FMJ : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    { 
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 360; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeyAce").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Pellets can pop Lead Bloons";
        //public override string DisplayName => "FMJ";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Lead;
        }
    }
}
