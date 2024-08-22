using System;
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
    [SerializeField] private Score BaseScore;

    private int tortalScore;

    public void addScore(int score, Vector2 ScorePos)
    {
        Score scoreObject = Instantiate(BaseScore);
        scoreObject.transform.position = ScorePos;
        scoreObject.Active(score);

        tortalScore += score;
        ScoreTmp.text = tortalScore.ToString();

    }

    internal void addBouns(float bounsValue, Vector3 position)
    {
        //throw new NotImplementedException();
    }

    internal void ResetBouns()
    {
        //throw new NotImplementedException();
    }
}