using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowards : MonoBehaviour
{
    public GameObject pivot;

    void Update()
    {
        transform.LookAt(pivot.transform.position);
    }
}
