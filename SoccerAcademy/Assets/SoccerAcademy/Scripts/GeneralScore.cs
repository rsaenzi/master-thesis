using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralScore : MonoBehaviour
{
    private ulong scoreBlue = 0;
    private ulong scoreRed = 0;
    private Text textBlue;
    private Text textRed;

    void Awake()
    {
        textBlue = this.transform.Find("ScoreBlue").GetComponent<Text>();
        textRed  = this.transform.Find("ScoreRed").GetComponent<Text>();

        if (textBlue != null)
        {
            textBlue.text = scoreBlue.ToString();
        }
        if (textRed != null)
        {
            textRed.text = scoreRed.ToString();
        }
    }

    public void GoalTouched(AgentSoccer.Team team) {

        if (team.Equals(AgentSoccer.Team.Blue))
        {
            scoreBlue += 1;
            if (scoreBlue == ulong.MaxValue)
            {
                scoreBlue = 0;
            }

            if (textBlue != null)
            {
                textBlue.text = scoreBlue.ToString();
            }
        }
        else {

            scoreRed += 1;
            if (scoreRed == ulong.MaxValue)
            {
                scoreRed = 0;
            }

            if (textRed != null)
            {
                textRed.text = scoreRed.ToString();
            }
        }
    }
}
