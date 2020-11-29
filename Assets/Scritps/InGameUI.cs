using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text scoreText;
    public static InGameUI instance;


    int humanScore = 0;
    int cpuScore = 0;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public void CPUGetScore()
    {
        cpuScore++;
        UpdateScore();
    }

    public void HumanScore()
    {
        humanScore++;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = humanScore + ":" + cpuScore;
    }
}
