using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public int score = 5;

    //파괴될 때 가져와서 찍어냄. 미리 갖고 있는 게 x  
    public ParticleSystem explosionParticle;

    public float hp = 10f;

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            //Instantiate에서 위치 / 회전 설정 없으면 임의의 위치 or 원점에 생성.
            ParticleSystem instance = Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(instance.gameObject, instance.duration);

            AudioSource explosionAudio = instance.GetComponent<AudioSource>();
            explosionAudio.Play();

            //Instantiate - Destroy를 하면 CPU에 무리가 가므로 재활용할 예정.
            gameObject.SetActive(false);
        }
    }
}