using TMPro;
using UnityEngine;

public class ScoreEnd : MonoBehaviour
{
    public TextMeshProUGUI Myscore;
    public TextMeshProUGUI BestScore;
    private void Update()
    {
        Myscore.text = "�÷��� ����: " + DataBaseManager.Instance.tortalScore.ToString();
        BestScore.text = "�ְ� ����: " + DataBaseManager.Instance.BesrScore.ToString();
    }
}
