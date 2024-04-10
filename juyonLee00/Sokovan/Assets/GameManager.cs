using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ItemBox[] itemBoxes;

    public bool isGameOver;

    void Start()
    {
        isGameOver = false;
    }

    
    void Update()
    {
        if(isGameOver == true)
        {
            return;
        }

        int count = 0;
        for (int i=0; i<itemBoxes.Length; i++)
        {
            if (itemBoxes[i].isOveraped == true)
                count += 1;
        }

        if(count >= 3)
        {
            isGameOver = true;
        }
        
    }

}
