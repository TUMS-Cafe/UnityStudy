using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    public static Ninja ninjaKing;

    public string ninjaName;

    public bool isKing;

    void Start()
    {
        if (isKing)
        {
            ninjaKing = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("My Name: " + ninjaName + ", Ninja King is: " + ninjaKing);
    }
}
