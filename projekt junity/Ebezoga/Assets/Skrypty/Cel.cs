using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cel : MonoBehaviour
{
    public int zycie;

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
        Destroy(gameObject, 0.25f);
    }

}
