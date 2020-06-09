using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class SelectModule : MonoBehaviour
{
    public Material mat2;
    public Material mat1;
    private Transform LastSelected;

    void Update()
    {
        Select();
    }

    private void Select()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "Module")
                {
                    if (LastSelected.transform != hit.transform)
                    {
                        LastSelected = hit.transform;
                        Debug.Log("Hit");
                        hit.transform.gameObject.GetComponent<Renderer>().material = mat1;
                        LastSelected.gameObject.GetComponent<Renderer>().material = mat2;
                    }
                }
            }
        }
    }
}