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

namespace ShotgunMonkey.Upgrades
{
    public class FullMetalJacket : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 250; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("Alchemist").GetUpgrade(MIDDLE, 2).icon;
        public override string Description => "Pellets and Slugs can pop Lead Bloons. Increased Slug Damage.";
        //public override string DisplayName => "FMJ";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            towerModel.ApplyDisplay<Display1xx>();
        }
    }
    public class MorePellets : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 150; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeyAce").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Fires 3 more Pellets. Increased Slugs Pierce";
        //public override string DisplayName => "FMJ";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            var emission = towerModel.GetWeapon().emission;
            if (towerModel.GetUpgradeLevel(MIDDLE) >= 2)
            {
                emission = new RandomEmissionModel("RandomEmissionModel_", 11, 30f, 0f, null, false, 1f, 1f, 1f, false);
            }
            else
            {
                emission = new RandomEmissionModel("RandomEmissionModel_", 11, 50f, 0f, null, false, 1f, 1f, 1f, false);
            }
            //towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Lead;

            towerModel.ApplyDisplay<Display2xx>();
        }
    }
    public class LongBarrel : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 360; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeyAce").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Longer range. Longer Pellet lifespan.";
        //public override string DisplayName => "FMJ";
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
    public class Choke : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 360; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Even longer range. Tighter Pellet spread.";
        //public override string DisplayName => "FMJ";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            //towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Lead;
            //towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

            towerModel.range += 5;
            attackModel.range += 5;

            var emission = towerModel.GetWeapon().emission;
            if (towerModel.GetUpgradeLevel(TOP) >= 2)
            {
                emission = new RandomEmissionModel("RandomEmissionModel_", 11, 30f, 0f, null, false, 1f, 1f, 1f, false);
            }
            else
            {
                emission = new RandomEmissionModel("RandomEmissionModel_", 8, 30f, 0f, null, false, 1f, 1f, 1f, false);
            }

            towerModel.ApplyDisplay<Displayx2x>();
        }
    }
    public class HairTrigger : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 50; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(TOP, 1).icon;
        public override string Description => "Fires faster";
        //public override string DisplayName => "FMJ";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            towerModel.GetWeapon().rate *= 0.9f;

            towerModel.ApplyDisplay<Displayxx1>();
        }
    }
    public class SleightOfHand : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 300; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(TOP, 2).icon;
        public override string Description => "Fires even faster";
        //public override string DisplayName => "Sleight of Hand";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            towerModel.GetWeapon().rate *= 0.75f;

            towerModel.ApplyDisplay<Displayxx2>();
        }
    }
    public class SlugRounds : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 300; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeyAce").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Fires long-range Slugs";
        //public override string DisplayName => "Sleight of Hand";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            
            if (towerModel.GetUpgradeLevel(TOP) >= 2)
            {
                projectile.pierce = 11;
            }
            else
            {
                projectile.pierce = 8;
            }
            attackModel.weapons[0].RemoveBehavior<EmissionModel>();

            towerModel.range += 10;
            attackModel.range += 10;

            towerModel.ApplyDisplay<Displayxx3>();
            projectile.ApplyDisplay<SlugDisplay>();
        }
    }
    public class DoubleBarrel : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 850; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeyBuccaneer").GetUpgrade(TOP, 2).icon;
        public override string Description => "Double barrels provide a faster fire rate."; //R9-0 MW 2019
        //public override string DisplayName => "Sleight of Hand";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            towerModel.ApplyDisplay<Displayx3x>();
            var projectile = attackModel.weapons[0].projectile;
            //towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-200").GetAttackModel("AcidicMixture").Duplicate());
            //var DoubleBarrelBuff = new AddBerserkerBrewToProjectileModel("DoubleBarrelBuff", "DoubleBarrelBuff",)
            //var A = towerModel.GetAttackModel("AcidicMixture");
            towerModel.GetWeapon().rate *= 0.5f;
            //.7

        }
    }
    public class DragonsBreath : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 3280; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeyAce").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Fires incendiary ammunition, burning Bloons over time.\nCan't pop Purple Bloons";
        public override string DisplayName => "Dragon's Breath"; //SPAS-12 Black Ops 1

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            towerModel.ApplyDisplay<Display3xx>();
            var projectile = attackModel.weapons[0].projectile;
            var fireProjectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.AddBehavior(fireProjectile.GetBehavior<AddBehaviorToBloonModel>());
            projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
            projectile.ApplyDisplay<FireDisplay>();
        }
    }
}