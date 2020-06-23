using UnityEngine;
using UnityEngine.UI;

public class SoccerBallController : MonoBehaviour
{
    [HideInInspector]
    public SoccerFieldArea area;
    public string purpleGoalTag; //will be used to check if collided with purple goal
    public string blueGoalTag; //will be used to check if collided with blue goal
    private GeneralScore scoreCounter;

    void Awake()
    {
        scoreCounter = GameObject.Find("Canvas").GetComponent<GeneralScore>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(purpleGoalTag)) //ball touched purple goal
        {
            area.GoalTouched(AgentSoccer.Team.Blue);
            scoreCounter.GoalTouched(AgentSoccer.Team.Blue);
        }
        if (col.gameObject.CompareTag(blueGoalTag)) //ball touched blue goal
        {
            area.GoalTouched(AgentSoccer.Team.Red);
            scoreCounter.GoalTouched(AgentSoccer.Team.Red);
        }
    }
}
