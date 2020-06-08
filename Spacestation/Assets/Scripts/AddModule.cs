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
    public GameObject hp;
    public Vector3 pos;
    public bool found;

    void Start() {

    }

    void Update() {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;
            
            if( Physics.Raycast( ray, out hit, 100 ) && found == false ) {
                if(hit.transform.gameObject.tag == "hp") {
                    PlacementMenu.gameObject.SetActive(true);
                    pos = hit.transform.position;
                    found = true;
                    Debug.Log("ere");

                }
            }
        }
    }



    public void showHP() {

        GameObject[] hps ;
        hps = GameObject.FindGameObjectsWithTag("hp");

        foreach(GameObject SmallHP in hps) {
                SmallHP.GetComponent<MeshRenderer>().enabled=true;
            }
    }

    public void Instantiate(string type) {
        PlacementMenu.SetActive(false);
        //GameObject Hardpoint = hp;

        if(type == "green" && found == true){
            Instantiate(CubeGreen);
            CubeGreen.transform.position = pos;
        }
        /** }else if(type == "blue"){
            Instantiate(CubeBlue);
            CubeBlue.transform.position = hp.transform.position;
        }else if(type == "red") {
             Instantiate(CubeRed);
            CubeRed.transform.position = hp.transform.position;
        }else {
            Instantiate(Cube);
            Cube.transform.position = hp.transform.position;
        }
        **/
        found = false;
        //Debug.Log("hp" + Hardpoint.transform.position);
        //Hardpoint.SetActive(false);
    }

}
