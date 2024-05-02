using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<ScoreManager>();

            if (instance = null)
            {
                GameObject container = new GameObject("ScoreManager");
                instance = container.AddComponent<ScoreManager>();
            }
        }
        return instance;
    }

    private static ScoreManager instance;

    private int score = 0;

    /*
    //스타트보다 한박자 빠른 함수, static변수에 자기 자신을 넣어서 활성화시킴
    void Awake()
    {
        instance = this;
    }
    */

    //이미 싱글톤 변수가 할당되어 있고 그게 자기 자신이 아닌 경우 스스로를 식제
    void Start()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int newScore)
    {
        score = score + newScore;
    }
}
