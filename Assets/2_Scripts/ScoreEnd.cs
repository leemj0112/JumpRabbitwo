using TMPro;
using UnityEngine;

public class ScoreEnd : MonoBehaviour
{
    public TextMeshProUGUI Myscore;
    public TextMeshProUGUI BestScore;
    private void Update()
    {
        Myscore.text = "플레이 점수: " + DataBaseManager.Instance.tortalScore.ToString();
        BestScore.text = "최고 점수: " + DataBaseManager.Instance.BesrScore.ToString();
    }
}
