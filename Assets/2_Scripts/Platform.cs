using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D call;
    [SerializeField] private int score;

    private Animation anim;

    public int Score => score;
    public int numder;
    public float GetHallSizeX => call.size.x * 0.5f;
    private void Awake()
    {
        call = GetComponentInChildren<BoxCollider2D>();
        anim = GetComponent<Animation>();
    }
    public void Active(Vector2 pos, int platformNum)
    {
        transform.position = pos;
        numder = platformNum;

        if(platformNum == 1)
        {
            return;
        }

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

        internal void OnLandingAnimation()
    {
        anim.Play();
    }

}
