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
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppSystem.Threading;
using ShotgunMonkey.subTowers;

namespace ShotgunMonkey.subTowers.EEngineer;
    public class ShotgunEngineer : ModTower
    {
        public override string Name => "Shotgun Engineer";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.EngineerMonkey;
        public override int Cost => 3850; //450+500+400+2500
    public override string Description => "Shotgun Monkey.";
        public override string DisplayName => "Shotgun Engineer";
        public override int TopPathUpgrades => 2;
        public override int MiddlePathUpgrades => 2;
        public override int BottomPathUpgrades => 2;
        //public override ParagonMode ParagonMode => ParagonMode.Base555;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

            //towerModel.GetBehavior<DisplayModel>().display = towerModel.display;
            towerModel.ApplyDisplay<EngineerDisplays.E000>();

            towerModel.range = 40;

            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 40;
            //attackModel.weapons[0] = Game.instance.model.GetTowerFromId("Druid-010").GetAttackModel().weapons[0].Duplicate();
            //attackModel.AddWeapon(Game.instance.model.GetTowerFromId("Sauda").GetAttackModel().weapons[0].Duplicate());
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            var projectile = attackModel.weapons[0].projectile;

            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate(); //Gets the
            if (!(towerModel.GetUpgradeLevel(1) >= 3))
            {
                towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 8, 60f, 0f, null, false, 1f, 1f, 1f, false);
            }
            towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;
            towerModel.AddBehavior<AttackModel>(Game.instance.model.GetTowerFromId("EngineerMonkey-400").GetAttackModel("Spawner").Duplicate());

        //towerModel.GetWeapon().rate *= 2f;
        //projectile.ApplyDisplay<ShrapnelDisplay>();
        //var cock = new CreateTypedTowerModel("CreateTypedTowerModel_", GetTowerModel<subTowers.SlugSentry>(), GetTowerModel<subTowers.ExSlugSentry>(), GetTowerModel<subTowers.ShotgunSentry>(), GetTowerModel<subTowers.DragonsBreathSentry>(), CreatePrefabReference("95f0e98e9602cab4fb4f1dcc6d01653a"), CreatePrefabReference("02712b0bdfcd72b4f8bebf853ab75d70"), CreatePrefabReference("eccb1724c4f6bae4492f34509cdcda66"), CreatePrefabReference("5bb9342d838c0d848ab4ccb4f078114f"));
        //towerModel.GetAttackModel("Spawner").GetDescendant<ProjectileModel>().RemoveBehavior<CreateTypedTowerModel>();
        //towerModel.GetAttackModel("Spawner").GetDescendant<ProjectileModel>().AddBehavior<CreateTypedTowerModel>(new CreateTypedTowerModel("CreateTypedTowerModel_", Game.instance.model.GetTowerFromId("ShotgunMonkey-SlugSentry").Duplicate(), Game.instance.model.GetTowerFromId("ShotgunMonkey-ShotgunSentry").Duplicate(), Game.instance.model.GetTowerFromId("ShotgunMonkey-BuckshotSentry").Duplicate(), Game.instance.model.GetTowerFromId("ShotgunMonkey-DragonsBreathSentry").Duplicate(), CreatePrefabReference("333ed0c466512f94cace6f41b0a91fe9"), CreatePrefabReference("333ed0c466512f94cace6f41b0a91fe9"), CreatePrefabReference("333ed0c466512f94cace6f41b0a91fe9"), CreatePrefabReference("333ed0c466512f94cace6f41b0a91fe9")));
        //projectileModel1.weapons[1].GetDamageModel().immuneBloonProperties = BloonProperties.Black;
        towerModel.GetAttackModel("Spawner").GetDescendant<ProjectileModel>().GetDescendant<CreateTypedTowerModel>().crushingTower = GetTowerModel<subTowers.SlugSentry>().Duplicate();
        towerModel.GetAttackModel("Spawner").GetDescendant<ProjectileModel>().GetDescendant<CreateTypedTowerModel>().boomTower = GetTowerModel<subTowers.ShotgunSentry>().Duplicate();
        towerModel.GetAttackModel("Spawner").GetDescendant<ProjectileModel>().GetDescendant<CreateTypedTowerModel>().coldTower = GetTowerModel<subTowers.BuckshotSentry>().Duplicate();
        towerModel.GetAttackModel("Spawner").GetDescendant<ProjectileModel>().GetDescendant<CreateTypedTowerModel>().energyTower = GetTowerModel<subTowers.DragonsBreathSentry>().Duplicate();
    }

    public override bool IsValidCrosspath(int[] tiers) => ModHelper.HasMod("Ultimate Crosspathing") ? true : base.IsValidCrosspath(tiers);
    }
    public class EngineerDisplays
{
        public class E000 : ModDisplay
        {
            public override string BaseDisplay => Game.instance.model.GetTower("EngineerMonkey", 4, 0, 0).display.GUID;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
#if DEBUG
                node.PrintInfo();
                node.SaveMeshTexture();
#endif
            }

    }
    }
