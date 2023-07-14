using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject shootPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate = 2f;
    [SerializeField] float bulletSpeed = 1;
    float shootCounter = 1;

    public bool beginShooting = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootCounter -= fireRate / 2 * Time.deltaTime;
        if (beginShooting == true)
        {
            InvokeRepeating("StartShooting", 0f, 0.5f);
            beginShooting = false;
        }
    }

    void StartShooting()
    {
        if (shootCounter <= 0)
        {
            GameObject shot = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
            Rigidbody2D rigidbody2d = shot.GetComponent<Rigidbody2D>();
            rigidbody2d.velocity = bulletSpeed * transform.right;
            shootCounter = 1;
            Destroy(shot, 3f);
        }
    }
}
