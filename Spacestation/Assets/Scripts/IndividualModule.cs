using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualModule : MonoBehaviour
{
    public string modType;
    public GameObject Node;
    public Module thisModule;
    public GameObject ModuleObj;

    
    
    public void Start() {
        if(modType == "Connector_Cross") {
            thisModule = new Module_ConCross(transform.position, Node);
        }

        createNodes();
    }

    public void createNodes( ) {
        thisModule.node1 = (GameObject)Instantiate(Node, transform.position + thisModule.Node1pos, transform.rotation);
        thisModule.node2 = (GameObject)Instantiate(Node, transform.position + thisModule.Node2pos, transform.rotation);
        thisModule.node3 = (GameObject)Instantiate(Node, transform.position + thisModule.Node3pos, transform.rotation);
        thisModule.node4 = (GameObject)Instantiate(Node, transform.position + thisModule.Node4pos, transform.rotation);
        nodeParent();
    }
    
    public void nodeParent( ) {
        thisModule.node1.transform.parent = ModuleObj.transform;
        thisModule.node2.transform.parent = ModuleObj.transform;
        thisModule.node3.transform.parent = ModuleObj.transform;
        thisModule.node4.transform.parent = ModuleObj.transform;
    }
    

    }
