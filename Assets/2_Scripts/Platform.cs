using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public void Active(Vector2 pos)
    {
        transform.position = pos;
        Debug.Log($"Platform Name:{gameObject.name}, transform.pos:{transform.position}, pos:{pos}");
    }
}
