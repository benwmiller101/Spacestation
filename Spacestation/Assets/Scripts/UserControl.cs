using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class UserControl : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private Vector3 previousPosition;
    private float minFov = 15f;
    private float maxFov = 110f;
    public float sensitivity = 10f;

    float cameraDistanceMax = 20f;
    float cameraDistanceMin = 1f;
    public GameObject selectedModule;

    public float AnchorX = 0;
    public float AnchorY = 0;
    public float AnchorZ = 0;

    public TextMeshProUGUI ModuleName;
    public Text ModuleDescription;
    public GameObject ModuleInfo;

    //public  Material mat2;
    public Material mat1;
    GameObject LastSelected = null;
    public Material lastMat;
    public bool selected;

    void Start()
    {
        ModuleInfo.SetActive(false);
    }


    void Update()
    {
        CameraRotate();
        CameraZoom();
        Select();

        
    }


    private void CameraZoom()
    {
        if (Camera.main.orthographic == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0f) // forward
            {
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + Input.GetAxis("Mouse ScrollWheel"), cameraDistanceMin, cameraDistanceMax);
            }
        }
        else
        {
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
        }
    }

    private void CameraRotate()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            previousPosition =  cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            //Change Camera Anchor point to selected item
            cam.transform.position = selectedModule.transform.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            cam.transform.Translate(new Vector3(0, 0,  - 10));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);

        }
    }

    public void Select()
    {
        //When Mouse is clicked send a raycast out
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "Module")
                {
                    //If it hits object with module tag set the this objects position to new anchorpoint.
                    selectedModule = hit.transform.gameObject;

                    if (LastSelected != null)
                    {
                        if (LastSelected.transform == hit.transform)
                        {
                            //Selected the same object
                            deselect();
                            LastSelected = null;
                            selected = false;
                            ModuleInfo.SetActive(false);
                            ModuleName.text = "";
                        }
                        else
                        {
                            /*Selected another object.
                            Change the material of the initial object back to normal and change the newly selceted objects material to outline shader*/ 
                            deselect();
                            LastSelected = hit.transform.gameObject;
                            lastMat = hit.transform.gameObject.GetComponent<Renderer>().material;
                            hit.transform.gameObject.GetComponent<Renderer>().material = mat1;
                            selected = false;
                            ModuleInfo.SetActive(true);
                            ModuleName.text = hit.transform.gameObject.name;
                        }
                    }
                    else if (LastSelected == null)
                    {
                        //If its the initial object being selected
                        LastSelected = hit.transform.gameObject;
                        lastMat = hit.transform.gameObject.GetComponent<Renderer>().material;
                        hit.transform.gameObject.GetComponent<Renderer>().material = mat1;
                        selected = true;
                        ModuleInfo.SetActive(true);
                        ModuleName.text = hit.transform.gameObject.name;
                    }
                }
            }

        }
    }

    public void deselect()
    {
        LastSelected.gameObject.GetComponent<Renderer>().material = lastMat;
    }
}



