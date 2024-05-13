using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LayerMask whatIsProp;

    public ParticleSystem explosionParticle;
    public AudioSource explosionAudio;

    //�ֺ��� ���� �� �ִ� �ִ� ������
    public float maxDamage = 100f;
    //���� �ݰ濡 ���� �������� ��
    public float explosionForce = 1000f;
    //�ı��� �ȵ� ��� ������ �ı��ϴµ� �ɸ��� �ð�
    public float lifeTime = 10f;
    //���� �ݰ�
    public float explosionRadius = 20f;

    void Start()
    {
        Destroy(gameObject, lifeTime); //���� �ð���ŭ ��ٷȴٰ� ������ �ı� 
    }

    //trigger�� �浹�� �����Ǹ� ������Ʈ �ı�
    private void OnTriggerEnter(Collider other)
    {
        //������ ���� �׷��� ��ġ�� �ݶ��̴��� �� Prop ���̾ ������ �ݶ��̴��� ��� ��ȯ
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsProp);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius); //�ڵ����� ����ؼ� ���� ȿ�� ���

            Prop targetProp = colliders[i].GetComponent<Prop>();
            float damage = CalculateDamage(colliders[i].transform.position);
            targetProp.TakeDamage(damage);
        }

        //�Ͻ������� ��ƼŬ�� �θ�(��)�� �����Ͽ� ��ƼŬ�� ���� �Բ� ������� �ʵ��� ��
        explosionParticle.transform.parent = null;

        //��ƼŬ �ִϸ��̼ǰ� ������� �����
        explosionParticle.Play();
        explosionAudio.Play();

        //�ı��Ǳ� �� ���� �Ŵ����� �Լ� �ߵ����Ѽ� ���� ���� �˸���
        GameManager.instance.OnBallDestroy();

        Destroy(explosionParticle.gameObject, explosionParticle.duration); //��ƼŬ�� ���� �ð��� ������ ������ �ı� 
        Destroy(gameObject); //�� �ı�
    }

    //���� �ݰ濡�� ������ �Ÿ��� ���� ���� ������ ���. �� ���ʿ� ��������(���������� �ش� ��ġ�� �Ÿ��� �� ���� Ŭ����) ū ������
    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position; //���� ��ġ���� ��������� ����� �Ÿ� ���� ���

        float distance = explosionToTarget.magnitude; //������ �Ÿ� �� ���
        float edgeToCenterDistance = explosionRadius - distance; //���������� �Ÿ��� ���� �ݰ濡�� �󸶳� ������ �ִ��� ���
        float percentage = edgeToCenterDistance / explosionRadius; //���������� ������ �Ÿ� ������ ���
        float damage = maxDamage * percentage;

        //�ݶ��̴��� �ݰ濡 ���������� �߽��� �ݰ� ���̶� ������ ������ ������ �Ǵ� ��� ����
        //Mathf.Max�� �ִ� ��ȯ. �� �������� ����� ������������, ������ 0���� ó��
        damage = Mathf.Max(0, damage);

        return damage;
    }
}
