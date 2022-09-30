using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : TowerManager
{
    public Transform target;

    public float range;
    public float fireRate;
    public int Damage;
    private float fireCountdown;

    public string enemyTag;
    public Transform PartToRotage;
    public float turnSpeed;

    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    public virtual void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; //Mathf.Infinity : ���� ���Ѵ밪 ��ȯ
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // Distance(a,b) : a,b������ �Ÿ� ��ȯ
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void OnMouseDown()
    {
        UIManager.instance.activeUI();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
