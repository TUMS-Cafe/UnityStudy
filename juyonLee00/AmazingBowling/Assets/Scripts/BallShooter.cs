using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallShooter : MonoBehaviour
{
    //볼 쏘면 볼로 카메라 트래킹 대상 변환되도록 설정 
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

    //컴포넌트 켜질 때마다 매번 실행. 라운드 넘길 때마다 초기화하기 때문.
    //라운드 넘어갈 때마다 껐다가 키기.
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

    //누를 때 충전, 떼면 발사
    private void Update()
    {
        if(fired == true)
        {
            return;
        }

        powerSlider.value = minForce;


        if (currentForce >= maxForce && !fired)
        {
            currentForce = maxForce;
            Fire();
        }
        //힘이 최대힘 이상일 때

        else if (Input.GetButtonDown("Fire1"))
        {
            //이렇게 하면 연사 가능
            //fired = false;
            currentForce = minForce;

            shootingAudio.clip = chargingClip;
            shootingAudio.Play();
        }
        //이제 버튼 누른 순간

        else if (Input.GetButton("Fire1") && !fired)
        {
            currentForce = currentForce + chargeSpeed * Time.deltaTime;

            powerSlider.value = currentForce;
        }
        //누르고 있는 순간

        else if(Input.GetButtonUp("Fire1") && !fired)
        {
            Fire();
        }
    }

    private void Fire()
    {
        fired = true;

        Rigidbody ballInstance = Instantiate(ball, firePos.position, firePos.rotation);

        ballInstance.velocity = currentForce * firePos.forward;
        //transform의 앞쪽

        shootingAudio.clip = fireClip;
        shootingAudio.Play();
        currentForce = minForce;

        cam.SetTarget(ballInstance.transform, CamFollow.State.Tracking);
        //버그 : 날아가서 바닥에 닿지 않을 경우 계속 카메라가 따라가서 원래대로 위치 복구 불가 .
    }
}
