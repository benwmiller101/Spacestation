using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_ConCross : Module
{
    Vector3 Node1Offset = new Vector3(0.0f, 0.0f, 0.5f);
    Vector3 Node2Offset = new Vector3(0.0f, 0.0f, -0.5f);
    Vector3 Node3Offset = new Vector3(0.5f, 0.0f, 0.0f);
    Vector3 Node4Offset = new Vector3(-0.5f, 0.0f, 0.0f);

    public Module_ConCross(Vector3 pos, GameObject Node, GameObject me) {
        nNodes = 4;
        Node1Pos = Node1Offset + pos;
        Node2Pos = Node2Offset + pos;
        Node3Pos = Node3Offset + pos;
        Node4Pos = Node4Offset + pos;
    }

    public override Vector3 connect(Vector3 modulePos, Vector3 nodeOffset, char axis, float FatOffset) {
        Node1 = (Node) node1.GetComponent(typeof(Node));
        Node1.getValues(Node1Pos, 'z', Node1Offset);
        Node2 = (Node) node2.GetComponent(typeof(Node));
        Node2.getValues(Node2Pos, 'z', Node2Offset);        
        Node3 = (Node) node3.GetComponent(typeof(Node));
        Node3.getValues(Node3Pos, 'x', Node3Offset);
        Node4 = (Node) node4.GetComponent(typeof(Node));
        Node4.getValues(Node4Pos, 'x', Node4Offset);

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
