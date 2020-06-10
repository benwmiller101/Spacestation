using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private Vector3 previousPosition;
    private float minFov = 15f;
    private float maxFov = 90f;
    public float sensitivity = 10f;

    float cameraDistanceMax = 20f;
    float cameraDistanceMin = 1f;
    public GameObject selectedModule;

    public float AnchorX = 0;
    public float AnchorY = 0;
    public float AnchorZ = 0;

    //public  Material mat2;
    public Material mat1;
    GameObject LastSelected = null;
    public Material lastMat;
    public bool selected;

    void Update()
    {
        CameraRotate();
        CameraZoom();
        Select();

        Debug.Log(selectedModule.transform.position);
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

        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = new Vector3();

            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            cam.transform.Translate(new Vector3(0, 0, -10));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    public void Select()
    {
        if (Input.GetMouseButtonDown(1))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "Module")
                {
                    selectedModule = hit.transform.gameObject;
                    AnchorX = selectedModule.transform.position.x;
                    AnchorY = selectedModule.transform.position.y;
                    AnchorZ = selectedModule.transform.position.z;

                    if (LastSelected != null)
                    {
                        if (LastSelected.transform == hit.transform)
                        {
                            //Click the same object
                            deselect();
                            LastSelected = null;
                            selected = false;

                        }
                        else
                        {
                            //Click Another object
                            deselect();
                            LastSelected = hit.transform.gameObject;
                            lastMat = hit.transform.gameObject.GetComponent<Renderer>().material;
                            hit.transform.gameObject.GetComponent<Renderer>().material = mat1;
                            selected = false;
                            transform.position = new Vector3(-AnchorX, -AnchorY, -AnchorZ);
                        }
                    }
                    else if (LastSelected == null)
                    {
                        //Click no object
                        LastSelected = hit.transform.gameObject;
                        lastMat = hit.transform.gameObject.GetComponent<Renderer>().material;
                        hit.transform.gameObject.GetComponent<Renderer>().material = mat1;
                        selected = true;
                        transform.position = new Vector3(AnchorX, AnchorY, AnchorZ);
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



