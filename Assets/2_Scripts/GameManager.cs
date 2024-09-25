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
        SceneManager.LoadScene(0); //게임 씬 다시 불러오기
        DataBaseManager.Instance.health = 3;
        ResumeGame();
    }

    private void Awake()
    {
        Instance = this;
        //순서중요
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
        DataBaseManager.Instance.health = 3; //체력 초기화
        DataBaseManager.Instance.tortalScore = 0; //점수 초기화
    }

    public void OnGameOver()
    {
        ReBtn.SetActive(true);
    }

    public void PauseGame()
    {
        // 게임 내 모든 물리적 움직임 멈추기
        Time.timeScale = 0f;

        // UI는 멈추지 않도록 설정하기 (필요 시 추가적인 로직)
        // 예: 버튼 클릭 등 UI 이벤트 처리
    }

    public void ResumeGame()
    {
        // 게임을 다시 정상적으로 재개하기
        Time.timeScale = 1f;
    }
}
