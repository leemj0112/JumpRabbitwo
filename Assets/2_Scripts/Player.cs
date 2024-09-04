using UnityEngine;

public class Player : MonoBehaviour
{
    private float JumpPower = 0;

    private Rigidbody2D rigd;
    private Animator anim;

    private Platform landPlatform;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Init()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("StateID", 1);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            JumpPower += DataBaseManager.Instance.JumpPowerIncrede;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rigd.AddForce(Vector2.one * JumpPower);
            JumpPower = 0;

            anim.SetInteger("StateID", 2);

            Define.SFXType sFXType = Random.value < 0.5f ? Define.SFXType.Jump1 : Define.SFXType.Jump2;
            SoundManager.instance.PlaySfx(sFXType);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigd.velocity = Vector2.zero;
        anim.SetInteger("StateID", 0);
        CamaraManager.Instance.OnFollow(transform.position);

        if (collision.transform.TryGetComponent(out Platform platform))

            platform.OnLandingAnimation();

            ScoreManager.instance.addScore(platform.Score, platform.transform.position);

        if (landPlatform != platform)
        {
            //º¸³Ê½º
            ScoreManager.instance.addBouns(DataBaseManager.Instance.BounsValue, transform.position);
        }
        else ScoreManager.instance.ResetBouns(transform.position);
            landPlatform = platform;
    }
}
