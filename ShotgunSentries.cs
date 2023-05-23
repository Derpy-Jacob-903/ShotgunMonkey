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
public class ShotgunSentry : ModTower
{
	//public override string Name => "Shotgun Monkey";
	public override TowerSet TowerSet => TowerSet.Support;
	public override string BaseTower => TowerType.Sentry;
	public override int Cost => 0; //400+250-
	public override string Description => "Shotgun Monkey.";
	public override string DisplayName => "Birdshot Sentry";
	public override int TopPathUpgrades => 0;
	public override int MiddlePathUpgrades => 0;
	public override int BottomPathUpgrades => 0;
	public override string Icon => VanillaSprites.SentryPortrait;
	public override string Portrait => VanillaSprites.SentryPortrait;
	//public override ParagonMode ParagonMode => ParagonMode.Base555;
	public override void ModifyBaseTowerModel(TowerModel towerModel)
	{
		towerModel.range = 40;
		var attackModel = towerModel.GetAttackModel();
		attackModel.range = 40;
		var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
		var projectile = attackModel.weapons[0].projectile;

		attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate();
		attackModel.weapons[0].projectile.pierce = 1;
		towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 16, 60f, 0f, null, false, 1.1f, 0.9f, 1f, false);
		towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;
        projectile.GetBehavior<TravelStraitModel>().Lifespan *= 2;


        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        projectile.GetBehavior<TravelStraitModel>().Lifespan *= 2;
        towerModel.GetWeapon().rate *= 0.95f;
    }

	public override bool IsValidCrosspath(int[] tiers) => ModHelper.HasMod("Ultimate Crosspathing") ? true : base.IsValidCrosspath(tiers);
}
public class BuckshotSentry : ModTower
{
	//public override string Name => "Shotgun Monkey";
	public override TowerSet TowerSet => TowerSet.Support;
	public override string BaseTower => TowerType.SentryCold;
	public override int Cost => 0; //400+250-
	public override string Description => "Shotgun Monkey.";
	public override string DisplayName => "Buckshot Sentry";
	public override int TopPathUpgrades => 0;
	public override int MiddlePathUpgrades => 0;
	public override int BottomPathUpgrades => 0;
	public override string Icon => VanillaSprites.SentryColdPortrait;
	public override string Portrait => VanillaSprites.SentryColdPortrait;
	//public override ParagonMode ParagonMode => ParagonMode.Base555;
	public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.range = 40;
        var attackModel = towerModel.GetAttackModel();
        attackModel.range = 40;
        var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
        var projectile = attackModel.weapons[0].projectile;

        attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate();
        towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 5, 60f, 0f, null, false, 1.1f, 0.9f, 1f, false);
        towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;
        ///
        var oldProjectile = attackModel.weapons[0].projectile.Duplicate();
        //var projectile = attackModel.weapons[0].projectile;
        //var fireProjectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("DartlingGunner-003").GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.weapons[0].projectile.RemoveBehavior<TravelStraightSlowdownModel>();
        attackModel.weapons[0].projectile.AddBehavior(oldProjectile.GetBehavior<TravelStraitModel>());
        attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 2;
        attackModel.weapons[0].projectile.pierce = 2;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 2;
    }
}
public class SlugSentry : ModTower
{
	//public override string Name => "Shotgun Monkey";
	public override TowerSet TowerSet => TowerSet.Support;
	public override string BaseTower => TowerType.SentryCrushing;
	public override int Cost => 0; //400+250-
	public override string Description => "Fires long-range Slugs";
	public override string DisplayName => "Slug Sentry";
	public override int TopPathUpgrades => 0;
	public override int MiddlePathUpgrades => 0;
	public override int BottomPathUpgrades => 0;
	public override string Icon => VanillaSprites.SentryCrushingPortrait;
	public override string Portrait => VanillaSprites.SentryCrushingPortrait;
	//public override ParagonMode ParagonMode => ParagonMode.Base555;
	public override void ModifyBaseTowerModel(TowerModel towerModel)
	{

        towerModel.range = 50;
        var attackModel = towerModel.GetAttackModel();
        attackModel.range = 50;
        var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
        var projectile = attackModel.weapons[0].projectile;

        attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate();
        attackModel.weapons[0].projectile.pierce = 16;
        //towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 16, 60f, 0f, null, false, 1.1f, 0.9f, 1f, false);
        towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;
        projectile.GetBehavior<TravelStraitModel>().Lifespan *= 6;
        projectile.AddBehavior(new DamageModifierForTagModel("CeramicBloonDamageMultiplier", "Ceramic", 0, 4, false, false));
        projectile.ApplyDisplay<SlugDisplay>();
    }
}
public class ExSlugSentry : ModTower
{
	//public override string Name => "Shotgun Monkey";
	public override TowerSet TowerSet => TowerSet.Support;
	public override string BaseTower => TowerType.SentryBoom;
	public override int Cost => 0; //400+250-
	public override string Description => "Fires long-range Slugs";
	public override string DisplayName => "Boom Slug Sentry";
	public override int TopPathUpgrades => 0;
	public override int MiddlePathUpgrades => 0;
	public override int BottomPathUpgrades => 0;
	public override string Icon => VanillaSprites.SentryBoomPortrait;
	public override string Portrait => VanillaSprites.SentryBoomPortrait;
	//public override ParagonMode ParagonMode => ParagonMode.Base555;
	public override void ModifyBaseTowerModel(TowerModel towerModel)
	{

        towerModel.range = 40;
        var attackModel = towerModel.GetAttackModel();
        attackModel.range = 40;
        var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
        var projectile = attackModel.weapons[0].projectile;

        attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate();
        attackModel.weapons[0].projectile.pierce = 1;
        towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 16, 60f, 0f, null, false, 1.1f, 0.9f, 1f, false);
        towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;
        projectile.GetBehavior<TravelStraitModel>().Lifespan *= 2;

    }
}
public class DragonsBreathSentry : ModTower
{
	//public override string Name => "Shotgun Monkey";
	public override TowerSet TowerSet => TowerSet.Support;
	public override string BaseTower => TowerType.SentryEnergy;
	public override int Cost => 0; //400+250-
	public override string Description => "Fires incendiary ammunition, burning Bloons over time.\nCan't pop Purple Bloons";
	public override string DisplayName => "Incendiary Sentry";
	public override int TopPathUpgrades => 0;
	public override int MiddlePathUpgrades => 0;
	public override int BottomPathUpgrades => 0;
	public override string Icon => VanillaSprites.SentryEnergyPortrait;
	public override string Portrait => VanillaSprites.SentryEnergyPortrait;
	//public override ParagonMode ParagonMode => ParagonMode.Base555;
	public override void ModifyBaseTowerModel(TowerModel towerModel)
	{
        towerModel.range = 40;
        var attackModel = towerModel.GetAttackModel();
        attackModel.range = 40;
        var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
        var projectile = attackModel.weapons[0].projectile;

        attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate();
        //attackModel.weapons[0].projectile.pierce = 1;
        towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 11, 60f, 0f, null, false, 1.1f, 0.9f, 1f, false);
        towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;
        ///

        //var attackModel = towerModel.GetAttackModel();
        //towerModel.ApplyDisplay<Display3xx>();
        var oldProjectile = attackModel.weapons[0].projectile.Duplicate();
        //var projectile = attackModel.weapons[0].projectile;
        //var fireProjectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.weapons[0].projectile.RemoveBehavior<TravelStraitModel>();
        attackModel.weapons[0].projectile.AddBehavior(oldProjectile.GetBehavior<TravelStraitModel>());
        //fireProjectile.GetBehavior<AddBehaviorToBloonModel>().isUnique = false;
        //attackModel.weapons[0].projectile.AddBehavior(fireProjectile.GetBehavior<AddBehaviorToBloonModel>());

        attackModel.weapons[0].projectile.pierce = 2;
        attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 1.6f;
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
        attackModel.weapons[0].projectile.ApplyDisplay<FireDisplay>();

    }
}