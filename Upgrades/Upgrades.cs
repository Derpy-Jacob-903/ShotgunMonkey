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
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Fires 3 more Pellets. Increased Slugs Pierce";
        //public override string DisplayName => "FMJ";
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
    public class LongBarrel : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 360; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(BOTTOM, 1).icon;
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
    public class HairTrigger : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 0; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(TOP, 1).icon;
        public override string Description => "Fires slightly faster.";
        //public override string DisplayName => "FMJ";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            towerModel.GetWeapon().rate *= 0.95f;

            towerModel.ApplyDisplay<Displayxx1>();
        }
    }
    public class RapidFire : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 300; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(TOP, 2).icon;
        public override string Description => "Fires much faster.";
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
        public override int Priority => 1;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Fires high-Pierce Slugs. Extra damage to Ceramic Bloons.";
        //public override string DisplayName => "Sleight of Hand";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;

            if (towerModel.GetUpgradeLevel(TOP) >= 1)
            {
                towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 2;
            }
            else
            {
                towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 1;
            }
            if (towerModel.GetUpgradeLevel(TOP) >= 2)
            {
                projectile.pierce = 11;
            }
            else
            {
                projectile.pierce = 8;
            }
            var emission = towerModel.GetWeapon().emission;
            towerModel.GetWeapon().RemoveBehaviors<EmissionModel>();

            towerModel.range += 10;
            attackModel.range += 10;
            projectile.AddBehavior(new DamageModifierForTagModel("CeramicBloonDamageMultiplier", "Ceramic", 0, 4, false, false));
            towerModel.ApplyDisplay<Displayxx3>();
            projectile.ApplyDisplay<SlugDisplay>();
        }
    }
    public class ExplosiveRounds : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 3000; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override int Priority => 1;
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Fires explosive rounds. Extra damage to MOAB-class Bloons.";
        //public override string DisplayName => "Sleight of Hand";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
<<<<<<< Updated upstream
            //towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-200").GetAttackModel("AcidicMixture").Duplicate());
            //var DoubleBarrelBuff = new AddBerserkerBrewToProjectileModel("DoubleBarrelBuff", "DoubleBarrelBuff",)
            //var A = towerModel.GetAttackModel("AcidicMixture");
            towerModel.GetWeapon().rate *= 0.5f;
            //.7
=======
            projectile.pierce = 1;
