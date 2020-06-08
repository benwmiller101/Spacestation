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
    public GameObject hardpoint;
    public GameObject[] array = new GameObject[10];

//Every frame, if mouse is clicking on hardpoing
    void Update() {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;
            
            if( Physics.Raycast( ray, out hit, 100 )) {
                if(hit.transform.gameObject.tag == "hardpoint") {
                    PlacementMenu.gameObject.SetActive(true);
                    hardpoint = hit.transform.gameObject;
                }
            }
        }
    }


//Shows all Hardpoints (gameObjects tagged with hp)
    public void showHardpoint() {
        GameObject[] hps ;
        hps = GameObject.FindGameObjectsWithTag("hardpoint");

        foreach(GameObject SmallHP in hps) {
                SmallHP.GetComponent<MeshRenderer>().enabled=true;
            }
    }


// Called when Button pressed (instantiates module at hardpoint), takes in string to decide type
    public void Instantiate(string type) {
        PlacementMenu.SetActive(false);

        if(type == "green"){
            Instantiate(CubeGreen, hardpoint.transform.position, Quaternion.identity);
        }else if(type == "blue"){
            Instantiate(CubeBlue, hardpoint.transform.position, Quaternion.identity);
        }else if(type == "red") {
            Instantiate(CubeRed, hardpoint.transform.position, Quaternion.identity);
        }else if(type == "rock") {
            Instantiate(Cube, hardpoint.transform.position, Quaternion.identity);
        }
        
        hardpoint.SetActive(false);
    }

}
