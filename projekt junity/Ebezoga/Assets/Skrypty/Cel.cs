using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cel : MonoBehaviour
{
    public int zycie = 100;

    public void OdejmujeZycie ( int ile)
    {
        zycie -= ile;
        if(zycie <= 0)
        {
            Zniszcz();
        }
    }

    void Zniszcz()
    {
        Destroy(gameObject);
    }

}
