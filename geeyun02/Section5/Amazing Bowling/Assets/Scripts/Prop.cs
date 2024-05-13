using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public int score = 5;
    public ParticleSystem explosionParticle;
    public float hp = 10f;

    public void TakeDamage(float damage)
    {
        //hp = hp - damage;
        hp -= damage;

        if (hp <= 0)
        {
            //원본을 새로 하나 복사한 인스턴스 생성. Instantiate(오브젝트, 위치, 회전)
            ParticleSystem instance = Instantiate(explosionParticle,transform.position,transform.rotation);

            AudioSource explosionAudio = instance.GetComponent<AudioSource>();
            explosionAudio.Play();

            //사라지기 전 게임 매니저의 점수 추가 함수 발동
            GameManager.instance.AddScore(score);

            Destroy(instance.gameObject, instance.duration); //파티클 지연 시간 후에 스스로 파괴
            gameObject.SetActive(false); //prop은 아예 파괴하는게 아니라 비활성해서 나중에 재사용하도록 함
        }
    }
}
