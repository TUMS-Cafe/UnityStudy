using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        /*
        //쿼터니언 (x,y,z,w)
        Quaternion newRotation = Quaternion.Euler(new Vector3(45, 60, 90));
        //LookRotation : 특정 방향을 바라보도록 회전 ex) (0,1,0)->y축(위)를 바라봄
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(0, 1, 0));

        //상대 위치 벡터에서 내 위치 벡터를 빼면 거리/방향이 나옴
        Vector3 direction = targetTransform.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        */

        /*
         Quaternion aRotation = Quaternion.Euler(new Vector3(30, 0, 0));
        Quaternion bRotation = Quaternion.Euler(new Vector3(60, 0, 0));

        //A   |   B
        //0  0.5  1
        Quaternion targetRotation = Quaternion.Lerp(aRotation, bRotation, 0.5f);

        transform.rotation = targetRotation;
         */

        /*
        Quaternion targetRotation = Quaternion.Euler(new Vector3(45, 0, 0));

        transform.rotation = targetRotation;

        transform.Rotate(new Vector3(30, 0, 0));
        */

        /*
        Quaternion originalRotation = transform.rotation;

        Vector3 originalRotationInVector3 = originalRotation.eulerAngles;
        Vector3 targetRotationVec = originalRotationInVector3 + new Vector3(30, 0, 0);

        Quaternion targetRotation = Quaternion.Euler(targetRotationVec);

        transform.rotation = targetRotation;
        */

        Quaternion originalRotation = Quaternion.Euler(new Vector3(45, 0, 0));
        Quaternion plusRotation = Quaternion.Euler(new Vector3(30, 0, 0));

        Quaternion targetRotation = plusRotation * originalRotation;

        transform.rotation = targetRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
