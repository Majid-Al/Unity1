using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{

    [SerializeField] string enemyTag = "Enemy";
    GameObject firstOne;
    bool target = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetTarget()
    {
        float towerRange = 3;
        int index = 0;
        firstOne = null;
        // get all the enemys
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject[] nearEnemys = new GameObject[enemys.Length];

        // filter the enemys and find those in range
        foreach (var enemy in enemys)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < towerRange)
            {
                nearEnemys[index] = enemy;
                index++;
            }
        }

        // find the first enemy in ther range
        if (nearEnemys.Length >= 1 && nearEnemys[0])
        {
            firstOne = nearEnemys[0];
        }
        target = true;

        // if there is no enemy in the range go back to deffault position
        if (firstOne == null)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            target = false;
        }
    }
}
