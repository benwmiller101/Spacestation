using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class AddModule : MonoBehaviour

{
    public GameObject PlacementSubMenu;
    public GameObject BuildMenu;
    public GameObject Cube;
    public GameObject CubeRed;
    public GameObject CubeGreen;
    public GameObject CubeBlue;
    public GameObject Cross;
    public GameObject Long;
    public GameObject node;
    public GameObject[] array = new GameObject[10];
    public bool Moved = false;

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
        //BuildMenu.SetActive(false);
       // PlacementSubMenu.SetActive(false);

        if (type == "green"){
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
        if (Moved == false)
        {
            BuildMenu.SetActive(true);
            LeanTween.moveLocalX(BuildMenu, 2.5f, 0.5f).setEase(LeanTweenType.easeOutBack);
            Moved = true;
        }else if(Moved == true) {
            LeanTween.moveLocalX(BuildMenu, -100, 0.5f).setEase(LeanTweenType.easeInBack).setOnComplete(hideMenu);
            Moved = false;
        }
    }

    public void hideMenu()
    {
        BuildMenu.SetActive(false);
    }
}
