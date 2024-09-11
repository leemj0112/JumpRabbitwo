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
            // X축 위치 갱신
            SpwonPos = SpwonPos + Vector3.right * platform.GetHallSizeX;

            // Y축 높이 증가 (예: 0.5 ~ 1.5 사이 랜덤 값)
            float heightIncrease = Random.Range(0.5f, 1.5f);
            SpwonPos.y += heightIncrease;  // Y축으로 위치 상승
        }

        platform.Active(SpwonPos, platformNum);

        float gap = Random.Range(DataBaseManager.Instance.GetIntevalMin, DataBaseManager.Instance.GetIntevalmax);
        SpwonPos = SpwonPos + Vector3.right * platform.GetHallSizeX * gap;

        return;
    }
}
