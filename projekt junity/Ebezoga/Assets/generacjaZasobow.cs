using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generacjaZasobow : MonoBehaviour
{
    //łupy = lupy
    public GameObject[] lupy;
    

    void Start()
    {
        Generacja();
    }
    void Generacja()
    {
        Quaternion rotacjaLupu = Quaternion.Euler(-90, 0, Random.Range(0, 360));
        int losowyLup = Random.Range(0, lupy.Length);
        GameObject klon = Instantiate(lupy[losowyLup], gameObject.transform.position, rotacjaLupu);

    }
   
}
