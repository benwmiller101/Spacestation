using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShip : MonoBehaviour
{

    public GameObject ship;
    public Animator anim;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            anim.Play("DockOpen");
            Instantiate(ship, transform.position, Quaternion.identity);
        } 
    }
}
