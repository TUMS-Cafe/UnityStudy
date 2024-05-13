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
            //�⺻���� input�� fire1���� ���� ctrl, ���콺 ���� ��ư�� �Ҵ��
            if (Input.GetButtonDown("Fire1"))
            {
                state = RotateState.Horizontal; //ó�� ��ư�� ������ '����'���� ����������� �ٲ�
            }
        }
        else if (state == RotateState.Horizontal)
        {
            if (Input.GetButton("Fire1"))
            {
                transform.Rotate(new Vector3(0, horizontalRotateSpeed * Time.deltaTime, 0)); //��ư ������ �ִ� '����'���� ����(y��)�������� ȸ��
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                state = RotateState.Vertical; //��ư�� ���� '����'���� ������������ �ٲ�
            }
        }
        else if (state == RotateState.Vertical)
        {
            if (Input.GetButton("Fire1"))
            {
                transform.Rotate(new Vector3(-verticalRotateSpeed * Time.deltaTime, 0, 0)); //��ư ������ �ִ� '����'���� ����(x��)�������� ȸ��
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                state = RotateState.Ready; //��ư�� ���� '����'���� �߻� �غ� ���·� �ٲ�
                ballShooter.enabled = true; //ball shooter ��ũ��Ʈ Ȱ��ȭ
            }
        }

        /*
        //switch���� ����� �ڵ�
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
                    ballShooter.enabled = true; //ball shooter ��ũ��Ʈ Ȱ��ȭ
                }
                break;
            case RotateState.Ready:
                break;
        }
        */
    }

    //�ٽ� ���۵� ������ �ʱ�ȭ
    private void OnEnable()
    {
        transform.rotation = Quaternion.identity; //identity�� 0,0,0�� ȸ���� ����
        state = RotateState.Idle;
        ballShooter.enabled = false;
    }
}
