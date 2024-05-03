using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // �̵� �ӵ� ������ ����

    void Update()
    {
        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

            // �̵� ���� ����
            Vector3 moveDirection = new Vector3(thumbstick.x, 0f, thumbstick.y).normalized;

            // Duck �̵�
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
