using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedControl : MonoBehaviour
{
    public Toggle X2;
    public Toggle X3;
    public Toggle PauseToggle;

    private void Update()
    {
        //if (Toggle)
    }
    public void x2()
    {
        Debug.Log("X2");
        //Time.timeScale = 2f;
       // Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
    }

    public void x3()
    {
        Debug.Log("X3");
        // Time.timeScale = 3f;
        // Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
    }

    public void Pause()
    {
        Debug.Log("Pause");
        // Time.timeScale = 0f;
        // Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
    }
    public void Play()
    {
        Debug.Log("Play");
        if (PauseToggle.isOn == true)
        {
            PauseToggle.isOn = false;
            X2.isOn = false;
            X3.isOn = false;
        }
      //  Time.timeScale = 1f;
      //  Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
    }

}
