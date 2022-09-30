using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerBuyButton : MonoBehaviour
{
    public static bool onBuyButton;
    public GameObject Nodes;

    void Start()
    {
        onBuyButton = false;
    }

    void Update()
    {
        //wallet.GetComponent<TextMeshProUGUI>().text = "money : " + money + "$";
    }

    public void OnClickBuyButton()
    {
        if (BuildManager.money >= 50)
        {
            BuildManager.money -= 50;
            onBuyButton = true;
            GameObject[] children = new GameObject[Nodes.transform.childCount];

            for (int i = 0; i < Nodes.transform.childCount; i++)
            {
                children[i] = Nodes.transform.GetChild(i).gameObject;
                if(children[i].GetComponent<Node>().turret == null)
                {
                    Renderer rend = children[i].GetComponent<Renderer>();
                    rend.material.color = Node.buyColor;

                }
            }
        }
    }
}
