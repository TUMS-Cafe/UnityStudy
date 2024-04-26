using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloArray : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        int score1 = 90;
        int score2 = 45;
        int score3 = 60;

        Debug.Log(score1);
        Debug.Log(score2);
        Debug.Log(score3);
        */

        //배열 : 여러개의 값을 하나의 변수로 다루게 해준다
        int[] scores = new int[10];
        //scores[1][2][3][4][5][6][7][8][9]

        scores[0] = 90;
        scores[1] = 45;
        scores[2] = 60;
        scores[3] = 70;
        scores[4] = 56;
        scores[5] = 80;
        scores[6] = 90;
        scores[7] = 100;
        scores[8] = 45;
        scores[9] = 14;

        //out of index
        //scores[10]=30;

        //for문을 사용한 배열의 출력
        for(int i = 0; i < 10; i++)
        {
            Debug.Log("학생 " + i + "번째의 점수: " + scores[i]);
        }
    }
}
