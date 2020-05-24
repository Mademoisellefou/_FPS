using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum estados { Patrullar, Perseguir, atacar }
public class Enemigo : MonoBehaviour
{
    [Header("Estados")]
    estados _estados = estados.Patrullar;
    [Header("Patrullo")]
    public Transform inicio, fin;
    private Transform objetivo;
    [Header("Perseguir")]
    public float RangoVision, distancia;
    public float VelocidadPer;
    [Header("MYMOVE")]
    public float Speed;
    private GameObject Player;
    private void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        objetivo = fin;
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        if (_estados == estados.Patrullar)
        {
            transform.LookAt(objetivo.position);
            transform.position = Vector3.MoveTowards(transform.position, objetivo.position, 2f * Time.deltaTime);
            if (transform.position == objetivo.position) { 
            objetivo = (objetivo == fin) ? inicio : fin;
            }
            if (VeoJugador() == true)
            {
                _estados = estados.Perseguir;
            }
        }
        else
        {
            if (_estados == estados.Perseguir)
            {
                transform.LookAt(Player.transform);
                transform.Translate(Vector3.forward * VelocidadPer * Time.deltaTime);
                if ((transform.position - Player.transform.position).magnitude > 10)
                {
                    _estados = estados.Patrullar;
                }
                if ((transform.position - Player.transform.position).magnitude < 2)
                {
                    _estados = estados.atacar;
                }
            }
            else
            {
                if (_estados == estados.atacar)
                {
                    transform.LookAt(Player.transform);
                    transform.Translate(Vector3.zero * VelocidadPer * Time.deltaTime);
                }
                if ((transform.position - Player.transform.position).magnitude > 1)
                {
                    _estados = estados.Perseguir;
                }
                if ((transform.position - Player.transform.position).magnitude > 20)
                {
                    _estados = estados.Patrullar;
                }
            }

        }
        print("estado :" + _estados);
    }
    public bool VeoJugador()
    {
        bool _Visto = false;
        if (Vector3.SqrMagnitude(transform.position - Player.transform.position) <= distancia)
        {
            if (Vector3.Angle(transform.forward, (Player.transform.position - transform.position)) < RangoVision)
            {
                _Visto = true;
            }
        }

        return _Visto;
    }
    public void ItHurts()
    {

        GetComponent<AudioSource>().Play();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            other.gameObject.transform.position = Player.transform.position;
        }
    }
    
}
