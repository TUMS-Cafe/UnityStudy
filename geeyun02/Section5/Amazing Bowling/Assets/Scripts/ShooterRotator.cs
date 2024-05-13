using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotator : MonoBehaviour
{
    private enum RotateState
    {
        Idle, Vertical, Horizontal, Ready
    }

    private RotateState state = RotateState.Idle;

    public float verticalRotateSpeed = 360f;
    public float horizontalRotateSpeed = 360f;

    public BallShooter ballShooter;

    void Update()
    {
        if (state == RotateState.Idle)
        {
            //기본으로 input의 fire1에는 왼쪽 ctrl, 마우스 왼쪽 버튼이 할당됨
            if (Input.GetButtonDown("Fire1"))
            {
                state = RotateState.Horizontal; //처음 버튼을 누르는 '순간'에는 수평방향으로 바뀜
            }
        }
        else if (state == RotateState.Horizontal)
        {
            if (Input.GetButton("Fire1"))
            {
                transform.Rotate(new Vector3(0, horizontalRotateSpeed * Time.deltaTime, 0)); //버튼 누르고 있는 '동안'에는 수평(y축)방향으로 회전
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                state = RotateState.Vertical; //버튼을 떼는 '순간'에는 수직방향으로 바뀜
            }
        }
        else if (state == RotateState.Vertical)
        {
            if (Input.GetButton("Fire1"))
            {
                transform.Rotate(new Vector3(-verticalRotateSpeed * Time.deltaTime, 0, 0)); //버튼 누르고 있는 '동안'에는 수직(x축)방향으로 회전
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                state = RotateState.Ready; //버튼을 떼는 '순간'에는 발사 준비 상태로 바뀜
                ballShooter.enabled = true; //ball shooter 스크립트 활성화
            }
        }

        /*
        //switch문을 사용한 코드
        switch (state)
        {
            case RotateState.Idle:
                if (Input.GetButtonDown("Fire1"))
                {
                    state = RotateState.Horizontal;
                }
                break;
            case RotateState.Horizontal:
                if (Input.GetButton("Fire1"))
                {
                    transform.Rotate(new Vector3(0, horizontalRotateSpeed * Time.deltaTime, 0));
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    state = RotateState.Vertical;
                }
                break;
            case RotateState.Vertical:
                if (Input.GetButton("Fire1"))
                {
                    transform.Rotate(new Vector3(-verticalRotateSpeed * Time.deltaTime, 0, 0));
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    state = RotateState.Ready;
                    ballShooter.enabled = true; //ball shooter 스크립트 활성화
                }
                break;
            case RotateState.Ready:
                break;
        }
        */
    }

    //다시 시작될 때마다 초기화
    private void OnEnable()
    {
        transform.rotation = Quaternion.identity; //identity는 0,0,0도 회전한 상태
        state = RotateState.Idle;
        ballShooter.enabled = false;
    }
}
