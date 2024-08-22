using System;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Platform : MonoBehaviour
{
    private BoxCollider2D call;
    [SerializeField] private int score;

    public int Score => score;

    public float GetHallSizeX()
    {
        return call.size.x * 0.5f;
    }
    private void Awake()
    {
        call = GetComponentInChildren <BoxCollider2D>();
    }


    public void Active(Vector2 pos)
    {
        transform.position = pos;
    }

    internal void OnLanding()
    {
        ScoreManager.instance.addScore(score, transform.position );
    }
}
