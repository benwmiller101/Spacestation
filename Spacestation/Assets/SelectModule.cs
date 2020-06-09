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
                    if( LastSelected != null ) 
                    {
                        deselect();
                        if (LastSelected.transform != hit.transform )
                        {
                            LastSelected = hit.transform.gameObject;
                            lastMat = hit.transform.gameObject.GetComponent<Renderer>().material;
                            Debug.Log("Hit1");
                            hit.transform.gameObject.GetComponent<Renderer>().material = mat1;
                        }
                    } else if (LastSelected == null) {
                            LastSelected = hit.transform.gameObject;
                            lastMat = hit.transform.gameObject.GetComponent<Renderer>().material;
                            Debug.Log("Hit2");
                            hit.transform.gameObject.GetComponent<Renderer>().material = mat1;
                        }
                    }
                }
                       
            }
    }
    
    public void deselect() {
        Debug.Log("dese");
        LastSelected.gameObject.GetComponent<Renderer>().material = lastMat;

    }
}