>>>>>>> Stashed changes

            //var emission = towerModel.GetWeapon().emission;
            //towerModel.GetWeapon().RemoveBehaviors<EmissionModel>();

            //towerModel.range += 10;
            //attackModel.range += 10;

            attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            var fireProjectile = Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.AddBehavior(fireProjectile.GetBehavior<CreateProjectileOnContactModel>());
            projectile.AddBehavior(fireProjectile.GetBehavior<CreateEffectOnContactModel>());
            projectile.AddBehavior(new DamageModifierForTagModel("MoabBloonDamageMultiplier", "Moab", 3, 0, false, false));
            if (towerModel.GetUpgradeLevel(TOP) >= 1)
            {
                attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage += 1;
            }
            if (towerModel.GetUpgradeLevel(TOP) >= 2)
            {
                attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce += 11;
            }
            towerModel.ApplyDisplay<Displayxx3>();
            projectile.ApplyDisplay<BombDisplay>();
        }
    }
    /// <summary>
    ///public class ThermiteRounds : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    ///{
    ///public override int Path => TOP;
    ///public override int Tier => 4;
    ///public override int Cost => 3000; //140+220
    //public override string Portrait => "BlitzaPortrait";
    ///public override int Priority => 1;
    ///public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(BOTTOM, 1).icon;
    ///public override string Description => "Fires explosive rounds.";
    //public override string DisplayName => "Sleight of Hand";

    ///public override void ApplyUpgrade(TowerModel towerModel)
    ///{
    ///var attackModel = towerModel.GetAttackModel();
    ///var projectile = attackModel.weapons[0].projectile;
    //projectile.pierce = 3;

    //var emission = towerModel.GetWeapon().emission;
    //towerModel.GetWeapon().RemoveBehaviors<EmissionModel>();

    //towerModel.range += 10;
    //attackModel.range += 10;

    //attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
    //projectile.AddBehavior(new DamageModifierForTagModel("MoabBloonDamageMultiplier", "Moab", 3, 3, false, false));
    //var fireProjectile = Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.Duplicate();
    //projectile.AddBehavior(fireProjectile.GetBehavior<CreateProjectileOnContactModel>());
    //projectile.AddBehavior(fireProjectile.GetBehavior<CreateEffectOnContactModel>());
    //attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile = Game.instance.model.GetTowerFromId("WizardMonkey-020").GetAttackModel("Wall of Fire").weapons[0].projectile.Duplicate();
    ///attackModel.AddWeapon(Game.instance.model.GetTowerFromId("WizardMonkey-020").GetAttackModel("Wall of Fire").weapons[0].Duplicate());
    //attackModel.weapons[1].RemoveBehaviors<TargetTrackOrDefaultModel>();
    //attackModel.weapons[1].AddBehavior(attackModel.weapons[0].GetBehavior<TargetTrackOrDefaultModel>());

    ///towerModel.ApplyDisplay<Displayxx3>();
    ///projectile.ApplyDisplay<BombDisplay>();
    ///}
    ///}
    /// </summary>
    public class Buckshotgun : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 360; //140+220
        //public override string Portrait => "BlitzaPortrait";
        public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(BOTTOM, 1).icon;
        public override string Description => "Even longer range. Tighter Pellet spread.";
        public override string DisplayName => "Buckshot";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var oldProjectile = attackModel.weapons[0].projectile;
            //towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Lead;
            //towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;


            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("DartlingGunner-003").GetAttackModel().weapons[0].projectile.Duplicate();
            attackModel.weapons[0].projectile.RemoveBehavior<TravelStraitModel>();
            attackModel.weapons[0].projectile.AddBehavior(oldProjectile.GetBehavior<TravelStraitModel>());
            attackModel.weapons[0].projectile.pierce = 3;

            var emission = towerModel.GetWeapon().emission;
            if (towerModel.GetUpgradeLevel(TOP) >= 2 & (towerModel.GetUpgradeLevel(MIDDLE) >= 2)) //
            {
                emission = new RandomEmissionModel("RandomEmissionModel_", 8, 30f, 0f, null, false, 1f, 1f, 1f, false);
            }
            else if (towerModel.GetUpgradeLevel(TOP) >= 2 & !(towerModel.GetUpgradeLevel(MIDDLE) >= 2)) //
            {

                emission = new RandomEmissionModel("RandomEmissionModel_", 8, 50f, 0f, null, false, 1f, 1f, 1f, false);
            }
            else if (!(towerModel.GetUpgradeLevel(TOP) >= 2 & (towerModel.GetUpgradeLevel(MIDDLE) >= 2))) //
            {

                emission = new RandomEmissionModel("RandomEmissionModel_", 5, 30f, 0f, null, false, 1f, 1f, 1f, false);
            }
            else
            {
                emission = new RandomEmissionModel("RandomEmissionModel_", 5, 50f, 0f, null, false, 1f, 1f, 1f, false);
            }

            towerModel.ApplyDisplay<Displayx2x>();
        }
    }
