using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ItemBox[] ItemBoxes;

    public bool isGameOver;

    public GameObject winUI;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //스페이스를 누르면 재시작
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //SceneManager.LoadScene("Main");
            SceneManager.LoadScene(0);
        }

        //내가 따로 추가한 코드 - esc를 누르면 종료
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //게임 승리인 경우 한번만 체크하고 종료
        if (isGameOver == true)
        {
            return;
        }

        int count = 0;
        
        //배열의 요소가 모두 true이면 게임 승리
        for(int i = 0; i < 3; i++)
        {
            if (ItemBoxes[i].isOverlapped == true)
            {
                //count = count + 1;
                count++;
            }

            if (count >= 3)
            {
                Debug.Log("게임 승리!");
                isGameOver = true;
                winUI.SetActive(true);
            }
        }
    }
}
