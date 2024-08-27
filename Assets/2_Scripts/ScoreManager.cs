using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public void init()
    {
        instance = this;
        StartCoroutine(DecScoreCar());
    }

    private IEnumerator DecScoreCar()
    {
        while (true)
        {

            if (ScoredataList.Count > 0)
            {
                ScoreData data = ScoredataList[0];

                Score scoreobj = Instantiate<Score>(BaseScore);
                scoreobj.transform.position = data.pos;
                scoreobj.Active(data.str, data.color);

                ScoredataList.RemoveAt(0);

                yield return new WaitForSeconds(DataBaseManager.Instance.ScorePopInterval);
            }
            else
            {
                yield return null;
            }
        }

    }


    private struct ScoreData
    {
        public string str;
        public Color color;
        public Vector2 pos;
    }

    private List<ScoreData> ScoredataList = new List<ScoreData>();

    [SerializeField] private TextMeshProUGUI ScoreTmp;
    [SerializeField] private TextMeshProUGUI bonusTmp;

    [SerializeField] private Score BaseScore;

    private int tortalScore;
    private float tortalbonus;

    public void addScore(int score, Vector2 ScorePos)
    {
        //�ִϸ��̼�
        ScoredataList.Add(new ScoreData()
        {
            str = score.ToString(),
            color = DataBaseManager.Instance.Scorecolor,
            pos = ScorePos
        });

        //ĵ����
        tortalScore += score;
        ScoreTmp.text = tortalScore.ToString();

    }

    internal void addBouns(float bounsValue, Vector2 position)
    {
        //�ִϸ��̼�
        ScoredataList.Add(new ScoreData()
        {
            str = "Bonus " + bounsValue.toPersentString(),
            color = DataBaseManager.Instance.bonuscolor,
            pos = position
        });

        //ĵ����
        tortalbonus += bounsValue;
        bonusTmp.text = tortalbonus.toPersentString();
    }

    internal void ResetBouns()
    {
        tortalbonus = 0;
        bonusTmp.text = tortalbonus.toPersentString();
    }
}