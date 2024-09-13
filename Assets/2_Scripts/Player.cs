using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float JumpPower = 0;
    private bool isJumpReady = false;

    private Rigidbody2D rigd;
    private Animator anim;

    private Platform landPlatform;

    private float h;
    private bool isFacingRight = true;

    public Slider jumpPowerSlider;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        // 슬라이더의 최대값을 점프 파워의 최대값으로 설정
        jumpPowerSlider.maxValue = DataBaseManager.Instance.maxJumPower;
        jumpPowerSlider.value = 0; // 초기값을 0으로 설정
    }

    public void Init()
    {

    }
    private void Flip()
    {
        // 스프라이트를 반전시킴 (X축 크기를 음수로 변경)
        isFacingRight = !isFacingRight;  // 방향 상태를 반전

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;  // X축을 반전시킴
        transform.localScale = scaler;
    }

    private void Update()
    {
        //이동
        h = Input.GetAxisRaw("Horizontal");
        rigd.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigd.velocity.x > DataBaseManager.Instance.MoveSpeed)
        {
            rigd.velocity = new Vector2(DataBaseManager.Instance.MoveSpeed, rigd.velocity.y); //오른쪽
        }
        else if (rigd.velocity.x < DataBaseManager.Instance.MoveSpeed * -1)
        {
            rigd.velocity = new Vector2(DataBaseManager.Instance.MoveSpeed * -1, rigd.velocity.y); //왼쪽
        }

        if (h > 0 && !isFacingRight) // 오른쪽으로 이동 중인데 왼쪽을 보고 있다면
        {
            Flip();  // 오른쪽을 보도록 스프라이트 반전
        }
        else if (h < 0 && isFacingRight) // 왼쪽으로 이동 중인데 오른쪽을 보고 있다면
        {
            Flip();  // 왼쪽을 보도록 스프라이트 반전
        }


        //점프
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
            rigd.velocity = new Vector2(0, rigd.velocity.y); //속도 멈추기

            jumpPowerSlider.value = JumpPower;

            if (JumpPower > DataBaseManager.Instance.maxJumPower)
            {
                SetIdleState();
            }

            if (Input.GetKeyUp(KeyCode.Space))//떼는 순간
            {
                h = Input.GetAxisRaw("Horizontal"); //속도 되돌리기
                rigd.AddForce(Vector2.right * h, ForceMode2D.Impulse);

                isJumpReady = false;
                if (JumpPower < DataBaseManager.Instance.minJumPower) //최소 점프 파워를 못 넘었을 시
                {
                    SetIdleState();
                }
                else
                {
                    rigd.AddForce(Vector2.up * JumpPower);
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
        // CamaraManager.Instance.OnFollow(transform.position);

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

