using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataController.instance.gameData.BulletDamageUpgrade = 0;
        DataController.instance.gameData.LaserDamageUpgrade = 0;
        DataController.instance.gameData.MissileDamageUpgrade = 0;

    }

    // Update is called once per frame
    void Update()
    {
    }
}
