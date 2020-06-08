using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitpointController : MonoBehaviour
{
    public GameObject Node;
    public Vector3 Node1pos;
    public Vector3 Node2pos;
    public Vector3 Node3pos;
    public Vector3 Node4pos;

    void Start()
    {
        Instantiate(Node, transform.position + Node1pos, transform.rotation);
        Instantiate(Node, transform.position + Node2pos, transform.rotation);
        Instantiate(Node, transform.position + Node3pos, transform.rotation);
        Instantiate(Node, transform.position + Node4pos, transform.rotation);
    }
}
