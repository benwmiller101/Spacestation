using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module {
    public GameObject node1;
    public GameObject node2;
    public GameObject node3;
    public GameObject node4;
    public GameObject me;
    public GameObject nodeObj;
    public bool placed = false;
    public Vector3 pos;
    public int nNodes;
    public Vector3 Node1Pos;
    public Vector3 Node2Pos;
    public Vector3 Node3Pos;
    public Vector3 Node4Pos;
    public char Node1Axis;
    public char Node2Axis;
    public char Node3Axis;
    public char Node4Axis;
    public Node Node1;
    public Node Node2;
    public Node Node3;
    public Node Node4;
    public float myFatAss = 0f;



    public Module( ) {
            
    
    }

    public void nodeAxis() {
    }

    public virtual Vector3 connect(Vector3 modulePos, Vector3 nodeOffset, char axis, float FatOffset) {
        return pos;
    }

    public virtual void parent () {

    }


    public virtual void passValues() {

    }




}