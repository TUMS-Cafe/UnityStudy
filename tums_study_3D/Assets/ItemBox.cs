using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    public bool isOveraped = false;

    private Renderer myRenderer;
    public Color touchColor;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // 트리거인 콜라이더와 충돌할 때 자동으로 실행

        if(other.tag =="EndPoint")
        {
            isOveraped=true;
            myRenderer.material.color = touchColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOveraped=false;
            myRenderer.material.color = originalColor;
        }
    }

    // Stay 충돌하고 있는 혹은 붙어 있는 '동안'
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOveraped = true;
            myRenderer.material.color = touchColor;
        }
    }

    /*void OnCollisionEnter(Collision other)
    {
        // 일반 콜라이더와 충돌할 때 자동으로 실행
    }*/
}
