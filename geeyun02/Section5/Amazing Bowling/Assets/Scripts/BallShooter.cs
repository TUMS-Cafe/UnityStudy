using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallShooter : MonoBehaviour
{
    public CamFollow cam;

    public Rigidbody ball;
    public Transform firePos;
    public Slider powerSlider;

    public AudioSource shootingAudio;
    public AudioClip fireClip;
    public AudioClip chargingClip;

    public float minForce = 15f;
    public float maxForce = 30f;
    public float chargingTime = 0.75f;

    private float currentForce;
    private float chargeSpeed;
    private bool fired;

    //자동으로 한번 실행됨, 초기화 미리 해둘 수 있음
    private void OnEnable()
    {
        currentForce = minForce;
        powerSlider.value = minForce;
        fired = false;
    }

    private void Start()
    {
        chargeSpeed = (maxForce - minForce) / chargingTime;
    }

    private void Update()
    {
        //한번 발사되면 더이상 발사하지 않음
        if (fired == true)
        {
            return;
        }

        powerSlider.value = minForce;

        //현재 힘이 최대 힘을 넘어가고 아직 발사가 안된 경우 - 최대 힘으로 설정하고 강제 발사 처리
        if(currentForce>=maxForce && !fired)
        {
            currentForce = maxForce;
            //발사 처리
            Fire();
        }
        //발사 버튼을 누른 경우 - 힘을 충전할 준비
        else if (Input.GetButtonDown("Fire1"))
        {
            //fired = false;를 추가하면 연사 가능

            currentForce = minForce;

            //충전 오디오로 변경해서 재생
            shootingAudio.clip = chargingClip;
            shootingAudio.Play();
        }
        //발사 버튼을 누르고 있는 동안 - 힘 충전
        else if (Input.GetButton("Fire1") && !fired)
        {
            currentForce = currentForce + chargeSpeed * Time.deltaTime;
            powerSlider.value = currentForce;
        }
        //버튼에서 손을 뗀 순간 - 발사
        else if (Input.GetButtonUp("Fire1") && !fired)
        {
            //발사처리
            Fire();
        }
    }

    //발사처리 함수
    private void Fire()
    {
        fired = true;
        //볼 인스턴스 찍어내기
        Rigidbody ballInstance = Instantiate(ball, firePos.position, firePos.rotation);
        //forward로 앞쪽 방향의 값을 vector3로 받아냄
        ballInstance.velocity = currentForce * firePos.forward;

        //발사 오디오로 변경해서 재생
        shootingAudio.clip = fireClip;
        shootingAudio.Play();

        currentForce = minForce;

        //카메라 추적 대상을 포탄으로 변경
        cam.SetTarget(ballInstance.transform, CamFollow.State.Tracking);
    }
}
