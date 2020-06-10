using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_ConCross : Module
{

    public Module_ConCross(Vector3 pos, GameObject Node ) {
        Node1pos = new Vector3(0.0f, 0.0f, 0.5f);
        Node2pos = new Vector3(0.0f, 0.0f, -0.5f);
        Node3pos = new Vector3(0.5f, 0.0f, 0.0f);
        Node4pos = new Vector3(-0.5f, 0.0f, 0.0f);
    }
}
