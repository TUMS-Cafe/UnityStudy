using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Sum(1, 1));
        Debug.Log(Sum(-5,8,10));
        Debug.Log(Sum(1.3f, 1.6f));
        Debug.Log(Sum(3.14f,3.14f,3.14f));

    }

public int Sum(int a, int b)
    {
        return a + b;
    }

    public int Sum(int a, int b,int c)
    {
        return a + b + c;
    }

    public float Sum(float a, float b)
    {
        return a + b;
    }

    public float Sum(float a, float b, float c)
    {
        return a + b + c;
    }
}