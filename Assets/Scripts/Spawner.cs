using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyBasic;
    [SerializeField] GameObject enemyRange;
    [SerializeField] GameObject enemyTank;
    [SerializeField] GameObject enemyFast;
    [SerializeField] GameObject enemySuper;
    [SerializeField] int enemyNumbers;

    void Start()
    {
        spawn(enemyNumbers);
    }



    void spawn(int x)
    {
        int firstNumber = Random.Range(1, x + 1);
        // Debug.Log("Enemy 1 : " + firstNumber);
        for (int i = 0; i < firstNumber; i++)
        {
            Instantiate(enemyBasic, new Vector3(Random.Range(-2.2f, 2.5f), 6, 0), Quaternion.identity);
        }
        int temp = x - firstNumber;
        int secondNumber = Random.Range(1, temp + 1);
        if (temp > 0)
        {
            // Debug.Log("Enemy 2 : " + secondNumber);
            for (int i = 0; i < secondNumber; i++)
            {
                Instantiate(enemyRange, new Vector3(Random.Range(-2.2f, 2.5f), 6, 0), Quaternion.identity);
            }
        }
        int temp2 = temp - secondNumber;
        if (temp2 > 0)
        {
            // Debug.Log("Enemy 3 : " + temp2);
            for (int i = 0; i < temp2; i++)
            {
                Instantiate(enemyRange, new Vector3(Random.Range(-2.2f, 2.5f), 6, 0), Quaternion.identity);
            }
        }
        // Debug.Log("For totall of : " + firstNumber + secondNumber + temp2);
    }




}
