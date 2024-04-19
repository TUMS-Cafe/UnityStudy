using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public enum State
    {
        Idle,
        Ready,
        Tracking
    }

    //밖에선 변수 , 안에서 보면 함수인 property 이용.
    private State state
    {
        //property
        set
        {
            //value = Awake에서 전달된 값 (State.Idle)을 조건에 맞게 처리
            //밖은 변수처럼 사용해 처리를 간결하게 보이기 위함.
            switch(value)
            {
                case State.Idle:
                    targetZoomSize = roundReadyZoomSize;
                    break;
                case State.Ready:
                    targetZoomSize = readyShotZoomSize;
                    break;
                case State.Tracking:
                    targetZoomSize = trackingZoomSize;
                    break;
            }
        }
    }

    private Transform target;

    //지연 시간 필요 - 해당 위치로 바로 이동하는 게 아니라 시간을 들여서 값을 바꿔줘서 자연스럽게 이동하도록 설정.
    private float smoothTime = 0.2f;

    private Vector3 lastMovingVelocity;
    private Vector3 targetPosition;

    private Camera cam;
    private float targetZoomSize = 5f;

    private const float roundReadyZoomSize = 14.5f;
    private const float readyShotZoomSize = 5f;
    private const float trackingZoomSize = 10f;

    //마지막에 값이 얼마나 변경되었는지 알아야 SmoothDamping 사용해서 해결 가능.
    private float lastZoomSpeed;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        state = State.Idle;
    }

    private void Move()
    {
        targetPosition = target.transform.position;

        //현재 위치 , 가고 싶은  곳 , 마지막 순간의 속도 , 지연 시간 ,
        //속도 담을 임시 컨테이너 .  마지막 순간에 값을 부드럽게 바꾸고 값을 어떻게 갱신했는지 확인.
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref lastMovingVelocity, smoothTime);
            
        transform.position = targetPosition;
    }

    //현재 줌 사이즈에서 원하는 줌 사이즈까지 지연시간 줘서 부드럽게 
    private void Zoom()
    {
        float smoothZoomSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoomSize, ref lastZoomSpeed, smoothTime);

        cam.orthographicSize = smoothZoomSize;
    }

    //시간 간격 일정해서 정확한 처리 요구할 때 사용 .
    private void FixedUpdate()
    {
        if(target != null)
        {
            Move();
            Zoom();
        }
    }

    public void Reset()
    {
        state = State.Idle;
    }

    public void SetTarget(Transform newTarget, State newState)
    {
        target = newTarget;
        state = newState;
    }
}
