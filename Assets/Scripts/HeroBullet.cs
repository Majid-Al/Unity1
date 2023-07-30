using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBullet : MonoBehaviour

{
    GameObject target;
    [SerializeField] int bulletSpeed;
    public float attackDamage;

    [SerializeField] BattleSceneManager battleSceneManager;

    void Start()
    {
        battleSceneManager = GameObject.Find("BattleSceneManager").GetComponent<BattleSceneManager>();
    }
    void Update()
    {
        attackDamage = battleSceneManager.p_attackDamage;
        if (target != null)
        {

            //  go towards selected Enemy (target) at the Speed of speed
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime * Vector3.Distance(transform.position, target.transform.position));
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            float distanceThisFrame = bulletSpeed * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // make the bullet hit directly
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }

        // if it reaches the target position get destroy
        // if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
        // {
        //     Destroy(gameObject);
        //     return;
        // }


    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     Debug.Log("this is why it got destroy");
    //     Destroy(gameObject, 0.1f);
    // }


    // enemy gets set to target ( this function will get called in the Attacking Script (hero))
    public void SetTarget(GameObject enemy)
    {
        target = enemy;
    }

    public void GetDestroy()
    {
        Destroy(gameObject);
    }
}
