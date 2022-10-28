using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _scoreText;
    public void OnGameOver(int score)
    {
        _scoreText.SetText($"Score: {score}");
    }
}
