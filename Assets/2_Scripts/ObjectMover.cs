using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{

    void Update()
    {
        // �� �����Ӹ��� ���� õõ�� �̵�
        transform.position += Vector3.up * DataBaseManager.Instance.moveSpeed * Time.deltaTime;
    }
}
