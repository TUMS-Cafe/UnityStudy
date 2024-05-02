using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    //public ScoreManager scoreManager;

    void Awake()
    {
        Debug.Log("Start Score: " + ScoreManager.GetInstance().GetScore());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ScoreManager.GetInstance().AddScore(5);
            Debug.Log(ScoreManager.GetInstance().GetScore());
        }
    }
}
