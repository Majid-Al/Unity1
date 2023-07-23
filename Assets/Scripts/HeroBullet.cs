using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBullet : MonoBehaviour

{
    GameObject target;
    [SerializeField] int speed;
    void Start()
    {

    }
    void Update()
    {
        if (target != null)
        {

            //  go towards selected Enemy (target) at the Speed of speed
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime * Vector3.Distance(transform.position, target.transform.position));
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            float distanceThisFrame = speed * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // make the bullet hit directly
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }

        // if it reaches the target position get destroy
        if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
        {
            Destroy(gameObject);
            return;
        }


    }

    // enemy gets set to target ( this function will get called in the Tower Script)
    public void SetTarget(GameObject enemy)
    {
        target = enemy;
    }
}
