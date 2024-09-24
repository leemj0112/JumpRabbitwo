using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance;

    [System.Serializable]
    public class Data
    {
        public int GroupCount;
        [SerializeField] private float LargePercent;
        [SerializeField] private float MiddlePercent;
        [SerializeField] private float SmallPercent;

        public int GetPlatformID()
        {
            float randNal = Random.value;
            int PlatformID;
            if (randNal <= LargePercent)
            {
                PlatformID = 2;
            }
            else if (randNal <= LargePercent + MiddlePercent)
            {
                PlatformID = 1;
            }
            else
            {
                PlatformID = 0;
            }
            return PlatformID;
        }
    }

    //전체 이동, 스폰 제외
    [SerializeField] private Transform spawnPosTrf;
    private Vector3 SpwonPos;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();
    private int platformNum = 0;
    public int LandingPlatformNum;
    Plag plag;
    Platform topPlatform;

    bool rightUpPlatfrom = true;
    internal void Init()
    {
        instance = this;
        PlatformArrDic.Add(0, DataBaseManager.Instance.SmallPlatformArr);
        PlatformArrDic.Add(1, DataBaseManager.Instance.MiddlePlatformArr);
        PlatformArrDic.Add(2, DataBaseManager.Instance.LargePlatformArr);
    }

    private void Update()
    {
        if (platformNum >= 10)
        {
            if (plag == null)
            {
                plag = Instantiate(DataBaseManager.Instance.plag); //위치를 못잡겠네
                plag.transform.position = topPlatform.transform.position; //제일 높은 플랫폼에 깃발 생성
            }
            return; // 더 이상 생성하지 않음
        }

        if (platformNum - LandingPlatformNum < DataBaseManager.Instance.RemainPlatformCount)
        // 현재 생성된 플랫폼 - 랜딩한 플랫폼 번호 < 플랫폼 차이라면
        {
            int lastIndex = DataBaseManager.Instance.DataArr.Length - 1;
            Data Lastdata = DataBaseManager.Instance.DataArr[lastIndex];

            for (int i = 0; i < Lastdata.GroupCount; i++)
            {
                int platformID = Lastdata.GetPlatformID();
                ActiveOne(platformID);
            }
        }

    }

    public void PlagSpwan()
    {

    }

    internal void Active()
    {
        SpwonPos = spawnPosTrf.position;

        int platformGroupSum = 0;
        foreach (Data data in DataBaseManager.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;
            while (platformNum < platformGroupSum)
            {
                int platformID = data.GetPlatformID();
                ActiveOne(platformID);
            }
        }
    }

    private void ActiveOne(int platformID)
    {
        platformNum++;
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomPlatform = platforms[randID];

        Platform platform = Instantiate(randomPlatform);

        if (platformNum > 1)
        {
            float XOffset = 5.0f; //좌우 이동 간격
            if (platformNum % 2 == 0)
            {
                SpwonPos.x += XOffset; //짝수 플랫폼일 경우 X축을 오른쪽으로 이동
            }
            else
            {
                SpwonPos.x -= XOffset; //홀수 플랫폼일 경우 X축을 왼쪽으로 이동
            }

            // Y축은 계속해서 올라감
            float yOffset = 1.0f; // 위로 올라가는 간격
            SpwonPos.y += yOffset; // Y축으로 계속 상승
        }

        platform.Active(SpwonPos, platformNum);
        topPlatform = platform;

        float gap = Random.Range(DataBaseManager.Instance.GetIntevalMin, DataBaseManager.Instance.GetIntevalmax);
        SpwonPos = SpwonPos + Vector3.up * gap; // 추가적으로 Y축 간격을 적용해 더 벌어지도록

        return;
    }
}
