using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D call;

    public float GetHallSizeX()
    {
        return call.size.x * 0.5f;
    }
    private void Awake()
    {
        call = GetComponentInChildren <BoxCollider2D>();
    }


    public void Active(Vector2 pos)
    {
        transform.position = pos;
        Debug.Log($"Platform Name:{gameObject.name}, transform.pos:{transform.position}, pos:{pos}");
    }
}
