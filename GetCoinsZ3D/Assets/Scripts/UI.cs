using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void SetScoreText(int score)
    {
        _scoreText.text = score.ToString();
    }
}
