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

    //�ڵ����� �ѹ� �����, �ʱ�ȭ �̸� �ص� �� ����
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
        //�ѹ� �߻�Ǹ� ���̻� �߻����� ����
        if (fired == true)
        {
            return;
        }

        powerSlider.value = minForce;

        //���� ���� �ִ� ���� �Ѿ�� ���� �߻簡 �ȵ� ��� - �ִ� ������ �����ϰ� ���� �߻� ó��
        if(currentForce>=maxForce && !fired)
        {
            currentForce = maxForce;
            //�߻� ó��
            Fire();
        }
        //�߻� ��ư�� ���� ��� - ���� ������ �غ�
        else if (Input.GetButtonDown("Fire1"))
        {
            //fired = false;�� �߰��ϸ� ���� ����

            currentForce = minForce;

            //���� ������� �����ؼ� ���
            shootingAudio.clip = chargingClip;
            shootingAudio.Play();
        }
        //�߻� ��ư�� ������ �ִ� ���� - �� ����
        else if (Input.GetButton("Fire1") && !fired)
        {
            currentForce = currentForce + chargeSpeed * Time.deltaTime;
            powerSlider.value = currentForce;
        }
        //��ư���� ���� �� ���� - �߻�
        else if (Input.GetButtonUp("Fire1") && !fired)
        {
            //�߻�ó��
            Fire();
        }
    }

    //�߻�ó�� �Լ�
    private void Fire()
    {
        fired = true;
        //�� �ν��Ͻ� ����
        Rigidbody ballInstance = Instantiate(ball, firePos.position, firePos.rotation);
        //forward�� ���� ������ ���� vector3�� �޾Ƴ�
        ballInstance.velocity = currentForce * firePos.forward;

        //�߻� ������� �����ؼ� ���
        shootingAudio.clip = fireClip;
        shootingAudio.Play();

        currentForce = minForce;

        //ī�޶� ���� ����� ��ź���� ����
        cam.SetTarget(ballInstance.transform, CamFollow.State.Tracking);
    }
}
