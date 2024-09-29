using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject audioPanel;
    private bool activePanel = false;
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


}
