using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornadoPrzeciwnik : MonoBehaviour
{
    float szybkoscStrzelania;
    Transform cel;
    public GameObject pocisk;
    public Transform pozycjaStrzalu;
    public float MinDyst;
    public float MaxDyst;
    public float poruszanie;
    GameObject graczek;
    public float obrazenia;
    public float zycie;
    bool dodanoAmmo = false;

    void Start()
    {
        cel = GameObject.Find("gracz").transform;
    }

    void Update()
    {
        if(zycie <= 0)
        {
            graczek = GameObject.Find("gracz");
            if (dodanoAmmo == false)
            {
                graczek.GetComponent<poruszanie>().ammo += 10;
                dodanoAmmo = true;
                graczek.GetComponent<poruszanie>().OdswiezanieAmmo();
            }
            Destroy(gameObject, 0.25f);
        }

        szybkoscStrzelania -= Time.deltaTime;
        transform.LookAt(cel);
        Vector3 zwrot = transform.position - cel.position;

        if (Vector3.Distance(transform.position, cel.position) >= MinDyst)
        {

            transform.position += transform.forward * poruszanie * Time.deltaTime;

            
        }
        if (Vector3.Distance(transform.position, cel.position) <= MaxDyst)
            {
                if (szybkoscStrzelania <= 0)
                {
                    szybkoscStrzelania = Random.Range(3.5f - LawaWyplywa.PSW, 4.5f-LawaWyplywa.PSW);
                    Strzal();
                }
            }
    }
    void Strzal()
    {
        Instantiate(pocisk, pozycjaStrzalu.position, pozycjaStrzalu.rotation);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "gracz")
        {
            graczek = GameObject.Find("gracz");
            graczek.GetComponent<poruszanie>().zycie -= obrazenia;
        }
    }
}
