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



    [SerializeField] private Transform spawnPosTrf;
    [SerializeField] private Platform[] LargePlatformArr;
    [SerializeField] private Platform[] MiddlePlatformArr;
    [SerializeField] private Platform[] SmallPlatformArr;
    [SerializeField] private Data[] DataArr;
    private int platformNum = 0;

    [SerializeField] private float GetIntevalMin = 1.0f;
    [SerializeField] private float GetIntevalmax = 2.0f;
    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();

    internal void Init()
    {
        PlatformArrDic.Add(0, SmallPlatformArr);
        PlatformArrDic.Add(1, MiddlePlatformArr);
        PlatformArrDic.Add(2, LargePlatformArr);
    }

    internal void Active()
    {
        Vector3 pos = spawnPosTrf.position;

        int platformGroupSum = 0;
        foreach (Data data in DataArr)
        {
            platformGroupSum += data.GroupCount;
            Debug.Log($"platformGroupSum: {platformGroupSum} ======== ");
            while (platformNum < platformGroupSum)
            {
                int platformID = data.GetPlatformID();
                pos = ActiveOne(pos, platformID);
                platformNum++;
            }
        }
    }

    private Vector3 ActiveOne(Vector3 pos, int platformID)
    {
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomPlatform = platforms[randID];
        Platform platform = Instantiate(randomPlatform);

        if (platformNum != 0)
            pos = pos + Vector3.right * platform.GetHallSizeX();

        platform.Active(pos);

        float gap = Random.Range(GetIntevalMin, GetIntevalmax);
        pos = pos + Vector3.right * platform.GetHallSizeX() * gap;
        return pos;
    }
}
