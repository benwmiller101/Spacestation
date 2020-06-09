using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddModule : MonoBehaviour

{
    public GameObject PlacementMenu;
    public GameObject Cube;
    public GameObject CubeRed;
    public GameObject CubeGreen;
    public GameObject CubeBlue;
    public GameObject Cross;
    public GameObject Long;
    public GameObject node;
    public GameObject[] array = new GameObject[10];

//Every frame, if mouse is clicking on hardpoing
    void Update() {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;
            
            if( Physics.Raycast( ray, out hit, 100 )) {
                if(hit.transform.gameObject.tag == "node") {
                    PlacementMenu.gameObject.SetActive(true);
                    node = hit.transform.gameObject;
                }
            }
        }
    }

    private void NodeHover()
    {
        if (Input.GetMouseButtonDown(1)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "Module")
                {
                    //hit.transform.gameObject
                }
            }
        }
    }


//Shows all nodes (gameObjects tagged with hp)
    public void shownode() {
        GameObject[] hps ;
        hps = GameObject.FindGameObjectsWithTag("node");

        foreach(GameObject SmallHP in hps) {
                SmallHP.GetComponent<MeshRenderer>().enabled=true;
            }
    }


// Called when Button pressed (instantiates module at node), takes in string to decide type
    public void Instantiate(string type) {
        PlacementMenu.SetActive(false);

        if(type == "green"){
            Instantiate(CubeGreen, node.transform.position, Quaternion.identity);
        }else if(type == "blue"){
            Instantiate(CubeBlue, node.transform.position, Quaternion.identity);
        }else if(type == "long") {
            Instantiate(Long, node.transform.position, Quaternion.identity);
        }else if(type == "cross") {
            Instantiate(Cross, node.transform.position, Quaternion.identity);
        }
        
        node.SetActive(false);
    }

}
