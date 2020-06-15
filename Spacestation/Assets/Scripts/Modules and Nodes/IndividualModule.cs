using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualModule : MonoBehaviour
{
    public string modType;
    public GameObject Node;
    public Node node;
    public Module thisModule;
    public GameObject ModuleObj;
    public bool placed = false;
    public bool created = false;
    public Vector3 spawn = new Vector3(0.0f, 0.0f, 0.5f);

    void Update() {
        if (placed != true) {
            if( Input.GetMouseButtonDown(0) )
            {
                Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
                RaycastHit hit;
                
                if( Physics.Raycast( ray, out hit, 100 )) {
                    if(hit.transform.gameObject.tag == "node") {
                        ModuleObj.SetActive(true);
                        node = (Node) hit.transform.gameObject.GetComponent(typeof(Node));
                        transform.position = thisModule.connect(node.transform.parent.transform.position, node.myOffset, node.getAxis(), thisModule.myFatAss);
                        rotate(node.getAxis());
                        placed = true;
                    }
                }
            }
        }
    }
    
    
    public void Start() {
        created = false;
        thisModule = new Module();

        if(modType == "Connector_Cross") {
            thisModule = new Module_ConCross(ModuleObj.transform.position, Node, ModuleObj);
        }else if(modType == "Connector_Horizontal") {
             thisModule = new Module_ConHorizontal(ModuleObj.transform.position, Node, ModuleObj);
        }else if(modType == "BaseV1") {
                thisModule = new Module_BaseV1(ModuleObj.transform.position, Node, ModuleObj);
        }

        createNodes();
    }

    public void createNodes( ) {
        if(created == false) {
            for(int i = thisModule.nNodes; i != 0; i--) {
                if (i == 4) {
                    thisModule.node1 = (GameObject)Instantiate(Node);
                    thisModule.node1.transform.parent = ModuleObj.transform;
                }else if (i == 3) {
                    thisModule.node2 = (GameObject)Instantiate(Node);
                    thisModule.node2.transform.parent = ModuleObj.transform;
                }else if (i == 2) {
                    thisModule.node3 = (GameObject)Instantiate(Node);
                    thisModule.node3.transform.parent = ModuleObj.transform;
                }else if (i == 1) {
                    thisModule.node4 = (GameObject)Instantiate(Node);
                    thisModule.node4.transform.parent = ModuleObj.transform;
                }
            }
                    thisModule.connect(spawn,spawn,'x', thisModule.myFatAss);
        }
        created = true;
    }

    public void rotate(char axis) {
        if(modType == "Connector_Horizontal") {
            if(axis == 'z') {
                transform.Rotate(0, 0, 0);
            }else if( axis == 'x') {
                transform.Rotate(0, 90, 0);
            }
        }
    }

}