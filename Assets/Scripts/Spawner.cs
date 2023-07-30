using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyBasic;
    [SerializeField] GameObject enemyRange;
    [SerializeField] GameObject enemyFast;
    [SerializeField] GameObject enemyTank;
    [SerializeField] GameObject enemySuper;
    [SerializeField] int enemyNumbers;

    List<GameObject> basicEnemyPool = new List<GameObject>();
    List<GameObject> rangeEnemyPool = new List<GameObject>();
    List<GameObject> fastEnemyPool = new List<GameObject>();
    List<GameObject> tankEnemyPool = new List<GameObject>();
    [SerializeField] int poolSize = 10;



    void Start()
    {
        // Initialize the Enemys pool
        CreatePool(enemyBasic, basicEnemyPool, 10);
        CreatePool(enemyRange, rangeEnemyPool, 10);
        CreatePool(enemyFast, fastEnemyPool, 10);
        CreatePool(enemyTank, tankEnemyPool, 10);






        // spawn(enemyNumbers);
    }

    void CreatePool(GameObject enemy, List<GameObject> thePool, int enemyNumbers)
    {
        for (int i = 0; i < enemyNumbers; i++)
        {
            GameObject spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity);
            spawnedEnemy.SetActive(false);
            thePool.Add(spawnedEnemy);
        }
    }

    void spawn(int x)
    {
        x -= 3;
        int randomNumber = Random.Range(1, x + 1);

        for (int i = 0; i < randomNumber; i++)
        {
            Instantiate(enemyBasic, new Vector3(Random.Range(-2.2f, 2.5f), 6, 0), Quaternion.identity);
        }
        Debug.Log("basic enemys : " + randomNumber);



        x = x - (randomNumber - 1);
        randomNumber = Random.Range(1, x + 1);
        for (int i = 0; i < randomNumber; i++)
            {
                Instantiate(enemyRange, new Vector3(Random.Range(-2.2f, 2.5f), 6, 0), Quaternion.identity);
            }
        Debug.Log("range enemys : " + randomNumber);



        x = x - (randomNumber - 1);
        randomNumber = Random.Range(1, x + 1);

        for (int i = 0; i < randomNumber; i++)
        {
            Instantiate(enemyFast, new Vector3(Random.Range(-2.2f, 2.5f), 6, 0), Quaternion.identity);
        }
        Debug.Log("Fast enemys : " + randomNumber);




        x = x - (randomNumber - 1);

        for (int i = 0; i < x; i++)
        {
            Instantiate(enemyTank, new Vector3(Random.Range(-2.2f, 2.5f), 6, 0), Quaternion.identity);
        }
        Debug.Log("Tank enemys : " + x);


    }


}
