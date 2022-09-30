using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUpgrade : MonoBehaviour
{
    Turret turret;

    public static WeaponUpgrade instance;
    public GameObject BulletUpgradeBtn;
    public GameObject LaserUpgradeBtn;
    public GameObject MissileUpgradeBtn;

    int BulletUpgradeCount = 0;
    int LaserUpgradeCount = 0;
    int MissileUpgradeCount = 0;

    int BulletUpgradePrice = 50;
    int LaserUpgradePrice = 50;
    int MissileUpgradePrice = 50;


    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void LateUpdate()
    {
        BulletUpgradeBtn.GetComponent<TextMeshProUGUI>().text = "BulletUpgrade \nBulletUpgrade Count " + BulletUpgradeCount 
            + "\nPrice " + BulletUpgradePrice;
        LaserUpgradeBtn.GetComponent<TextMeshProUGUI>().text = "LaserUpgrade \nLaserUpgradeCount " + LaserUpgradeCount
            + "\nPrice " + LaserUpgradePrice;
        MissileUpgradeBtn.GetComponent<TextMeshProUGUI>().text = "MissileUpgrade \nMissileUpgradeCount " + MissileUpgradeCount
            + "\nPrice " + MissileUpgradePrice;
    }

    public void OnClickBilletUpgradeButton()
    {
        if(BuildManager.money >= 50 * BulletUpgradeCount)
        {
            BulletUpgradePrice = BulletUpgradePrice + (50 * (BulletUpgradeCount + 1));
            BuildManager.money = BuildManager.money - BulletUpgradePrice;
            BulletUpgradeCount += 1;
            DataController.instance.gameData.BulletDamageUpgrade += 10;
        }
    }
    public void OnClickLaserUpgradeButton()
    {
        if (BuildManager.money >= 50 * LaserUpgradeCount)
        {
            LaserUpgradePrice = LaserUpgradePrice + (50 * (LaserUpgradeCount + 1));
            BuildManager.money = BuildManager.money - LaserUpgradePrice;
            LaserUpgradeCount += 1;
            DataController.instance.gameData.LaserDamageUpgrade += 1;
        }
    }
    public void OnClickMissileUpgradeButton()
    {
        if (BuildManager.money >= 50 * MissileUpgradeCount)
        {
            MissileUpgradePrice = MissileUpgradePrice + (50 * (MissileUpgradeCount + 1));
            BuildManager.money = BuildManager.money - MissileUpgradePrice;
            MissileUpgradeCount += 1;
            DataController.instance.gameData.MissileDamageUpgrade += 20;
        }
    }
}
