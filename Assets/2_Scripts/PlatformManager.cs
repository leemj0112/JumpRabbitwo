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

    //��ü �̵�, ���� ����
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
                plag = Instantiate(DataBaseManager.Instance.plag); //��ġ�� ����ڳ�
                plag.transform.position = topPlatform.transform.position; //���� ���� �÷����� ��� ����
            }
            return; // �� �̻� �������� ����
        }

        if (platformNum - LandingPlatformNum < DataBaseManager.Instance.RemainPlatformCount)
        // ���� ������ �÷��� - ������ �÷��� ��ȣ < �÷��� ���̶��
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
            float XOffset = 5.0f; //�¿� �̵� ����
            if (platformNum % 2 == 0)
            {
                SpwonPos.x += XOffset; //¦�� �÷����� ��� X���� ���������� �̵�
            }
            else
            {
                SpwonPos.x -= XOffset; //Ȧ�� �÷����� ��� X���� �������� �̵�
            }

            // Y���� ����ؼ� �ö�
            float yOffset = 1.0f; // ���� �ö󰡴� ����
            SpwonPos.y += yOffset; // Y������ ��� ���
        }

        platform.Active(SpwonPos, platformNum);
        topPlatform = platform;

        float gap = Random.Range(DataBaseManager.Instance.GetIntevalMin, DataBaseManager.Instance.GetIntevalmax);
        SpwonPos = SpwonPos + Vector3.up * gap; // �߰������� Y�� ������ ������ �� ����������

        return;
    }
}
