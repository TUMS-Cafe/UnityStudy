//미리 만들어진 코드 사용
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloUnity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //주석, 컴퓨터가 처리하지 않는 라인 - 메모로 사용

        /*
         여러줄에 걸친
         주석을
         남길 수 있다.
         */

        //콘솔 출력, 컴퓨터와 개발자가 텍스트 메시지를 통해 대화하는 것
        Debug.Log("Hello World!");

        //숫자형 변수
        //int : 소숫점이 없는 정수
        int age = 23;
        int money = -1000;

        Debug.Log(age);
        Debug.Log(money);

        //floating point - float : 소숫점을 가지는 실수, 32비트
        //소숫점 아래 7자리까지만 정확
        float height = 169.1234567f;

        //double : float의 두배의 메모리를 사용, 64비트
        //소숫점 아래 15자리까지만 정확
        double pi = 3.14159265359;

        //숫자가 아닌 변수
        //bool : 참 true 혹은 거짓 false
        bool isGIrl = true;
        bool isBoy = false;

        //character - char : 한 문자
        char grade = 'A';

        //string : 문장
        string movieTitle = "진격의 거인";

        Debug.Log("내 나이는! " + age);
        Debug.Log("내가 가진 돈은! " + money);
        Debug.Log("내 키는! " + height);
        Debug.Log("원주율은! " + pi);
        Debug.Log("내 성적은! " + grade);
        Debug.Log("명작 영화! " + movieTitle);
        Debug.Log("나는 남자인가? " + isBoy);
        Debug.Log("나는 여자인가? " + isGIrl);

        //var : 할당하는 값을 기준으로 타입이 결정됨
        var myName = "geeyun";
        // string myName = "geeyun";
        var myAge = 23;
        // int myAge = 23;

        Debug.Log("나의 이름: " + myName);
        Debug.Log("나의 나이: " + myAge);
    }
}
