using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도 조절용 변수

    void Update()
    {
        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

            // 이동 방향 설정
            Vector3 moveDirection = new Vector3(thumbstick.x, 0f, thumbstick.y).normalized;

            // Duck 이동
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
