using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도 조절용 변수
    //public float rotationSpeed = 720f; // 회전 속도 조절용 변수
    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Debug.Log("Thumbstick Input: " + thumbstick);

        // 이동 방향 설정
        Vector3 moveDirection = new Vector3(thumbstick.x, 0f, thumbstick.y);

        // 이동 벡터의 길이가 0.1보다 크면 이동 (대각선 이동 포함)
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            // 각 방향에 대한 이동 처리
            Vector3 direction = Vector3.zero;

            if (thumbstick.x > 0.1f) // 오른쪽 입력 (직진)
            {
                direction += Vector3.forward;
            }
            else if (thumbstick.x < -0.1f) // 왼쪽 입력 (후진)
            {
                direction += Vector3.back;
            }

            if (thumbstick.y > 0.1f) // 위쪽 입력 (왼쪽으로 이동)
            {
                direction += Vector3.left;
            }
            else if (thumbstick.y < -0.1f) // 아래쪽 입력 (오른쪽으로 이동)
            {
                direction += Vector3.right;
            }

            // 오브젝트 이동
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

            // 오브젝트 회전
            //Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
    }
}
