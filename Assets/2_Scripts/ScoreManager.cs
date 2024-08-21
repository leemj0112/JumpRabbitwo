using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public void init()
    {
        instance = this;
    }

    [SerializeField] private TextMeshProUGUI ScoreTmp;
    private int tortalScore;

    public void addScore(int score)
    {
        tortalScore += score;
        ScoreTmp.text = tortalScore.ToString();
    }
}