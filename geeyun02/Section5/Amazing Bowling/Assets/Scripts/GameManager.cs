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
        //���� ���� �߰��� �ڵ� - esc�� ������ ����
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
            PlayerPrefs.SetInt("BestScore", score); //������ �ְ� �������� ������ ���� ����
        }
    }

    int GetBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        return bestScore;
    }

    //���� ���� �Լ�
    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        bestScoreText.text = "Best Score: " + GetBestScore();
    }

    //���� �� ���� �����ٴ� ��� ��ø� ���� �Լ�
    public void OnBallDestroy()
    {
        UpdateUI();
        isRoundActive = false;
    }

    //�����
    public void Reset()
    {
        score = 0;
        UpdateUI();

        //���带 �ٽ� ó������ ����(�ڷ�ƾ)
        StartCoroutine("RoundRoutine");
    }

    IEnumerator RoundRoutine()
    {
        //Ready
        onReset.Invoke(); //event �ߵ�

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

        //���ѷ���
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
