using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Rigidbody target;

    //public Transform spawnPosition;
    public Transform spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject instance = Instantiate(target, spawnPosition.position, spawnPosition.rotation);
        Rigidbody instance = Instantiate(target, spawnPosition.position, spawnPosition.rotation);

        //instance.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
        instance.AddForce(0, 1000, 0);

        Debug.Log(instance.name);
    }
}
