using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulePlacementTest : MonoBehaviour
{
 

   
     [SerializeField]
     private GameObject currentPlaceablePrefab;
    [SerializeField]
     private KeyCode newObjectHotkey = KeyCode.A;
    public float Range = 10f;
     private GameObject currentPlaceableObject;
     public GameObject CubeRed;
     public GameObject CubeGreen;
     public GameObject CubeBlue;
    void Update()
    {
        HandleNewObjectHotkey();
        //PlaceBlock();
        RemoveBlock();

        if(currentPlaceableObject != null){
            MoveCurrentPlaceableObjectToMouse();
            ReleaseIfClicked();
        }
    }
    private void ReleaseIfClicked(){
        if(Input.GetMouseButtonDown(0)){
            currentPlaceableObject = null;
        }
    }
    private void MoveCurrentPlaceableObjectToMouse(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)){
            currentPlaceableObject.transform.position = hitInfo.point;
        }
    }

    private void HandleNewObjectHotkey(){
        if (Input.GetKeyDown(newObjectHotkey))
        {
            if(currentPlaceableObject == null){
                currentPlaceableObject = Instantiate(currentPlaceablePrefab);
            }
            else
            {
                Destroy(currentPlaceableObject);
            }
        }
    }
        private void PlaceBlock(){
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hitpoint;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitpoint, Range)){
                Instantiate(currentPlaceableObject,hitpoint.normal + hitpoint.transform.position, hitpoint.transform.rotation);
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
        currentPlaceableObject =  CubeRed;
    }
    public void BlockColourGreen(){
        currentPlaceableObject =  CubeGreen;
    }
    public void BlockColourBlue(){
        currentPlaceableObject =  CubeBlue;
    }
}
