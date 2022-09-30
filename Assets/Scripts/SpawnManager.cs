using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager instance;

    public GameObject enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 6f;
    private float countdown = 0f;

    private int waveIndex = 10;

    public List<GameObject> activeEnemyList = new List<GameObject>();
    public static List<GameObject> GetActiveEnemyList() { return instance.activeEnemyList; }
    public static void AddActiveEnemy(GameObject enemy) { instance.activeEnemyList.Add(enemy); }
    public static void RemoveActiveEnemy(GameObject enemy) { instance.activeEnemyList.Remove(enemy); }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Error, there are multiple instance of SpawnManager in the scene");
            return;
        }

        instance = this;

        activeEnemyList = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for(int i =0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        AddActiveEnemy(enemy);
    }

 
}
