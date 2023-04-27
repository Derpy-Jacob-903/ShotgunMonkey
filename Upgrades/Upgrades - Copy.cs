using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2Cpp;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using static ShotgunMonkey.ShotgunMonkeyMod.TowerDisplays;
using UnityEngine.UIElements;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppSystem.Runtime.Remoting.Lifetime;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Harmony;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using ShotgunMonkey.subTowers.EEngineer;
using Il2CppAssets.Scripts.Unity.Display;

namespace ShotgunMonkey.EngineerUpgrades
{
    public class FullMetalJacketEngineer : ModUpgrade<ShotgunEngineer>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 250; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Alchemist").GetUpgrade(MIDDLE, 2).icon;
        public override string Description => "Pellets and Slugs can pop Lead Bloons. Increased Slug Damage.";
        public override string DisplayName => "Full Metal Jacket";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            towerModel.ApplyDisplay<Display1xx>();
        }
    }
    public class MorePelletsEngineer : ModUpgrade<ShotgunEngineer>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 150; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Fires 3 more Pellets. Increased Slugs Pierce";
        public override string DisplayName => "More Pellets";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            var emission = towerModel.GetWeapon().emission;
            if (towerModel.GetUpgradeLevel(MIDDLE) >= 2 & !(towerModel.GetUpgradeLevel(MIDDLE) >= 3))
            {
                emission = new RandomEmissionModel("RandomEmissionModel_", 11, 30f, 0f, null, false, 1f, 1f, 1f, false);
            }
            else if (towerModel.GetUpgradeLevel(MIDDLE) >= 3)
            {

                towerModel.GetWeapon().RemoveBehaviors<EmissionModel>();
            }
            else
            {
                emission = new RandomEmissionModel("RandomEmissionModel_", 11, 50f, 0f, null, false, 1f, 1f, 1f, false);
            }
            //towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Lead;

            towerModel.ApplyDisplay<Display2xx>();
        }
    }
    public class LongBarrelEngineer : ModUpgrade<ShotgunEngineer>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 360; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Longer range. Longer Pellet lifespan.";
        public override string DisplayName => "Long Barrel";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            //towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Lead;
            //towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            towerModel.range += 5;
            attackModel.range += 5;
            projectile.GetBehavior<TravelStraitModel>().Lifespan *= 2;

            towerModel.ApplyDisplay<Displayx1x>();
        }
    }
    public class ChokeEngineer : ModUpgrade<ShotgunEngineer>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 360; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Even longer range. Tighter Pellet spread.";
        public override string DisplayName => "Choke";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            //towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Lead;
            //towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

            towerModel.range += 5;
            attackModel.range += 5;

            var emission = towerModel.GetWeapon().emission;
            if (towerModel.GetUpgradeLevel(TOP) >= 2 & !(towerModel.GetUpgradeLevel(MIDDLE) >= 3))
            {
                emission = new RandomEmissionModel("RandomEmissionModel_", 11, 30f, 0f, null, false, 1f, 1f, 1f, false);
            }
            else if (towerModel.GetUpgradeLevel(MIDDLE) >= 3)
            {

                towerModel.GetWeapon().RemoveBehaviors<EmissionModel>();
            }
            else
            {
                emission = new RandomEmissionModel("RandomEmissionModel_", 8, 30f, 0f, null, false, 1f, 1f, 1f, false);
            }

            towerModel.ApplyDisplay<Displayx2x>();
        }
    }
    public class HairTriggerEngineer : ModUpgrade<ShotgunEngineer>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 0; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(TOP, 1).icon;
        public override string Description => "Fires slightly faster.";
        public override string DisplayName => "Hair Trigger";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            towerModel.GetWeapon().rate *= 0.95f;

            towerModel.ApplyDisplay<Displayxx1>();
        }
    }
    public class RapidFireEngineer : ModUpgrade<ShotgunEngineer>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 300; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(TOP, 2).icon;
        public override string Description => "Fires much faster.";
        public override string DisplayName => "Rapid Fire";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            towerModel.GetWeapon().rate *= 0.75f;

            towerModel.ApplyDisplay<Displayxx2>();
        }
    }
}
namespace ShotgunMonkey.EngineerDisplays
{
    public class D000 : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTower("SniperMonkey", 0, 0, 0).display.GUID;

    }
    public class D1xx : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTower("SniperMonkey", 1, 0, 0).display.GUID;

    }
    public class Display2xx : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTower("SniperMonkey", 1, 2, 0).display.GUID;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
#if DEBUG
            node.PrintInfo();
            node.SaveMeshTexture();
#endif
            //node.RemoveBone("FlatSkin_SniperMonkey_NightVisionGoggles"); 
        }
    }
    public class Displayx1x : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTower("SniperMonkey", 1, 0, 0).display.GUID;

    }
    public class Displayx2x : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTower("SniperMonkey", 0, 1, 0).display.GUID;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
#if DEBUG
            node.PrintInfo();
            node.SaveMeshTexture();
#endif

            //node.RemoveBone("FlatSkin_SniperMonkey_NightVisionGoggles");
        }

    }
    public class Displayxx1 : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTower("SniperMonkey", 0, 0, 1).display.GUID;

    }
    public class Displayxx2 : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTower("SniperMonkey", 0, 0, 2).display.GUID;
    }
    public class Display3xx : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTower("SniperMonkey", 3, 0, 0).display.GUID;

    }
    public class Displayx3x : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTower("SniperMonkey", 0, 3, 0).display.GUID;
    }
    public class Displayxx3 : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTower("SniperMonkey", 0, 0, 3).display.GUID;

    }
}

