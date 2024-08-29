using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D call;
    [SerializeField] private int score;

    public int Score => score;

    public float GetHallSizeX => call.size.x * 0.5f;

    private void Awake()
    {
        call = GetComponentInChildren<BoxCollider2D>();
    }


    public void Active(Vector2 pos)
    {
        transform.position = pos;

        if (Random.value < DataBaseManager.Instance.ItemSpwanper)
        {
            Item item = Instantiate<Item>(DataBaseManager.Instance.BaseItem);
            item.Active(transform.position, GetHallSizeX);
        }


    }

    internal void OnLanding()
    {
        ScoreManager.instance.addScore(score, transform.position);
    }
}
