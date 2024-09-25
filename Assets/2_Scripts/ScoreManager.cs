using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public void init()
    {
        instance = this;
    }

    public void Active()
    {
        StartCoroutine(DecScoreCar());

        ScoreTmp.text = DataBaseManager.Instance.tortalScore.ToString();
        bonusTmp.text = DataBaseManager.Instance.tortalbonus.ToString();
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

    public void addScore(int score, Vector2 ScorePos, bool IsCallBonus = true)
    {
        //애니메이션
        ScoredataList.Add(new ScoreData()
        {
            str = score.ToString(),
            color = DataBaseManager.Instance.Scorecolor,
            pos = ScorePos
        });

        //캔버스
        DataBaseManager.Instance.tortalScore += score;
        ScoreTmp.text = DataBaseManager.Instance.tortalScore.ToString();

        if (IsCallBonus)
        {
            int bonusSocre = (int)(score * DataBaseManager.Instance.tortalbonus);
            if(bonusSocre > 0)
            {
            addScore(bonusSocre, ScorePos, false);
            }
        }

    }

    internal void addBouns(float bounsValue, Vector2 position)
    {
        //애니메이션
        ScoredataList.Add(new ScoreData()
        {
            str = "보너스 " + bounsValue.toPersentString(),
            color = DataBaseManager.Instance.bonuscolor,
            pos = position
        });

        //캔버스
        DataBaseManager.Instance.tortalbonus += bounsValue;
        bonusTmp.text = DataBaseManager.Instance.tortalbonus.toPersentString();
    }

    internal void ResetBouns(Vector2 BonusPos)
    {
        DataBaseManager.Instance.tortalbonus = 0;
        bonusTmp.text = DataBaseManager.Instance.tortalbonus.toPersentString();

        //애니메이션
        ScoredataList.Add(new ScoreData()
        {
            str = "보너스 리셋",
            color = DataBaseManager.Instance.Scorecolor,
            pos = BonusPos
        }) ;
    }
}