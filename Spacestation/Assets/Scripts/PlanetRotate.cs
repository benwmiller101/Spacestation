using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    public float speed;
    private Vector3 target;
    public GameObject pivot;


    void Start()
    {
        target = new Vector3(Random.Range(1, 30), Random.Range(1, 30), Random.Range(1, 30));
    }
    void Update()
    {
        transform.RotateAround(pivot.transform.position, target, speed * Time.deltaTime);
    }
}
