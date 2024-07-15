using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    Vector3 dir;

    Animator anim;
    CharacterController cc;

    public AudioClip footstep;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 캐릭터가 지면에 있는 경우
        if (cc.isGrounded)
        {
            float h = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x; // 좌우 이동
            float v = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y; // 앞뒤 이동

            dir = new Vector3(h, 0, v) * speed;

            if (dir.magnitude > 0.1f)
            {
                // 진행 방향으로 캐릭터 회전
                float targetAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, targetAngle, 0);
                anim.SetBool("isWalk", true);
            }
            else
            {
                anim.SetBool("isWalk", false);
            }

            // 점프 처리
            if (OVRInput.GetDown(OVRInput.Button.Three)) // Oculus Quest의 경우 OVRInput.Button.Two은 버튼 'X'에 해당
            {
                dir.y = 7.5f; // 점프 높이
                anim.SetBool("isJump",true); // 점프 애니메이션 
                
            }
            else
            {
                anim.SetBool("isJump", false);
            }
        }

        dir.y += Physics.gravity.y * Time.deltaTime;
        cc.Move(dir * Time.deltaTime);
    }

    void FootStep()
    {
        AudioSource.PlayClipAtPoint(footstep, Camera.main.transform.position);
    }
}
