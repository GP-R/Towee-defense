using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float speed;

    // fix : protected level, get set func
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    public static Transform[] points;       // waypoint ��ġ����

    protected Transform target;               // target ��ġ����
    private int wavepointIndex;             // waypoint�� ����
    public GameObject wayPoint;

    public virtual void Awake() { }
    public virtual void Start() { }
    public virtual void Update() { }

    public void GetNextWaypoint()
    {
        wavepointIndex++;
        if (Waypoints.points.Length > wavepointIndex)
            target = Waypoints.points[wavepointIndex];
        else
        {
            SpawnManager.RemoveActiveEnemy(gameObject);
            Destroy(gameObject);
        }
    }

    public float GetSpeed() { return speed; }
    //public GameObject getEnemyPrefab() { return curEnemyPrefab; }

}


public class SecondRoundEnemy : Enemy
{
    public override void Start()
    {

    }

    public override void Update()
    {

    }
}
