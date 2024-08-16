using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public int GroupCount;
    }

    [SerializeField] private Transform spawnPosTrf;
    [SerializeField] private Platform[] LargePlatformArr;
    [SerializeField] private Platform[] MiddlePlatformArr;
    [SerializeField] private Platform[] SmallPlatformArr;
    [SerializeField] private Data[] DataArr;
    private int platformNum = 0;

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
            while(platformNum < platformGroupSum)
            {
                pos = ActiveOne(pos);
                platformNum++;
            }
        }
    }

    private Vector3 ActiveOne(Vector3 pos)
    {
        Platform[] platforms = PlatformArrDic[2];

        int randID = Random.Range(0, platforms.Length);
        Platform randomPlatform = platforms[randID];

        Platform platform = Instantiate(randomPlatform);
        platform.Active(pos);
        Debug.Log($"Active pos: {pos}");

        pos = pos + Vector3.right * 6;
        return pos;
    }
}
