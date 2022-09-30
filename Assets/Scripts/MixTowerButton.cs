using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixTowerButton : MonoBehaviour
{
    public GameObject nodes;
    private GameObject node;
    private Vector3 positionOffset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private Vector3 getPosOffset(string turretTag)
    {
        switch (turretTag)
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
        return positionOffset;
    }

    public void OnClickMixButton()
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

        if (node.GetComponent<Node>().onClick)
        {

            int removeCount = 0;
            GameObject[] mixNode = new GameObject[2];
            for (int i = 0; i < nodes.transform.childCount; i++)
            {
                if (children[i].GetComponent<Node>().turret == null)
                    continue;
                if (node.GetComponent<Node>().turret.name == children[i].GetComponent<Node>().turret.name && node != children[i])
                {
                    mixNode[removeCount] = children[i];
                    removeCount++;
                }
                if (removeCount == 2)
                    break;
            }
            if (removeCount < 2) //자기자신포함 3개 이하일시 조합불가
                return;
            Destroy(node.GetComponent<Node>().turret);
            node.GetComponent<Node>().turret = null;
            for (int i = 0; i < mixNode.Length; i++)
            {
                Destroy(mixNode[i].GetComponent<Node>().turret);
                mixNode[i].GetComponent<Node>().turret = null;
                mixNode[i].GetComponent<Node>().level = 0;
            }
            if (node.GetComponent<Node>().level == 1)
            {
                GameObject turretToBuild = BuildManager.instance.GetLVTwoTurretToBuild();
                Vector3 positionOffset = getPosOffset(turretToBuild.tag);
                node.GetComponent<Node>().turret = Instantiate(turretToBuild, node.transform.position + positionOffset, node.transform.rotation);
                node.GetComponent<Node>().level++;
            }
            else if (node.GetComponent<Node>().level == 2)
            {
                GameObject turretToBuild = BuildManager.instance.GetLVThreeTurretToBuild();
                Vector3 positionOffset = getPosOffset(turretToBuild.tag);
                node.GetComponent<Node>().turret = Instantiate(turretToBuild, node.transform.position + positionOffset, node.transform.rotation);
                node.GetComponent<Node>().level++;
            }
            else if (node.GetComponent<Node>().level == 3)
            {
                GameObject turretToBuild = BuildManager.instance.GetLVFourTurretToBuild();
                Vector3 positionOffset = getPosOffset(turretToBuild.tag);
                node.GetComponent<Node>().turret = Instantiate(turretToBuild, node.transform.position + positionOffset, node.transform.rotation);
                node.GetComponent<Node>().level++;
            }
            node.GetComponent<Node>().onClick = false;
        }
    }

}
