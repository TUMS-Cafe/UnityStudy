using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카멜 명명법 : 클래스와 함수 이름은 첫글자 대문자, 변수 이름은 첫글자 소문자, 새로운 단어가 나오면 대문자로 구별
public class Player : MonoBehaviour
{
    public GameManager gameManager;

    //접근 지시자 : 클래스 내부 변수는 암묵적으로 private, 밖에서 사용하려면 public 선언 필요
    public float speed = 10f;
    private Rigidbody playerRigidbody;

    //게임이 처음 시작되었을 때 한번 실행
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    //화면이 한번 깜빡일 때 한번 실행
    //영화 1초 24프레임, 모바일 1초 30프레임, pc 1초 60프레임, 콘솔게임 1초 30프레임
    //1초에 대략 60번 단, 사양에 따라 다르며 몇 번 실행되는지는 정해져 있지 않다
    void Update()
    {
        /*
        //getkey를 사용한 유저 입력
        //불편사항 1.키가 바뀌면 코드 일일히 수정해야함, 2.상하좌우를 네가지로 나눠서 일일히 적어야함
        if (Input.GetKey(KeyCode.W)) //앞
        {
            playerRigidbody.AddForce(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.A)) //왼
        {
            playerRigidbody.AddForce(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S)) //뒤
        {
            playerRigidbody.AddForce(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.D)) //오
        {
            playerRigidbody.AddForce(speed, 0, 0);
        }
        */

        //게임 오버 상태이면 종료
        if (gameManager.isGameOver == true)
        {
            return;
        }

        //getaxis를 사용한 유저입력
        //키보드 커스터마이제이션 가능 ex)발사 기능="Fire"=마우스 오른쪽 버튼, 앉는 기능="Crunch"=키보드 C, 점프기능="Jump"=키보드 F
        //-1 ~ +1사이의 값을 사용하여 조이스틱에도 대응 가능, 미는 강도에 따라 구현 가능 ex)-1(<-, A)    0    +1(->, D)
        float inputX = Input.GetAxis("Horizontal"); //키보드 수평방향에 대응되는 키 지정 <-, ->, A, D
        float inputZ = Input.GetAxis("Vertical"); //키보드 수직방향에 대응되는 키 지정 ↑, ↓, W, S
        float fallSpeed = playerRigidbody.velocity.y; //중력 유지를 위해 원래 떨어지던 속도를 변수로 저장

        //AddForce : 내부에서 속도가 계산이 되어 관성의 영향 받게됨
        //playerRigidbody.AddForce(inputX * speed, 0, inputZ * speed);

        //velocity : 속도 바로 지정
        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity = velocity * speed; //벡터 각각의 요소에 속도를 곱해줌
        velocity.y = fallSpeed;
        //Vector3(inputX * speed, fallSpeed, inputZ * speed);
        playerRigidbody.velocity = velocity;
    }
}
