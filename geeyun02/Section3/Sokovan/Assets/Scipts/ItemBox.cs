using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Renderer myRenderer;

    public Color touchColor; //충돌 시 색상 (마음대로 변경 가능)
    private Color originalColor; //기존 색상 저장해둠

    public bool isOverlapped = false;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    //trigger인 콜라이더와 충돌할 때 자동으로 실행
    //Enter : 충돌을 한 그 순간
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOverlapped = true;
            //endpoint 도달 시 상자 색깔 변경
            myRenderer.material.color = touchColor;
        }
    }

    //Exit : 붙어있다가 떼어질 때
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOverlapped = false;
            //endpoint에서 벗어날 시 상자 색깔 원상태로
            myRenderer.material.color = originalColor;
        }
    }

    //Stay : 충돌하고 있는 혹은 붙어있는 '동안'
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOverlapped = true;
            //endpoint 도달 시 상자 색깔 변경
            myRenderer.material.color = touchColor;
        }
    }
}