<<<<<<< Updated upstream
}
=======
    public class DoubleBarrelShotgun : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
        {
            public override int Path => BOTTOM;
            public override int Tier => 3;
            public override int Cost => 850; //140+220
                                             //public override string Portrait => "BlitzaPortrait";
            public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeySub").GetUpgrade(BOTTOM, 1).icon;
            public override string Description => "Double barrels provide rapid."; //R9-0 MW 2019
                                                                                                //public override string DisplayName => "Sleight of Hand";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();

                towerModel.ApplyDisplay<Displayxx3>();
                var projectile = attackModel.weapons[0].projectile;
                //towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-200").GetAttackModel("AcidicMixture").Duplicate());
                //var DoubleBarrelBuff = new AddBerserkerBrewToProjectileModel("DoubleBarrelBuff", "DoubleBarrelBuff",)
                //var A = towerModel.GetAttackModel("AcidicMixture");

                var rate = towerModel.GetWeapon().rate;
                var rateDown = towerModel.GetWeapon().rate;
                rate *= 60;
                rateDown *= -0.8f;
                towerModel.GetWeapon().rate *= 0.2f;
                towerModel.AddBehavior(new DamageBasedAttackSpeedModel("DamageBasedAttackSpeedModel_", 1.0f, (int)Il2CppSystem.Math.Round(rate*0.95), rateDown / 24, 24));
                //towerModel.GetBehavior<DamageBasedAttackSpeedModel>().ApplyBuffIcon = ;
                //
                //"damageThreshold": 1.0,
                //"increasePerThreshold": rateDown,
                //"maxStacks": 1,
                //"maxTimeInFramesWithoutDamage": 199,
                //"name": "DamageBasedAttackSpeedModel_",
                //towerModel.GetWeapon().rate *= 0.5f;
                //.7

            }
        }
        public class FullAutoShotgun : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
        {
            public override int Path => BOTTOM;
            public override int Tier => 4;
            public override int Cost => 8500; //140+220
                                             //public override string Portrait => "BlitzaPortrait";
            public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("TackShooter").GetUpgrade(TOP, 2).icon;
            public override string Description => "Fully automatic shotgun fires very fast."; //R9-0 MW 2019
                                                                                              //public override string DisplayName => "Sleight of Hand";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();

                towerModel.ApplyDisplay<Displayxx3>();
                var projectile = attackModel.weapons[0].projectile;
                //towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-200").GetAttackModel("AcidicMixture").Duplicate());
                //var DoubleBarrelBuff = new AddBerserkerBrewToProjectileModel("DoubleBarrelBuff", "DoubleBarrelBuff",)
                //var A = towerModel.GetAttackModel("AcidicMixture");

                //var rate = towerModel.GetWeapon().rate;
                //var rateDown = towerModel.GetWeapon().rate;
                //rate *= 60;
                //rateDown *= -0.6f;
                //towerModel.GetWeapon().rate *= 0.4f;
                towerModel.RemoveBehavior(towerModel.GetBehavior<DamageBasedAttackSpeedModel>());
                //towerModel.GetBehavior<DamageBasedAttackSpeedModel>().ApplyBuffIcon = ;
                //
                //"damageThreshold": 1.0,
                //"increasePerThreshold": rateDown,
                //"maxStacks": 1,
                //"maxTimeInFramesWithoutDamage": 199,
                //"name": "DamageBasedAttackSpeedModel_",
                //towerModel.GetWeapon().rate *= 0.5f;
                //.7

            }
        }
        public class DrumMagazine : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
        {
            public override int Path => BOTTOM;
            public override int Tier => 5;
            public override int Cost => 21500; //140+220
                                             //public override string Portrait => "BlitzaPortrait";
            public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeyBuccaneer").GetUpgrade(TOP, 2).icon;
            public override string Description => "Drum magazines fires very fast."; //R9-0 MW 2019
                                                                                              //public override string DisplayName => "Sleight of Hand";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();

                towerModel.ApplyDisplay<Displayxx3>();
                var projectile = attackModel.weapons[0].projectile;


                towerModel.GetWeapon().rate *= 0.5f;
                //var attackModel = towerModel.GetAttackModel();
                towerModel.ApplyDisplay<Display3xx>();
                var fireAttackModel = Game.instance.model.GetTowerFromId("DartlingGunner").GetAttackModel().Duplicate();
                var fireTowerModel = Game.instance.model.GetTowerFromId("DartlingGunner");
                //fireAttackModel.GetBehavior<AddBehaviorToBloonModel>().isUnique = false;

                attackModel.AddBehavior(fireAttackModel.GetBehavior<TargetPointerModel>());
                attackModel.AddBehavior(fireAttackModel.GetBehavior<RotateToPointerModel>());
                attackModel.AddBehavior(fireAttackModel.GetBehavior<TargetSelectedPointModel>());
                towerModel.towerSelectionMenuThemeId = "ActionButton";
                //towerModel.towerSelectionMenuThemeId = "SuperMonkey";

                towerModel.targetTypes = towerModel.TargetTypes.AddTo(fireTowerModel.targetTypes.Duplicate());
                towerModel.TargetTypes = towerModel.TargetTypes.AddTo(fireTowerModel.TargetTypes.Duplicate());
                towerModel.targetTypes[0].intID = -2;
                towerModel.TargetTypes[0].intID = -2;

                //attackModel.weapons[0].projectile.AddBehavior(fireProjectile.GetBehavior<AddBehaviorToBloonModel>());
                //projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;

            }
        }
        public class DragonsBreath : ModUpgrade<ShotgunMonkeyMod.ShotgunMonkey>
        {
            public override int Path => TOP;
            public override int Tier => 4;
            public override int Cost => 3280; //140+220
                                              //public override string Portrait => "BlitzaPortrait";
            public override int Priority => -1;
            public override SpriteReference IconReference => Game.instance.model.GetTowerFromId("MonkeyAce").GetUpgrade(BOTTOM, 1).icon;
            public override string Description => "Fires incendiary ammunition, burning Bloons over time. Can't pop Purple Bloons";
            public override string DisplayName => "Dragon's Breath"; //SPAS-12 Black Ops 1

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                towerModel.ApplyDisplay<Display3xx>();
                var oldProjectile = attackModel.weapons[0].projectile;
                //var projectile = attackModel.weapons[0].projectile;
                //var fireProjectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate();
                attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate();
                attackModel.weapons[0].projectile.RemoveBehavior<TravelStraitModel>();
                attackModel.weapons[0].projectile.AddBehavior(oldProjectile.GetBehavior<TravelStraitModel>());
                //fireProjectile.GetBehavior<AddBehaviorToBloonModel>().isUnique = false;
                //attackModel.weapons[0].projectile.AddBehavior(fireProjectile.GetBehavior<AddBehaviorToBloonModel>());


                attackModel.weapons[0].projectile.pierce = 3;
                attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 0.8f;
                attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
                attackModel.weapons[0].projectile.ApplyDisplay<FireDisplay>();
            }
        }
    }

>>>>>>> Stashed changes
