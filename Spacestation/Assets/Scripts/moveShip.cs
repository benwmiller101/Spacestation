using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShip : MonoBehaviour
{
    [Range(1f, 10f)]
    public float speed = 3;
    public float MaxDisFromOrigin = 3;
    public bool right = false;
    public bool left = false;
    public bool forward = false;
    public bool back = false;
    public Vector3 direction;


    //public string direction = myEnum.Item1;
    void Update()
    {
        
        if (right) {
            left = false;
            forward = false;
            back = false;
            direction = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            transform.position += Vector3.right * Time.deltaTime * speed;
            transform.LookAt(transform.position + 10 * direction);
        }
        if (left)
        {
            right = false;
            forward = false;
            back = false;
            transform.position += Vector3.right * Time.deltaTime * -speed;
        }
        if (forward)
        {
            left = false;
            right = false;
            back = false;
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        if (back)
        {
            left = false;
            forward = false;
            right = false;
            transform.position += Vector3.forward * Time.deltaTime * - speed;
        }

        if (transform.position.z > MaxDisFromOrigin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -MaxDisFromOrigin);
        }
        else if (transform.position.z < -MaxDisFromOrigin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, MaxDisFromOrigin);
        }

        if (transform.position.x > MaxDisFromOrigin)
        {
            transform.position = new Vector3(-MaxDisFromOrigin, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -MaxDisFromOrigin)
        {
            transform.position = new Vector3(MaxDisFromOrigin, transform.position.y, transform.position.z);
        }
    }
}
