using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float speed = 1;
    [SerializeField] float health;
    [SerializeField] float attack;
    [SerializeField] float attackRange;

    void Start()
    {
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    }


