using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : Variables
{
    public GameObject Enemy;
    public GameObject Heart;
    public Transform EnemySpawns;
    public List<Transform> spawnPosition;
    public int enemyCount = 0;
    Text EnemyLeft;
    public static int curEnemy;
    public static int prevEnermySpawnNum = 1;
    public GameObject gem1,gem2,gem3,gem4,gem5,gem6,gem7,gem8,gem9,gem10,gem11,gem12,gem13,gem14,gem15,gem16,gem17,gem18;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in EnemySpawns)
        {
            spawnPosition.Add(child);
        }
        spawnZomb(numZombPerSpawn);
        curEnemy = enemyCount;
        EnemyLeft = GameObject.Find("EnemyLeft").GetComponent<Text>();
        
        Enemy.SetActive(false);
        
    }
    void spawnZomb (int numPerSpawn)
    {
        Enemy.SetActive(true);
        for (int k = 0; k < numPerSpawn; k++)
        {
            for(int i=0; i<9; i++)
            {

                Instantiate(Enemy, spawnPosition[i].position, Quaternion.identity);
                enemyCount = numZombPerSpawn * 9;
                NextLevelTime = 0f;
            }
        }
        Enemy.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(prevEnermySpawnNum != numZombPerSpawn)
        {
            spawnZomb(numZombPerSpawn);
            gem1.SetActive(true);
            gem2.SetActive(true);
            gem3.SetActive(true);
            gem4.SetActive(true);
            gem5.SetActive(true);
            gem6.SetActive(true);
            gem7.SetActive(true);
            gem8.SetActive(true);
            gem9.SetActive(true);
            gem10.SetActive(true);
            gem11.SetActive(true);
            gem12.SetActive(true);
            gem13.SetActive(true);
            gem14.SetActive(true);
            gem15.SetActive(true);
            gem16.SetActive(true);
            gem17.SetActive(true);
            gem18.SetActive(true);
            prevEnermySpawnNum = numZombPerSpawn;
            if(numZombPerSpawn % 2 == 0)
            {
                Heart.SetActive(true);
            }
        }
        EnemyLeft.text = "Enemy:  " + curEnemy + '/' + enemyCount;
    }
}
