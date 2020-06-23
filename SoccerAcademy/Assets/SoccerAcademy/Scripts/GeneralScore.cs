using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralScore : MonoBehaviour
{
    private ulong scoreBlue = 0;
    private ulong scoreRed = 0;
    public Text textBlue;
    public Text textRed;

    void Awake()
    {
        textBlue.text = scoreBlue.ToString();
        textRed.text = scoreRed.ToString();
    }

    public void GoalTouched(AgentSoccer.Team team) {

        if (team.Equals(AgentSoccer.Team.Blue))
        {
            scoreBlue += 1;
            textBlue.text = scoreBlue.ToString();
        }
        else {
            scoreRed += 1;
            textRed.text = scoreRed.ToString();
        }

        if (scoreBlue == ulong.MaxValue)
        {
            scoreBlue = 0;
        }
        if (scoreRed == ulong.MaxValue)
        {
            scoreRed = 0;
        }
    }
}
