using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoundEnemy : Enemy
{

    public override void Awake()
    {
        wayPoint = GameObject.Find("WayPoints");
        points = new Transform[wayPoint.transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = wayPoint.transform.GetChild(i);
        }

    }
    public override void Start()
    {
        target = points[0];
        speed = 10f;
        GameObject bar = transform.Find("Canvas").gameObject.transform.Find("Health bar").gameObject;
        healthBar = bar.GetComponent<HealthBar>();
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }



    public override void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
}
