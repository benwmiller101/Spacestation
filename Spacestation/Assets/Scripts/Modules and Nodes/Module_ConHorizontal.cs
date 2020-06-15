using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_ConHorizontal : Module
{
    Vector3 Node1Offset = new Vector3(0.0f, 0.0f, 0.5f);
    Vector3 Node2Offset = new Vector3(0.0f, 0.0f, -0.5f);

    public Module_ConHorizontal(Vector3 pos, GameObject Node, GameObject me) {
        nNodes = 2;
        Node1Pos = Node1Offset + pos;
        Node2Pos = Node2Offset + pos;
    }
    

    public override Vector3 connect(Vector3 modulePos, Vector3 nodeOffset, char axis, float FatOffset) {

        if(axis == 'z') {
            Node1Offset = new Vector3(0.0f, 0.0f, 0.5f);
            Node2Offset = new Vector3(0.0f, 0.0f, -0.5f);
        }else if(axis =='x') {
            Node1Offset = new Vector3(0.5f, 0.0f, 0.0f);
            Node2Offset = new Vector3(-0.5f, 0.0f, 0.0f);
        }

        Node1 = (Node) node3.GetComponent(typeof(Node));
        Node1.getValues(Node1Pos, axis, Node1Offset);
        Node2 = (Node) node4.GetComponent(typeof(Node));
        Node2.getValues(Node2Pos, axis, Node2Offset);  
            
        if(axis == 'x') {
            if(nodeOffset.x > 0) {
                return modulePos + nodeOffset + new Vector3(0.5f + FatOffset, 0.0f, 0.0f) ;
            }else if( nodeOffset.x < 0) {
                return modulePos + nodeOffset + new Vector3(-0.5f - FatOffset , 0.0f, 0.0f) ;
            }
        }else if(axis == 'z') {
            if(nodeOffset.z > 0) {
                return modulePos + nodeOffset + new Vector3(0.0f, 0.0f, 0.5f + FatOffset) ;
            }else if( nodeOffset.z < 0) {
                return modulePos + nodeOffset + new Vector3(0.0f, 0.0f, -0.5f - FatOffset) ;
            }
        }

        return new Vector3(0.0f,0.0f,0.0f);
    }
}
