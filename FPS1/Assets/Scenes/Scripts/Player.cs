using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Camera")]
    public Camera ca;
    float h, v;
    public float posth,_postv;
    [Header("MOVING")]
    public float moving;
    InputPlayer _move;
    public GameObject explosion;
    [Header("GUN")]
    public GameObject boom;
    public bool isShoooting;
    public Transform PuntodeDisparo;
    [Header ("JUMP")]
    public bool canJump;
    public float jump;
    Rigidbody rb;
    [Header("forEnemy")]
    public bool thisforyou;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground")) {
            canJump = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isShoooting = false;
        _move = GetComponent <InputPlayer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(explosion,PuntodeDisparo.position,Quaternion.identity);
            StartCoroutine(Shoot());
            RaycastHit _hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit, Mathf.Infinity, 1 << 9))
            {
                thisforyou = true;               
            }
         }
        h = Input.GetAxis("Mouse X")* posth;
        v = Input.GetAxis("Mouse Y")*_postv;
        transform.Rotate(0,h,0);
        ca.transform.Rotate(-v,0,0);
        rb.velocity = new Vector3(_move.InputVertical * moving,rb.velocity.y,_move.InputHorizontal * moving);        
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (canJump) {
                rb.velocity =new Vector3(0,jump,0);
            }
        }
    }
 IEnumerator Shoot()
    {
        isShoooting = true;
        GameObject bullet=Maneger_Scene.Singleton._Push();

        if (bullet == null)
        {
            print("isempty");
        }
        else {
            print("instanciado");
            bullet.SetActive(true);
            bullet.transform.position = PuntodeDisparo.position;
        }
       // GetComponent<AudioSource>().Play();
        
       // bullet.rb.AddForce(PuntodeDisparo.forward*speed,ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
        isShoooting =false;
    }

}
