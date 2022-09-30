using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    public GameObject turret;

    public static Color buyColor;
    public Color buyHoverColor;
    public GameObject nodes;
    public int level;

    private Renderer rend;
    private Color startColor;

    public bool onClick;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buyColor = Color.yellow;
        level = 0;
    }
    //TODO: 터렛이 설치된 상태일때 UI띄우기
    
    private void OnMouseDown()
    {
        //TODO: UI띄우기
        if (turret != null)
        {
            onClick = true;
            UIManager.instance.activeUI();
            return;
        }
        if (TowerBuyButton.onBuyButton && turret == null)
        {
            GameObject turretToBuild = BuildManager.instance.GetLVOneTurretToBuild();
            switch (turretToBuild.tag)
            {
                case "SpaceShip":
                    positionOffset.y = 3f;
                    break;
                case "Tower":
                    positionOffset.y = 0.5f;
                    break;
                case "Human":
                    positionOffset.y = 0.5f;
                    break;
                default:
                    break;
            }
            turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            level++;
            //터렛 색깔 원래대로 바꾸기
            GameObject[] children = new GameObject[nodes.transform.childCount];
            for (int i = 0; i < nodes.transform.childCount; i++)
            {
                children[i] = nodes.transform.GetChild(i).gameObject;
                Renderer rend = children[i].GetComponent<Renderer>();
                rend.material.color = startColor;
            }
            TowerBuyButton.onBuyButton = false;
        }

    }
    void Update()
    {
        /*if (TowerBuyButton.onBuyButton)
            rend.material.color = buyColor;*/
    }

    private void OnMouseEnter()
    {
        if (TowerBuyButton.onBuyButton)
        {
            if (turret != null)
                return;
            rend.material.color = buyHoverColor;
        }
        else
            rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        if (TowerBuyButton.onBuyButton)
        {
            if (turret != null)
                return;
            rend.material.color = buyColor;
        }
        else
        {
            rend.material.color = startColor;

        }
    }
}
