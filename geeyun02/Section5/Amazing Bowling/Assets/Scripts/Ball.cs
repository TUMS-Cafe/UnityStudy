using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LayerMask whatIsProp;

    public ParticleSystem explosionParticle;
    public AudioSource explosionAudio;

    //주변에 입힐 수 있는 최대 데미지
    public float maxDamage = 100f;
    //폭발 반경에 입힐 데미지의 힘
    public float explosionForce = 1000f;
    //파괴가 안될 경우 스스로 파괴하는데 걸리는 시간
    public float lifeTime = 10f;
    //폭발 반경
    public float explosionRadius = 20f;

    void Start()
    {
        Destroy(gameObject, lifeTime); //지연 시간만큼 기다렸다가 스스로 파괴 
    }

    //trigger에 충돌이 감지되면 오브젝트 파괴
    private void OnTriggerEnter(Collider other)
    {
        //가상의 구를 그려서 겹치는 콜라이더들 중 Prop 레이어를 가지는 콜라이더를 모두 반환
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsProp);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius); //자동으로 계산해서 폭발 효과 재생

            Prop targetProp = colliders[i].GetComponent<Prop>();
            float damage = CalculateDamage(colliders[i].transform.position);
            targetProp.TakeDamage(damage);
        }

        //일시적으로 파티클의 부모(볼)을 해제하여 파티클이 볼과 함께 사라지지 않도록 함
        explosionParticle.transform.parent = null;

        //파티클 애니메이션과 오디오를 재생함
        explosionParticle.Play();
        explosionAudio.Play();

        //파괴되기 전 게임 매니저의 함수 발동시켜서 라운드 종료 알리기
        GameManager.instance.OnBallDestroy();

        Destroy(explosionParticle.gameObject, explosionParticle.duration); //파티클의 지연 시간이 지나면 스스로 파괴 
        Destroy(gameObject); //볼 파괴
    }

    //폭발 반경에서 떨어진 거리에 따라 차등 데미지 계산. 원 안쪽에 있을수록(반지름에서 해당 위치의 거리를 뺀 값이 클수록) 큰 데미지
    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position; //현재 위치에서 상대방까지의 방향과 거리 벡터 계산

        float distance = explosionToTarget.magnitude; //벡터의 거리 값 계산
        float edgeToCenterDistance = explosionRadius - distance; //반지름에서 거리를 빼서 반경에서 얼마나 떨어져 있는지 계산
        float percentage = edgeToCenterDistance / explosionRadius; //반지름에서 떨어진 거리 비율을 계산
        float damage = maxDamage * percentage;

        //콜라이더는 반경에 겹쳐있지만 중심이 반경 밖이라서 데미지 비율이 음수가 되는 경우 방지
        //Mathf.Max는 최댓값 반환. 즉 데미지가 양수면 데미지값으로, 음수면 0으로 처리
        damage = Mathf.Max(0, damage);

        return damage;
    }
}
