using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Management : MonoBehaviour
{
    public int money;
    public float moneyInc;

    public Text moneyDisp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyDisp.text = "" + money;
    }
}
