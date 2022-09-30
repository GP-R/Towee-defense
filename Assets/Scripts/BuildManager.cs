using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject wallet;
    public static int money = 0;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    public GameObject[] LVOneTurretPrefab;
    public GameObject[] LVTwoTurretPrefab;
    public GameObject[] LVThreeTurretPrefab;
    public GameObject[] LVFourTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetLVOneTurretToBuild()
    {
        int buildTurret = Random.Range(0, LVOneTurretPrefab.Length);
        turretToBuild = LVOneTurretPrefab[buildTurret];
        return turretToBuild;
    }
    public GameObject GetLVTwoTurretToBuild()
    {
        int buildTurret = Random.Range(0, LVTwoTurretPrefab.Length);
        turretToBuild = LVTwoTurretPrefab[buildTurret];
        return turretToBuild;
    }
    public GameObject GetLVThreeTurretToBuild()
    {
        int buildTurret = Random.Range(0, LVThreeTurretPrefab.Length);
        turretToBuild = LVThreeTurretPrefab[buildTurret];
        return turretToBuild;
    }
    public GameObject GetLVFourTurretToBuild()
    {
        int buildTurret = Random.Range(0, LVFourTurretPrefab.Length);
        turretToBuild = LVFourTurretPrefab[buildTurret];
        return turretToBuild;
    }
    // Start is called before the first frame update
    void Start()
    {
        turretToBuild = LVOneTurretPrefab[0];
        money =10000;
    }


    private void LateUpdate()
    {
        wallet.GetComponent<TextMeshProUGUI>().text = "money : " + money + "$";
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
