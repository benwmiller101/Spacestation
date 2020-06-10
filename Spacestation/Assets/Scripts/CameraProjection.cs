using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProjection : MonoBehaviour
{
    // Update is called once per frame
    public void CameraChange()
    {
        Debug.Log("Changed");
        if (Camera.main.orthographic == true)
        {
            Camera.main.orthographic = false;
        }
        else
        {
            Camera.main.orthographic = true;
        }
    }
}
