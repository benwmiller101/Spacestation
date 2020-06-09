using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class SelectModule : MonoBehaviour
{
    //public  Material mat2;
    public  Material mat1;
    GameObject LastSelected = null;
    public Material lastMat;


    void Update()
    {
        Select();
    }

    public  void Select()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "Module")
                {
                    if( LastSelected != null) 
                    {
                        if (LastSelected.transform == hit.transform  ) {
                            deselect();
                            LastSelected = null;
                        }else {
                             deselect();
                            LastSelected = hit.transform.gameObject;
                            lastMat = hit.transform.gameObject.GetComponent<Renderer>().material;
                            hit.transform.gameObject.GetComponent<Renderer>().material = mat1;
                        }
                    } else if (LastSelected == null) {
                        LastSelected = hit.transform.gameObject;
                        lastMat = hit.transform.gameObject.GetComponent<Renderer>().material;
                        hit.transform.gameObject.GetComponent<Renderer>().material = mat1;
                    }
                }
             }
                       
        }
    }
    
    public void deselect() {
        LastSelected.gameObject.GetComponent<Renderer>().material = lastMat;
    }
}