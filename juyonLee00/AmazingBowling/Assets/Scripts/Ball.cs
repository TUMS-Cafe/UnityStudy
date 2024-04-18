using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LayerMask whatIsProp;

    public ParticleSystem explosionParticle;

    public AudioSource explosionAudio;

    public float maxDamage = 100f;
    //주변 물건이 반경 안에 있으면 튕겨나감
    public float explosionForce = 1000f;

    //물체가 밖으로 나갔을 경우 대비 
    public float lifeTime = 10f;

    public float explosionRadius = 20f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);        
    }

    private void OnTriggerEnter(Collider other)
    {
        //가상의 구 그림 .구의 중심과 반지름 그리면 거기 겹치는 모든 콜라이더 배열로 가져와줌. 레이어마스크 걸면 필터링 가능/
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsProp);

        
        for(int i=0; i<colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            //폭발 위치와 반경, 튕겨나가는 힘 매개변수로 받아 알아서 튕겨나감 - rigidbody
            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            Prop targetProp = colliders[i].GetComponent<Prop>();

            float damage = CalculateDamage(colliders[i].transform.position);

            targetProp.TakeDamage(damage);
        }

        explosionParticle.transform.parent = null;
        //파티클 부모가 없어지면 파티클 해제되면서 정상적으로 재생.
        explosionParticle.Play();
        explosionAudio.Play();

        //특수효과 다 재생 후 파괴되게 하기 위함.
        Destroy(explosionParticle.gameObject, explosionParticle.duration);
        Destroy(gameObject);
    }

    //폭발 중심에 가까울수록 데미지 커짐. (0~100)
    //원 중앙으로 갈수록 데미지가 더 커지므로 바깥점을 기준으로 얼마나 안쪽에 존재하는지 계산하는게 편함 
    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionTarget = targetPosition - transform.position;

        //벡터의 크기 
        float distance = explosionTarget.magnitude;

        float edgeToCenterDistance = explosionRadius - distance;

        float percentage = edgeToCenterDistance / explosionRadius;

        float damage = maxDamage * percentage;

        //콜라이더 부피로 인해 해당 반경과 겹쳐서 체력 회복되는 문제 해결
        damage = Mathf.Max(0, damage);

        return damage;
    }
}
