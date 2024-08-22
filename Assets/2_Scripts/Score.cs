using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshPro TMP;
    private void Awake()
    {
        TMP = GetComponentInChildren<TextMeshPro>();
    }

    public void Active(int score)
    {
        TMP.text = score.ToString();
    }
    public void Deactive()
    {
        Destroy(gameObject);
    }
}
