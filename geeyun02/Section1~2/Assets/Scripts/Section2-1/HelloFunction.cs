using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float sizeofcircle = 30f;
        float radius = GetRadius(sizeofcircle);
        Debug.Log("원의 넓이: " + sizeofcircle + " 원의 반지름: " + radius);
    }

    //Scope : 변수가 관측 가능한 영역, 함수 내부 스코프의 내용은 밖에서 보이지 않아서 변수명 같아도 충돌이 일어나지 않음
    float GetRadius(float size)
    {
        float pi = 3.14f;
        float tmp = size / pi;
        //유니티 엔진의 Mathf 함수 사용하여 제곱근 계산, 점 연산자는 내부의 요소를 가져온다는 의미
        float radius = Mathf.Sqrt(tmp);

        return radius;
    }
}
