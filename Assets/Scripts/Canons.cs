using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canons : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = cam.ScreenToWorldPoint(touch.position);

            // Check if either object is close enough to the touch position
            if (Vector3.Distance(touchPosition, object1.transform.position) < 10.5f)
            {
                RotateObject(object1, touchPosition);
            }
            else if (Vector3.Distance(touchPosition, object2.transform.position) < 10.5f)
            {
                RotateObject(object2, touchPosition);
            }

            // If there are more than one touch, loop through all touches
            if (Input.touchCount > 1)
            {
                foreach (Touch touch2 in Input.touches)
                {
                    if (touch2.fingerId != touch.fingerId)
                    {
                        Vector3 touch2Position = cam.ScreenToWorldPoint(touch2.position);

                        if (Vector3.Distance(touch2Position, object1.transform.position) < 10.5f)
                        {
                            RotateObject(object1, touch2Position);
                        }
                        else if (Vector3.Distance(touch2Position, object2.transform.position) < 10.5f)
                        {
                            RotateObject(object2, touch2Position);
                        }
                    }
                }
            }
        }
    }

    private void RotateObject(GameObject obj, Vector3 touchPosition)
    {
        Vector3 direction = touchPosition - obj.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;
        obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
// if (Input.touchCount > 0)
// {
//     Touch touch = Input.GetTouch(0);
//     Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

//     // Check if the touch position is close enough to the object's position
//     if (Vector3.Distance(touchPosition, transform.position) < 10.5f)
//     {
//         Vector3 direction = touchPosition - transform.position;
//         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
//         transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
//     }
// }
