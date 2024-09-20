using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] Hearts;


    internal void init()
    {

    }

    private void Update()
    {
        if(DataBaseManager.Instance.health > DataBaseManager.Instance.NumOfHeart)
        {
            DataBaseManager.Instance.health = DataBaseManager.Instance.NumOfHeart;
        }

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < DataBaseManager.Instance.health)
            {
                Hearts[i].sprite = DataBaseManager.Instance.FullHeart;
            }
            else
            {
                Hearts[i].sprite = DataBaseManager.Instance.EmptyHeart;
            }

            if (i < DataBaseManager.Instance.NumOfHeart)
            {
                Hearts[i].enabled = true; 
            }
            else
            {
                Hearts[i].enabled = false;
            }

        }
    }
}
