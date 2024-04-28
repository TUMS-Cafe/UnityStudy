using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //public int[] scores = new int[10];
    //private int index = 0;

    public List<int> scores = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        int score0 = 45;
        int score1 = 60;
        int score2 = 75;

        scores.Add(score0);
        scores.Add(score1);
        scores.Add(score2);

        //scores.RemoveAt(1);
        scores.Remove(60);

        Debug.Log(scores[1]);

        //리스트 요소 삭제 시 인덱스가 앞으로 밀리는 특징을 활용하여 모든 요소 삭제
        while (scores.Count > 0)
        {
            Debug.Log("삭제된 요소: " + scores[0]);
            scores.RemoveAt(0);
        }
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //scores[index] = Random.Range(0, 100);
            //index++;

            int randomNumber = Random.Range(0, 100);
            scores.Add(randomNumber);
        }
        if (Input.GetMouseButtonDown(1))
        {
            scores.RemoveAt(3);
        }
    }
    */
}
