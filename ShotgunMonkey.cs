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
        public override TowerSet TowerSet => TowerSet.Military;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 450; //400+250-
        public override string Description => "Shotgun Monkey.";
        public override string DisplayName => "Shotgun Monkey";
        public override int TopPathUpgrades => 3;
        public override int MiddlePathUpgrades => 3;
        public override int BottomPathUpgrades => 3;
        //public override ParagonMode ParagonMode => ParagonMode.Base555;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

            //towerModel.GetBehavior<DisplayModel>().display = towerModel.display;
            towerModel.ApplyDisplay<TowerDisplays.Display000>();

            towerModel.range = 20;

            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 20;
            //attackModel.weapons[0] = Game.instance.model.GetTowerFromId("Druid-010").GetAttackModel().weapons[0].Duplicate();
            //attackModel.AddWeapon(Game.instance.model.GetTowerFromId("Sauda").GetAttackModel().weapons[0].Duplicate());
            var projectileModel = towerModel.GetAttackModel().GetDescendant<ProjectileModel>();
            var projectile = attackModel.weapons[0].projectile;

            attackModel.weapons[0].projectile = Game.instance.model.GetTowerFromId("SniperMonkey-020").GetAttackModel().GetDescendant<ProjectileModel>().GetDescendant<EmitOnDamageModel>().GetDescendant<ProjectileModel>().Duplicate(); //Gets the
            towerModel.GetWeapon().emission = new RandomEmissionModel("RandomEmissionModel_", 8, 60f, 0f, null, false, 1f, 1f, 1f, false);
            towerModel.GetWeapon().rate = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().weapons[0].rate;
            //towerModel.GetWeapon().rate *= 2f;
            //projectile.ApplyDisplay<ShrapnelDisplay>();

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
        public class FireDisplay : ModDisplay
        {
            public override string BaseDisplay => "01dfdf7fe33be28409a9c2e1db9bbec0"; //Assets/Monkeys/WizardMonkey/Graphics/Projectiles/DragonsBreath.prefab
        }
        public class SlugDisplay : ModDisplay
        {
            public override string BaseDisplay => "fcddee8a92f5d2e4d8605a8924566620"; //Assets/Monkeys/DartMonkey/Graphics/Projectiles/SpikeOPultProjectile.prefab
        }
        public class BombDisplay : ModDisplay
        {
            public override string BaseDisplay => "fcddee8a92f5d2e4d8605a8924566620"; //Assets/Monkeys/DartMonkey/Graphics/Projectiles/SpikeOPultProjectile.prefab
        }
        public class BuckDisplay : ModDisplay
        {
            public override string BaseDisplay => "fcddee8a92f5d2e4d8605a8924566620"; //Assets/Monkeys/DartMonkey/Graphics/Projectiles/SpikeOPultProjectile.prefab
        }


        public class Display000 : ModDisplay
        {
            public override string BaseDisplay => Game.instance.model.GetTower("SniperMonkey", 0, 0, 0).display.GUID;

        }
        public class Display1xx : ModDisplay
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
                //node.RemoveBone("SniperMonkey:Dart"); //
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
                //node.RemoveBone("SniperMonkey:Dart"); //
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
}
