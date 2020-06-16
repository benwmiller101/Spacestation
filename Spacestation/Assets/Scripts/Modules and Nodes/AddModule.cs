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
            Instantiate(CubeGreen);
        }else if(type == "blue"){
            Instantiate(CubeBlue, node.transform.position, Quaternion.identity);
        }else if(type == "long") {
            Instantiate(Long);
        }else if(type == "cross") {
            Instantiate(Cross);
        }
        
        node.SetActive(false);
    }

    public void showMenu() {
        PlacementMenu.SetActive(true);
    }
}
