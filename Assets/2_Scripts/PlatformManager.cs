using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
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
    internal void Init()
    {
        PlatformArrDic.Add(0, DataBaseManager.Instance.SmallPlatformArr);
        PlatformArrDic.Add(1, DataBaseManager.Instance.MiddlePlatformArr);
        PlatformArrDic.Add(2, DataBaseManager.Instance.LargePlatformArr);
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
                platformNum++;
            }
        }
    }

    private void ActiveOne( int platformID)
    {
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomPlatform = platforms[randID];
        Platform platform = Instantiate(randomPlatform);

        bool isfirstPlatform = platformNum == 0;

        if (isfirstPlatform == false)
            SpwonPos = SpwonPos + Vector3.right * platform.GetHallSizeX;

        platform.Active(SpwonPos, isfirstPlatform);

        float gap = Random.Range(DataBaseManager.Instance.GetIntevalMin, DataBaseManager.Instance.GetIntevalmax);
        SpwonPos = SpwonPos + Vector3.right * platform.GetHallSizeX * gap;
        return;
    }
}
