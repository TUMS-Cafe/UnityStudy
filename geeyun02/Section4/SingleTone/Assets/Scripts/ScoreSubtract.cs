using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSubtract : MonoBehaviour
{
    //public ScoreManager scoreManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ScoreManager.GetInstance().AddScore(-2);
            Debug.Log(ScoreManager.GetInstance().GetScore());
        }
    }
}
