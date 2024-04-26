using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //public Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        //myTransform.Rotate(60, 60, 60);

        //소문자 transform은 나 자신의 transform 컴포넌트로 바로 접근 가능
        //transform.Rotate(60, 60, 60);
    }

    //업데이트는 대략 1초에 60번 정도 실행
    // Update is called once per frame
    void Update()
    {
        //1번에 60도 회전 -> 1초에 60*60=3600도 회전
        //transform.Rotate(60, 60, 60);

        //Time.deltaTime : 화면이 한번 깜빡이는 시간 = 한 프레임의 시간 = 1/프레임수
        transform.Rotate(60 * Time.deltaTime, 60 * Time.deltaTime, 60 * Time.deltaTime);
    }
}
