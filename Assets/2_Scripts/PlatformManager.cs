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

    //ÀüÃ¼ ÀÌµ¿, ½ºÆù Á¦¿Ü
    [SerializeField] private Transform spawnPosTrf;
    private Vector3 SpwonPos;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();
    private int platformNum = 0;
    public int LandingPlatformNum;
    internal void Init()
    {
        instance = this;
        PlatformArrDic.Add(0, DataBaseManager.Instance.SmallPlatformArr);
        PlatformArrDic.Add(1, DataBaseManager.Instance.MiddlePlatformArr);
        PlatformArrDic.Add(2, DataBaseManager.Instance.LargePlatformArr);
    }

    private void Update()
    {
        if(platformNum - LandingPlatformNum < DataBaseManager.Instance.RemainPlatformCount) 
            // ÇöÀç »ý¼ºµÈ ÇÃ·§Æû - ·£µùÇÑ ÇÃ·§Æû ¹øÈ£ < ÇÃ·§Æû Â÷ÀÌ¶ó¸é
        {
            int lastIndex = DataBaseManager.Instance.DataArr.Length -1;
            Data Lastdata = DataBaseManager.Instance.DataArr[lastIndex];

            for (int i = 0; i < Lastdata.GroupCount; i++)
            {
                int platformID =Lastdata.GetPlatformID();
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
            SpwonPos = SpwonPos + Vector3.right * platform.GetHallSizeX;

        platform.Active(SpwonPos, platformNum);

        float gap = Random.Range(DataBaseManager.Instance.GetIntevalMin, DataBaseManager.Instance.GetIntevalmax);
        SpwonPos = SpwonPos + Vector3.right * platform.GetHallSizeX * gap;
        return;
    }
}
