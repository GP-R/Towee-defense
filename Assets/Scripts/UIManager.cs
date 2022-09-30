using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private RaycastHit hit;

    public Camera getCamera;
    public GameObject Tower_Info;
    public GameObject nodes;
    private GameObject node;

    GameObject InfoText;
    GameObject AttText;
    GameObject SpeedText;
    GameObject TowerName;

    

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Start()
    {
        getCamera = Camera.main;
    }
    private void Update()
    {
        
    }
    public void hideUI()
    {
        Tower_Info.SetActive(false);
    }
    public void activeUI()
    {
        GameObject[] children = new GameObject[nodes.transform.childCount];
        for (int i = 0; i < nodes.transform.childCount; i++)
        {
            children[i] = nodes.transform.GetChild(i).gameObject;
            if (children[i].GetComponent<Node>().onClick)
            {
                node = children[i];
            }
        }
        if (node.GetComponent<Node>().onClick && node.GetComponent<Node>().turret.name == "Space Ship Lv1(Clone)")
        {
            Tower_Info.SetActive(true);
            TowerName = Tower_Info.transform.Find("TowerName").gameObject;
            TowerName.GetComponent<TextMeshProUGUI>().text = "Space Ship Lv1";
            AttText = Tower_Info.transform.Find("Att").gameObject;
            AttText.GetComponent<TextMeshProUGUI>().text = "Damage : " + 1 + DataController.instance.gameData.LaserDamageUpgrade;
            SpeedText = Tower_Info.transform.Find("Speed").gameObject;
            SpeedText.GetComponent<TextMeshProUGUI>().text = "Attack Speed";
            InfoText = Tower_Info.transform.Find("Info").gameObject;
            InfoText.GetComponent<TextMeshProUGUI>().text = "³»¿ë";
        }
        else Tower_Info.SetActive(false);
    }
}
