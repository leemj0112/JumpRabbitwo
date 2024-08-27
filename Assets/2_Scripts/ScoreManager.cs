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
    [SerializeField] private TextMeshProUGUI bonusTmp;

    [SerializeField] private Score BaseScore;

    private int tortalScore;
    private float tortalbonus;

    public void addScore(int score, Vector2 ScorePos)
    {
        Score scoreObject = Instantiate(BaseScore);
        scoreObject.transform.position = ScorePos;
        scoreObject.Active(score.ToString(), DataBaseManager.Instance.Scorecolor);

        tortalScore += score;
        ScoreTmp.text = tortalScore.ToString();

    }

    internal void addBouns(float bounsValue, Vector2 position)
    {
        Score scoreObject = Instantiate(BaseScore);
        scoreObject.transform.position = position;

        string str = "Bonus " + bounsValue.toPersentString();
        scoreObject.Active(str, DataBaseManager.Instance.bonuscolor);

        tortalbonus += bounsValue;
        bonusTmp.text = tortalbonus.toPersentString();
    }

    internal void ResetBouns()
    {
        tortalbonus = 0;
        bonusTmp.text = tortalbonus.toPersentString();
    }
}