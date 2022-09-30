using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Turret turret;

    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;
    public int damage;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    public void getTurretDamage(int damage)
    {
        this.damage = damage;
    }
    // Start is called before the first frame update
    // Start is called before the first frame update

    private void Awake()
    {
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget(damage);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }


    void HitTarget(int damage)
    {
        target.GetComponent<Enemy>().currentHealth -= damage + DataController.instance.gameData.MissileDamageUpgrade;
        target.GetComponent<Enemy>().healthBar.SetHealth(target.GetComponent<Enemy>().currentHealth);
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        if (target.GetComponent<Enemy>().currentHealth <= 0)
        {
            Destroy(target.gameObject);
            BuildManager.money += 10;
        }
        Destroy(gameObject);
    }
}
