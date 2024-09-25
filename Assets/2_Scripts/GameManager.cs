using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Player player;
    [SerializeField] private CamaraManager CamaraManager;
    [SerializeField] private DataBaseManager dataBaseManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private Health health;
    [SerializeField] private GameObject ReBtn;


    public void CallBtnRetry()
    {
        SceneManager.LoadScene(0); //���� �� �ٽ� �ҷ�����
        DataBaseManager.Instance.health = 3;
        ResumeGame();
    }

    private void Awake()
    {
        Instance = this;
        //�����߿�
        dataBaseManager.init();
        player.Init();
        platformManager.Init();
        CamaraManager.init();
        scoreManager.init();
        soundManager.init();
        health.init();
    }

    private void Start()
    {
        platformManager.Active();
        scoreManager.Active();
        soundManager.PlayBgm(Define.BgmType.Main);
        DataBaseManager.Instance.health = 3; //ü�� �ʱ�ȭ
        DataBaseManager.Instance.tortalScore = 0; //���� �ʱ�ȭ
    }

    public void OnGameOver()
    {
        ReBtn.SetActive(true);
    }

    public void PauseGame()
    {
        // ���� �� ��� ������ ������ ���߱�
        Time.timeScale = 0f;

        // UI�� ������ �ʵ��� �����ϱ� (�ʿ� �� �߰����� ����)
        // ��: ��ư Ŭ�� �� UI �̺�Ʈ ó��
    }

    public void ResumeGame()
    {
        // ������ �ٽ� ���������� �簳�ϱ�
        Time.timeScale = 1f;
    }
}
