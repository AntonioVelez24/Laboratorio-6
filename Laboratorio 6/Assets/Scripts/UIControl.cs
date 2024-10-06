using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] private GameObject audioPanel;
    [SerializeField] private Image fadePanel;
    [SerializeField] private float fadeTime = 0.5f;
    private bool activePanel = false;
    private void Awake()
    {
        fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, 0);
    }
    public void SetAudioPanel()
    {
        if (activePanel == false)
        {
            activePanel = true;
            audioPanel.SetActive(true);
        }
        else
        {
            activePanel = false;
            audioPanel.SetActive(false);
        }
    }
    private IEnumerator Fade()
    {
        Color c = fadePanel.color;
        for (float alpha = 0f; alpha <= 1; alpha += 0.5f)
        {
            c.a = alpha;
            fadePanel.color = c;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(fadeTime);
        for (float alpha = 1f; alpha >= 0; alpha -= 0.2f) 
        {
            c.a = alpha;
            fadePanel.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
