using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public UnityEvent<int> OnNewScoreReached = new UnityEvent<int>();
    public UnityEvent<int> OnGameOverWithScore = new UnityEvent<int>();
    int score = 0;
    public void OnNewHeightReached(float newHeight)
    {
        score = Mathf.FloorToInt(newHeight);
        OnNewScoreReached.Invoke(score);
    }
    public void OnGameOver()
    {
        OnGameOverWithScore.Invoke(score);
    }

    public void OnRestart()
    {
        score = 0;
        OnNewScoreReached.Invoke(score);
    }

}
