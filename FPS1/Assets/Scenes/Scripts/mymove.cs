using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mymove : MonoBehaviour
{
    void Start()
    {
        Transform _e1 =GameObject.FindGameObjectWithTag("Enemigo").GetComponent<Transform>();
        GetComponent<Rigidbody>().AddForce((_e1.position-transform.position)*2f*Time.deltaTime,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
