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

    public void Active(string scoreTxt, Color color)
    {
        TMP.text = scoreTxt.ToString();
        TMP.color = color;
    }
    public void Deactive()
    {
        Destroy(gameObject);
    }
}
