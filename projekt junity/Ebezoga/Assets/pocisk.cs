using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocisk : MonoBehaviour
{
    public float predkosc = 10f;
    GameObject przeciwnik;

    void Update()
    {
        transform.position += transform.forward * predkosc * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "przeciwnik")
        {
            przeciwnik = collision.gameObject;
            przeciwnik.GetComponent<tornadoPrzeciwnik>().zycie -= 1;
            Destroy(gameObject);
        }
        else if (collision.gameObject.name != "gracz")
        {
            Destroy(gameObject);
        }
    }
}
