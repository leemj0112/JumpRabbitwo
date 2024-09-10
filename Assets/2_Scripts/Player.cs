using UnityEngine;

public class Player : MonoBehaviour
{
    private float JumpPower = 0;
    private bool isJumpReady = false;

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
        if (isJumpReady == false)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //누르는 순간
            {
                isJumpReady = true;
                anim.SetInteger("StateID", 1);
            }
        }
        else
        {
            JumpPower += DataBaseManager.Instance.JumpPowerIncrede * Time.deltaTime;
            if(JumpPower > DataBaseManager.Instance.maxJumPower) 
            {
                SetIdleState();
            }

            if (Input.GetKeyUp(KeyCode.Space))//떼는 순간
            {
                isJumpReady = false;
                if (JumpPower < DataBaseManager.Instance.minJumPower) //최소 점프 파워를 못 넘었을 시
                {
                    SetIdleState();
                }
                else
                {
                    rigd.AddForce(Vector2.one * JumpPower);
                    JumpPower = 0;

                    anim.SetInteger("StateID", 2);

                    Define.SFXType sFXType = Random.value < 0.5f ? Define.SFXType.Jump1 : Define.SFXType.Jump2;
                    SoundManager.instance.PlaySfx(sFXType);

                    Effect effect = Instantiate(DataBaseManager.Instance.landingEff);
                    effect.Active(transform.position); //토끼 위치에 생성
                }
            }
        }

        if (transform.position.y < DataBaseManager.Instance.GameOverY)
        {
            GameManager.Instance.OnGameOver();
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetIdleState();
        CamaraManager.Instance.OnFollow(transform.position);

        if (collision.transform.TryGetComponent(out Platform platform))
            PlatformManager.instance.LandingPlatformNum = platform.numder;

        platform.OnLandingAnimation();

        if (landPlatform == null)
        {
            landPlatform = platform;
            return;
        }

        ScoreManager.instance.addScore(platform.Score, platform.transform.position);

        if (landPlatform != platform)
        {
            //보너스
            ScoreManager.instance.addBouns(DataBaseManager.Instance.BounsValue, transform.position);
        }
        else ScoreManager.instance.ResetBouns(transform.position);
        landPlatform = platform;
    }

    private void SetIdleState()
    {
        rigd.velocity = Vector2.zero;
        anim.SetInteger("StateID", 0);
        JumpPower = 0;
        isJumpReady = false;
    }
}

