using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int NumOfHeart;

    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    private void Update()
    {
        if(health > NumOfHeart)
        {
            health = NumOfHeart;
        }

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < health)
            {
                Hearts[i].sprite = FullHeart;
            }
            else
            {
                Hearts[i].sprite = EmptyHeart;
            }

            if (i < NumOfHeart)
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
