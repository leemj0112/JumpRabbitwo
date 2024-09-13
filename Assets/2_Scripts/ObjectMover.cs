using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{

    void Update()
    {
        // 매 프레임마다 위로 천천히 이동
        transform.position += Vector3.up * DataBaseManager.Instance.moveSpeed * Time.deltaTime;
    }
}
