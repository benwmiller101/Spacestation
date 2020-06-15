using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public GameObject thisNode;
    public GameObject parentMod;
    public Vector3 myPosition;
    public char axis;
    public bool connected = false;
    public Vector3 myModPos;
    public Vector3 myOffset;


    public bool canConnect() {
        return !connected;
    }

    public void getValues(Vector3 myPos, char axis, Vector3 modPos){
        myPosition = myPos;
        myOffset = modPos;
        this.axis = axis;
        move();
    }

    public void move() {
        transform.position = myPosition;
    }
    
    
    public Vector3 getConnectPos(Vector3 nodeOff){
        myModPos = myModPos + nodeOff;
        connected = true ;
        return myModPos;
        
    }

    public char getAxis() {
        return axis;
    }

    private void toggleRender(){

    }


    
}
