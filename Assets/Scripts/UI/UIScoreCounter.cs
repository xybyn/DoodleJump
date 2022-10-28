using UnityEngine;

public class UIScoreCounter : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _scoreText;
    public void OnNewScore(int newScore)
    {
        _scoreText.SetText($"Score: {newScore}");
    }
}
