using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("모든 개들의 수: " + Dog.count);
        Dog.ShowAnimalType();
    }
}
