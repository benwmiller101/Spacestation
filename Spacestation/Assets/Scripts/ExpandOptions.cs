using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandOptions : MonoBehaviour
{

    public GameObject ConnectorsMenu;
    public bool Moved = false;
    public void showMenu()
    {
        if (Moved == false)
        {
            ConnectorsMenu.SetActive(true);
            LeanTween.moveLocalX(ConnectorsMenu, 100, 0.5f).setEase(LeanTweenType.easeOutBack);
            Moved = true;
        }
        else if (Moved == true)
        {
            LeanTween.moveLocalX(ConnectorsMenu, 0, 0.5f).setEase(LeanTweenType.easeInBack).setOnComplete(hideMenu);
            Moved = false;
        }
    }

    public void hideMenu()
    {
        ConnectorsMenu.SetActive(false);
    }
}