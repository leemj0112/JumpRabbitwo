using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public void Active(Vector2 pos)
    {
        transform.position = pos + new Vector2 (-0.2f, 0.4f);
    }

    public void CallAnim()
    {
        Destroy(gameObject);
    }
}
