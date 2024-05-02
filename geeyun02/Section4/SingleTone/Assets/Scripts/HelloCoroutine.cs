using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HelloUnity");
        Debug.Log("End");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine("HelloUnity");
        }
    }

    IEnumerator HelloUnity()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Debug.Log("Hello Unity");
        }
    }
}
