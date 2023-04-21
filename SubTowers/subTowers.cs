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

namespace ShotgunMonkey.subTowers;
    public class TestSet : ModTowerSet
        {
            public override string DisplayName => "Pokemon";
            public override string Container => "PokemonContainer";
            public override string Button => "PokemonButton";
            public override string ContainerLarge => "PokemonContainer";
            public override string Portrait => "PokemonPortrait";
        }
    public class ShotgunSentry : ModTower
    {
        public override string Name => "Shotgun Monkey";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => ShotgunMonkey;
        public override int Cost => 450; //400+250-
        public override string Description => "Shotgun Monkey.";
        public override string DisplayName => "ShotgunSentry";
        public override int TopPathUpgrades => 3;
        public override int MiddlePathUpgrades => 3;
        public override int BottomPathUpgrades => 3;
        public override string Icon => VanillaSprites.SentryPortrait;
        public override string Portrait => VanillaSprites.SentryPortrait;
        //public override ParagonMode ParagonMode => ParagonMode.Base555;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

            //towerModel.GetBehavior<DisplayModel>().display = towerModel.display;
            //towerModel.ApplyDisplay<TowerDisplays.Display000>();
            //Game.instance.model.GetTower("SniperMonkey").display.GUID

            towerModel.range = 20;

            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 20;
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            var projectile = attackModel.weapons[0].projectile;

            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate(); //Gets the
            towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 8, 60f, 0f, null, false, 1f, 1f, 1f, false);
            towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;
        }

        public override bool IsValidCrosspath(int[] tiers) => ModHelper.HasMod("Ultimate Crosspathing") ? true : base.IsValidCrosspath(tiers);
    }
