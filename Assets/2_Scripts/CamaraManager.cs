using System.Collections;
using UnityEngine;

public class CamaraManager : MonoBehaviour
{
    [SerializeField] private float folSpeed = 5;
    public static CamaraManager Instance;

    public void init()
    {
        Instance = this;
    }

    public void OnFollow(Vector2 transTarget)
    {
        StartCoroutine(OnFollowCar(transTarget));
    }

    public IEnumerator OnFollowCar(Vector2 transTarget)
    {
        while (0.1f < Vector3.Distance(transform.position, transTarget))
        {
            transform.position = Vector3.Lerp(transform.position, transTarget, Time.deltaTime * folSpeed);
            yield return null;
        }
    }
}
