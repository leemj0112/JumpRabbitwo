using System.Collections;
using UnityEngine;

public class CamaraManager : MonoBehaviour
{
    public static CamaraManager Instance;

    float camerawhight;

    [SerializeField] private SpriteRenderer BG;

    public void init()
    {
        Instance = this;
        Camera Main = Camera.main;
        float cameraright = Main.orthographicSize / 2;
        camerawhight = cameraright * Main.aspect;
    }

    public void OnFollow(Vector2 transTarget)
    {
        StartCoroutine(OnFollowCar(transTarget));
    }

    public IEnumerator OnFollowCar(Vector2 transTarget)
    {
        while (0.1f < Vector3.Distance(transform.position, transTarget))
        {
            transform.position = Vector3.Lerp(transform.position, transTarget, Time.deltaTime * DataBaseManager.Instance.folSpeed);

            float BGrightX = BG.transform.position.x + BG.size.x; //배경화면의 오른쪽 값을 구하기
            float camerarightX = Camera.main.transform.position.x + camerawhight / 2; //카메라의 오른쪽 값 구하기

            if (BGrightX <= camerarightX)
            {
                BG.size = new Vector2(BG.size.x + camerawhight * 2, BG.size.y);//BG크기 늘리기 (카메라 X값 * 2)
            }

            yield return null;
        }
    }
}
