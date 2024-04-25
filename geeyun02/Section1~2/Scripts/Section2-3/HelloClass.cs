using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animal jack = new Animal();
        jack.name = "JACK";
        jack.sound = "Bark";
        jack.weight = 4.5f;

        Animal nate = new Animal();
        nate.name = "NATE";
        nate.sound = "Nyaa";
        nate.weight = 1.2f;

        Animal annie = new Animal();
        annie.name = "ANNIE";
        annie.sound = "Wee";
        annie.weight = 0.8f;

        Debug.Log(jack.name);
        Debug.Log(jack.sound);

        Debug.Log(nate.name);
        Debug.Log(nate.sound);

        Debug.Log(annie.name);
        Debug.Log(annie.sound);

        //클래스-오브젝트에서 변수는 오브젝트를 가리키는 화살표
        //nate를 가리키던 화살표가 jack을 가리키고 nate는 사실상 없는거나 마찬가지
        nate = jack;
        //nate를 바꾸면 jack도 같이 바뀐다
        nate.name = "JIMMY";
        nate.sound = "Cheeze";

        Debug.Log(jack.name); //JIMMY
        Debug.Log(jack.sound); //Cheeze

        Debug.Log(nate.name); //JIMMY
        Debug.Log(nate.sound); //Cheeze

        Debug.Log(annie.name);
        Debug.Log(annie.sound);
    }
}

public class Animal
{
    //public을 붙여줘야 외부에서 참조 가능
    public string name;
    public string sound;
    public float weight;
}
