using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maneger_Scene : MonoBehaviour
{
    public static Maneger_Scene Singleton;
    [Header("Pooler")]
    public int cantidad;
    public GameObject _bullet;
    private List<GameObject> _Bullet;
    private void Awake()
    {
        if (Singleton == null) { Singleton = this; }
        else { Destroy(this); }
    }
    void Start()
    {
        _Bullet= new List<GameObject>();
        for (int i = 0; i < cantidad; i++) {
            GameObject bul = Instantiate(_bullet);
            bul.SetActive(false);
            _Bullet.Add(bul);
        }
    }
    public GameObject _Push()
    {
        GameObject bul=null;
        for (int i = 0; i < cantidad; i++) {
            if (!_Bullet[i].activeInHierarchy) {
                bul = _Bullet[i];
                return bul;
            }
        }
        return bul;
    }
}
