using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulePlacement : MonoBehaviour
{
 

   public float Range = 10f;
     public GameObject Cube;
     public GameObject CubeRed;
     public GameObject CubeGreen;
     public GameObject CubeBlue;
    void Update()
    {
        PlaceBlock();
        RemoveBlock();
    }

        private void PlaceBlock(){
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hitpoint;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitpoint, Range)){
                Instantiate(Cube,hitpoint.normal + hitpoint.transform.position, hitpoint.transform.rotation);
                Debug.Log("placed a ciube");
            }
        }
    }

    private void RemoveBlock(){
        if (Input.GetMouseButtonDown(1)){
            RaycastHit hitpoint;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out hitpoint, Range)){
                 if(hitpoint.collider.gameObject.tag != "Base")
                Destroy(hitpoint.collider.gameObject);
            }
        }
    }

    public void BlockColourRed(){
        Cube =  CubeRed;
    }
    public void BlockColourGreen(){
        Cube =  CubeGreen;
    }
    public void BlockColourBlue(){
        Cube =  CubeBlue;
    }
}
