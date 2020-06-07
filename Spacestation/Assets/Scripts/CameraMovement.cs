using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private Vector3 previousPosition;
    private float minFov = 15f;
    private float maxFov = 90f;
    public float sensitivity = 10f;
    public float Range = 10f;
     public GameObject Cube;

    void Update()
    {
        CameraRotate();
        CameraZoom();
        PlaceBlock();
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
    
    private void CameraZoom (){
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }

    private void CameraRotate ()
    {
    if (Input.GetMouseButtonDown(0)){
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0)){
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = new Vector3();

            cam.transform.Rotate(new Vector3(1,0,0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0,1,0), -direction.x * 180, Space.World);
            cam.transform.Translate(new Vector3(0,0,-10));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }

}


