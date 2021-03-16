using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strzalTornada : MonoBehaviour
{
    public float obrazenia;
    Rigidbody cialko;
    public float szybkosc;
    GameObject graczek;

    void Awake()
    {
        cialko = GetComponent<Rigidbody>();
        Transform cel = GameObject.Find("Main Camera").transform;
        Vector3 zwrot = cel.position - transform.position;
        transform.LookAt(cel);
        cialko.AddForce(zwrot * szybkosc * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "gracz")
        {
            graczek = GameObject.Find("gracz");
            graczek.GetComponent<poruszanie>().zycie -= obrazenia;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
