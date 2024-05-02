using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        //FadeIn();
        StartCoroutine(FadeIn());

        //string으로 호출시키면 나중에 인위적으로 멈출 수 있음
        //StartCoroutine("FadeIn");
    }

    /*
    void FadeIn()
    {
        Color startColor = fadeImage.color;

        for(int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a = 0.01f;
            fadeImage.color = startColor;
        }
    }
    */

    IEnumerator FadeIn()
    {
        Color startColor = fadeImage.color;

        for (int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a = 0.01f;
            fadeImage.color = startColor;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
