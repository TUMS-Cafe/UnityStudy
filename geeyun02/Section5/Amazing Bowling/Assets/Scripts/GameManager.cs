using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UnityEvent onReset;
    public static GameManager instance;

    public GameObject readyPanel;

    /*
    public Text scoreText;
    public Text bestScoreText;
    public Text messageText;
    */

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI messageText;

    public bool isRoundActive = false;

    private int score = 0;

    public ShooterRotator shooterRotator;
    public CamFollow cam;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        UpdateUI();
    }

    void Start()
    {
        StartCoroutine("RoundRoutine");
    }

    void Update()
    {
        //내가 따로 추가한 코드 - esc를 누르면 종료
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateBestScore();
        UpdateUI();
    }

    void UpdateBestScore()
    {
        if (GetBestScore() < score)
        {
            PlayerPrefs.SetInt("BestScore", score); //점수가 최고 점수보다 높으면 새로 저장
        }
    }

    int GetBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        return bestScore;
    }

    //점수 갱신 함수
    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        bestScoreText.text = "Best Score: " + GetBestScore();
    }

    //폭발 시 라운드 끝났다는 사실 명시를 위한 함수
    public void OnBallDestroy()
    {
        UpdateUI();
        isRoundActive = false;
    }

    //재시작
    public void Reset()
    {
        score = 0;
        UpdateUI();

        //라운드를 다시 처음부터 시작(코루틴)
        StartCoroutine("RoundRoutine");
    }

    IEnumerator RoundRoutine()
    {
        //Ready
        onReset.Invoke(); //event 발동

        readyPanel.SetActive(true);
        cam.SetTarget(shooterRotator.transform, CamFollow.State.Idle);
        shooterRotator.enabled = false;
        isRoundActive = false;
        messageText.text = "Ready...";

        yield return new WaitForSeconds(3f);

        //Play
        isRoundActive = true;
        readyPanel.SetActive(false);
        shooterRotator.enabled = true;
        cam.SetTarget(shooterRotator.transform, CamFollow.State.Ready);

        //무한루프
        while (isRoundActive == true)
        {
            yield return null;
        }

        //End
        readyPanel.SetActive(true);
        shooterRotator.enabled = false;
        messageText.text = "Wait For Next Round...";

        yield return new WaitForSeconds(3f);
        Reset();
    }
}
