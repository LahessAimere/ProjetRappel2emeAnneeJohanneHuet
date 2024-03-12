using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour, ISerializable<PlayerScoreDTO>
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    private int _score = 0;

    public void UpdateScore(int score)
    {
        _score += score;
        string scoreString = score.ToString();
        _scoreText.text = scoreString;
    }
    
    public void Deserialize(PlayerScoreDTO dataTransferObject)
    {
        _score = dataTransferObject.Score;
    }

    public PlayerScoreDTO Serialized()
    {
        return new PlayerScoreDTO()
        {
            Score = _score
        };
    }
}
