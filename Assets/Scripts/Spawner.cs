using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] int enemyNumbers;

    void Start()
    {
        spawn(enemyNumbers);
    }



    void spawn(int x)
    {
        int firstNumber = Random.Range(1, x + 1);
        Debug.Log("Enemy 1 : " + firstNumber);
        for (int i = 0; i < firstNumber; i++)
        {
            Instantiate(enemy1, new Vector3(Random.Range(-2.2f, 2.5f), 6, 0), Quaternion.identity);
        }
        int temp = x - firstNumber;
        int secondNumber = Random.Range(1, temp + 1);
        if (temp > 0)
        {
            Debug.Log("Enemy 2 : " + secondNumber);
            for (int i = 0; i < secondNumber; i++)
            {
                Instantiate(enemy2, new Vector3(Random.Range(-2.2f, 2.5f), 6, 0), Quaternion.identity);
            }
        }
        int temp2 = temp - secondNumber;
        if (temp2 > 0)
        {
            Debug.Log("Enemy 3 : " + temp2);
            for (int i = 0; i < temp2; i++)
            {
                Instantiate(enemy3, new Vector3(Random.Range(-2.2f, 2.5f), 6, 0), Quaternion.identity);
            }
        }
    }




}
