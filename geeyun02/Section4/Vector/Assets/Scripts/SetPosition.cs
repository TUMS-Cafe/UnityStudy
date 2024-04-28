using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.position은 global space 기준으로 좌표가 설정됨
        //transform.position = new Vector3(0, 0, 0);

        //transform.localPosition은 local space 기준으로 좌표가 설정됨
        transform.localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
