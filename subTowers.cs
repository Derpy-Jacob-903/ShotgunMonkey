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
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using UnityEngine.UIElements;
using BTD_Mod_Helper.Api.Enums;
using static ShotgunMonkey.ShotgunMonkeyMod.TowerDisplays;
using Il2Cpp;

namespace ShotgunMonkey.subTowers;
    public class TestSet : ModTowerSet
        {
            public override string DisplayName => "Test";
            public override string Container => "PokemonContainer";
            public override string Button => "PokemonButton";
            public override string ContainerLarge => "PokemonContainer";
            public override string Portrait => "PokemonPortrait";
        }
    public class ShotgunSentry : ModTower
    {
        //public override string Name => "Shotgun Monkey";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 450; //400+250-
        public override string Description => "Shotgun Monkey.";
        public override string DisplayName => "Shotgun Sentry";
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Icon => VanillaSprites.SentryPortrait;
        public override string Portrait => VanillaSprites.SentryPortrait;
        //public override ParagonMode ParagonMode => ParagonMode.Base555;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

            //towerModel.GetBehavior<DisplayModel>().display = towerModel.display;
            //towerModel.ApplyDisplay<TowerDisplays.Display000>();
            //Game.instance.model.GetTower("Sentry").display.GUID

            towerModel.range = 20;

            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 20;
            

            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate(); //Gets the
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            var projectile = attackModel.weapons[0].projectile;
            towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 8, 60f, 0f, null, false, 1f, 1f, 1f, false);
            towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;
        }

        public override bool IsValidCrosspath(int[] tiers) => ModHelper.HasMod("Ultimate Crosspathing") ? true : base.IsValidCrosspath(tiers);
    }
    public class BuckshotSentry : ModTower
    {
        //public override string Name => "Shotgun Monkey";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 450; //400+250-
        public override string Description => "Shotgun Monkey.";
        public override string DisplayName => "Buckshot Sentry";
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Icon => VanillaSprites.SentryPortrait;
        public override string Portrait => VanillaSprites.SentryPortrait;
        //public override ParagonMode ParagonMode => ParagonMode.Base555;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

            //towerModel.GetBehavior<DisplayModel>().display = towerModel.display;
            //towerModel.ApplyDisplay<TowerDisplays.Display000>();
            //Game.instance.model.GetTower("Sentry").display.GUID

            towerModel.range = 20;

            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 20;

            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate(); //Gets the
            towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 5, 60f, 0f, null, false, 1f, 1f, 1f, false); //-3
            towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;

            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce += 1;
            var fireProjectile = Game.instance.model.GetTowerFromId("DartlingGunner-003").GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.AddBehavior(fireProjectile.GetBehavior<KnockbackModel>());
            //projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
            projectile.ApplyDisplay<BuckDisplay>();
        }
    }
    public class SlugSentry : ModTower
    {
        //public override string Name => "Shotgun Monkey";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 450; //400+250-
        public override string Description => "Fires long-range Slugs";
        public override string DisplayName => "Slug Sentry";
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Icon => VanillaSprites.SentryPortrait;
        public override string Portrait => VanillaSprites.SentryPortrait;
        //public override ParagonMode ParagonMode => ParagonMode.Base555;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

            //towerModel.GetBehavior<DisplayModel>().display = towerModel.display;
            //towerModel.ApplyDisplay<TowerDisplays.Display000>();
            //Game.instance.model.GetTower("Sentry").display.GUID
            towerModel.range = 20;

            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 20;

            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate(); //Gets the
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce = 8;
            //towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 8, 60f, 0f, null, false, 1f, 1f, 1f, false);
            towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;
            projectile.GetBehavior<TravelStraitModel>().Lifespan *= 3;
            projectile.ApplyDisplay<SlugDisplay>();
            
        }
    }
    public class ExSlugSentry : ModTower
    {
        //public override string Name => "Shotgun Monkey";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 450; //400+250-
        public override string Description => "Fires long-range Slugs";
        public override string DisplayName => "Ex. Slug Sentry";
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Icon => VanillaSprites.SentryPortrait;
        public override string Portrait => VanillaSprites.SentryPortrait;
        //public override ParagonMode ParagonMode => ParagonMode.Base555;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

            //towerModel.GetBehavior<DisplayModel>().display = towerModel.display;
            //towerModel.ApplyDisplay<TowerDisplays.Display000>();
            //Game.instance.model.GetTower("Sentry").display.GUID
            towerModel.range = 20;

            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 20;

            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate(); //Gets the
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            var projectile = attackModel.weapons[0].projectile; 
            projectile.pierce = 1;
            projectile.maxPierce = 1;
            //towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 8, 60f, 0f, null, false, 1f, 1f, 1f, false);
            towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;
            projectile.GetBehavior<TravelStraitModel>().Lifespan *= 3;
            projectile.pierce = 3;

        //var emission = towerModel.GetWeapon().emission;
        //towerModel.GetWeapon().RemoveBehaviors<EmissionModel>();

        //towerModel.range += 10;
        //attackModel.range += 10;

            attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectile.AddBehavior(new DamageModifierForTagModel("MoabBloonDamageMultiplier", "Moab", 1, 10, false, false));
            var fireProjectile = Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.AddBehavior(fireProjectile.GetBehavior<CreateProjectileOnContactModel>());
            projectile.AddBehavior(fireProjectile.GetBehavior<CreateEffectOnContactModel>());
            //projectile.GetBehavior<CreateProjectileOnContactModel>().projectile = ;
            towerModel.ApplyDisplay<Displayxx3>();
            projectile.ApplyDisplay<BombDisplay>();

        }
    }
    public class DragonsBreathSentry : ModTower
    {
        //public override string Name => "Shotgun Monkey";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 450; //400+250-
        public override string Description => "Fires incendiary ammunition, burning Bloons over time.\nCan't pop Purple Bloons";
        public override string DisplayName => "Incendiary Shotgun Sentry";
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Icon => VanillaSprites.SentryPortrait;
        public override string Portrait => VanillaSprites.SentryPortrait;
        //public override ParagonMode ParagonMode => ParagonMode.Base555;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

            //towerModel.GetBehavior<DisplayModel>().display = towerModel.display;
            //towerModel.ApplyDisplay<TowerDisplays.Display000>();
            //Game.instance.model.GetTower("Sentry").display.GUID
            towerModel.range = 20;

            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 20;

            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate(); //Gets the
            //projectile.pierce = 8;
            towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 8, 60f, 0f, null, false, 1f, 1f, 1f, false);
            towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;


            var projectile = attackModel.weapons[0].projectile;
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();

            var fireProjectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate();
            projectile.AddBehavior(fireProjectile.GetBehavior<AddBehaviorToBloonModel>());
            projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
            projectile.ApplyDisplay<FireDisplay>();
            
        }
    }
}
