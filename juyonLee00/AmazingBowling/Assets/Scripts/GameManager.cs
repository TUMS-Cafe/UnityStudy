using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //발동하는 순간 인스펙터에 설정한 모든 이벤트함수가 자동으로 실행 .
    public UnityEvent OnReset;

    public static GameManager instance;

    public GameObject readyPanel;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI bestScoreText;

    public TextMeshProUGUI messageText;

    public bool isRoundActive = false;

    private int score = 0;

    public ShooterRotator shooterRotator;
    public CamFollow cam;

    private void Awake()
    {
        instance = this;
        UpdateUI();
    }

    private void Start()
    {
        StartCoroutine("RoundRoutine");
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateBestScore();
        UpdateUI();
    }

    void UpdateBestScore()
    {
        if(GetBestScore() < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        
    }

    int GetBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        return bestScore;
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        bestScoreText.text = "BestScore : " + GetBestScore();
    }

    //볼이 게임 매니저로 들어가서 발동
    public void OnBallDestroy()
    {
        UpdateUI();
        isRoundActive = false;
    }

    public void Reset()
    {
        score = 0;
        UpdateUI();

        //라운드 초기화
        StartCoroutine("RoundRoutine");
    }

    //페이지 사이 대기 시간 삽입을 위해 코루틴 사용 
    IEnumerator RoundRoutine()
    {
        //Ready
        //등록된 이벤트들이 자동으로 발동 .
        OnReset.Invoke();

        readyPanel.SetActive(true);
        cam.SetTarget(shooterRotator.transform, CamFollow.State.Idle);
        //대기상태는 조작을 하지 않도록 설정
        shooterRotator.enabled = false;

        isRoundActive = false;
        messageText.text = "Ready..";

        yield return new WaitForSeconds(3f);

        //Play 무한 루프 - 볼이 닿아 터질 때까지는 끝나지 않음
        isRoundActive = true;
        readyPanel.SetActive(false);
        shooterRotator.enabled = true; //onEnabled에서 설정해놨으므로 자동으로 설정됨.

        //줌인으로 설정되어서 처음에 플레이어 좀 크게 보이게
        cam.SetTarget(shooterRotator.transform, CamFollow.State.Ready);

        while(isRoundActive == true)
        {
            yield return null;
        }

        readyPanel.SetActive(true);
        shooterRotator.enabled = false;

        messageText.text = "Wait For Next Round..";

        //End

        yield return new WaitForSeconds(3f);
        Reset();

    }
}
