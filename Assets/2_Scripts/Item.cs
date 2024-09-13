using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Animation Anim;

    private void Start()
    {
        //Anim.Play();
        Debug.Log("anim play");
    }
    
    public void Active(Vector2 pos, float halfsixeX)
    {
        transform.position = pos + new Vector2(Random.Range(-halfsixeX, halfsixeX), 1.4f); //당근위치 랜덤 생성
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent(out Player player))
        {
            ScoreManager.instance.addBouns(DataBaseManager.Instance.ItemBOnus, transform.position);
            Destroy(gameObject);
        }
    }
}
