using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompt : MonoBehaviour {

    private Text promTxt;
    private float timer = 0f;
    private float interval = 1f;
    private bool isFading = false;
    private Vector4 clor;

    private void Awake()
    {
        promTxt = GetComponent<Text>();
        clor = promTxt.color;
    }

    public void Fade()
    {
        if (isFading)
        {
            timer = 0f;
        }
        else
        {
            StartCoroutine(FadeFunc());
        }
    }

    IEnumerator FadeFunc()
    {
        isFading = true;      
        
        while (true)
        {
            yield return null;
            timer += Time.deltaTime;
            promTxt.color = new Vector4(promTxt.color.r, promTxt.color.g, promTxt.color.b, Mathf.Lerp(interval, 0, timer));
            if (timer > interval)
            {
                break;
            }
        }
        gameObject.SetActive(false);
        promTxt.color = clor;
        isFading = false;
        timer = 0f;
    }
}
