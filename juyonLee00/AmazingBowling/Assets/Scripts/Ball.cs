using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
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
        explosionParticle.transform.parent = null;
        //파티클 부모가 없어지면 파티클 해제되면서 정상적으로 재생.
        explosionParticle.Play();
        explosionAudio.Play();

        //특수효과 다 재생 후 파괴되게 하기 위함.
        Destroy(explosionParticle.gameObject, explosionParticle.duration);
        Destroy(gameObject);
    }
}
