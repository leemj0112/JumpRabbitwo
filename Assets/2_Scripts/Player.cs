using UnityEngine;

public class Player : MonoBehaviour
{
    private float JumpPower = 0;
    private bool isJumpReady = false;

    private Rigidbody2D rigd;
    private Animator anim;

    private Platform landPlatform;

    private float MoveSpeed = 5f;
    private float h;
    private bool isFacingRight = true;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Init()
    {

    }
    private void Flip()
    {
        // ��������Ʈ�� ������Ŵ (X�� ũ�⸦ ������ ����)
        isFacingRight = !isFacingRight;  // ���� ���¸� ����

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;  // X���� ������Ŵ
        transform.localScale = scaler;
    }

    private void Update()
    {
        //�̵�
        h = Input.GetAxisRaw("Horizontal");
        rigd.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigd.velocity.x > MoveSpeed)
        {
            rigd.velocity = new Vector2(MoveSpeed, rigd.velocity.y); //������
        }
        else if (rigd.velocity.x < MoveSpeed * -1)
        {
            rigd.velocity = new Vector2(MoveSpeed * -1, rigd.velocity.y); //����
        }

        if (h > 0 && !isFacingRight) // ���������� �̵� ���ε� ������ ���� �ִٸ�
        {
            Flip();  // �������� ������ ��������Ʈ ����
        }
        else if (h < 0 && isFacingRight) // �������� �̵� ���ε� �������� ���� �ִٸ�
        {
            Flip();  // ������ ������ ��������Ʈ ����
        }


        //����
        if (isJumpReady == false)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //������ ����
            {
                isJumpReady = true;
                anim.SetInteger("StateID", 1);

            }
        }
        else
        {
            JumpPower += DataBaseManager.Instance.JumpPowerIncrede * Time.deltaTime;
            rigd.velocity = new Vector2(0, rigd.velocity.y); //�ӵ� ���߱�

            if (JumpPower > DataBaseManager.Instance.maxJumPower)
            {
                SetIdleState();
            }

            if (Input.GetKeyUp(KeyCode.Space))//���� ����
            {
                h = Input.GetAxisRaw("Horizontal"); //�ӵ� �ǵ�����
                rigd.AddForce(Vector2.right * h, ForceMode2D.Impulse);

                isJumpReady = false;
                if (JumpPower < DataBaseManager.Instance.minJumPower) //�ּ� ���� �Ŀ��� �� �Ѿ��� ��
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
                    effect.Active(transform.position); //�䳢 ��ġ�� ����
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
            //���ʽ�
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

