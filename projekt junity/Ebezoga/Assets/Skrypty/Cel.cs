using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cel : MonoBehaviour
{
    public int zycie;
    GameObject graczek;
    private void Start()
    {
        graczek = GameObject.Find("gracz");
    }


    public void OdejmujeZycie ( int ile)
    {
        zycie -= ile;
        if(zycie <= 0)
        {
            if (gameObject.name == "rudaZlota")
            {
                graczek.GetComponent<poruszanie>().gold++;
                graczek.GetComponent<poruszanie>().stone++;

            }
            else if(gameObject.name == "rudaKrysztaluNiebieski")
            {
                graczek.GetComponent<poruszanie>().blueCrystal++;
            }
            else if (gameObject.name == "rudaKrysztaluCzerwony")
            {
                graczek.GetComponent<poruszanie>().redCrystal++;
            }
            else if (gameObject.name == "wegiel")
            {
                graczek.GetComponent<poruszanie>().coal += 2;
            }
            Zniszcz();
        }
    }

    void Zniszcz()
    {
        Destroy(gameObject, 0.25f);
    }    
}
