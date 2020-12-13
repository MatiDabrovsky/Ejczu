using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkryptGeneracjiTerenu : MonoBehaviour
{
    public GameObject[] czanki;
    public int siatkaX;
    public int siatkaY;
    int losowansko;
    public float odstep;
    public Vector3 poczatekSpawnu = Vector3.zero;
    Quaternion rotacjaCzanka;

    private void Start()
    {
        Generacja();
    }

    void Generacja()
    {
        for (int x = 0; x < siatkaX; x++)
        {

            for (int y = 0; y < siatkaY; y++)
            {
                Vector3 pozycjaSpawnu = new Vector3(x * odstep, 0, y * odstep) + poczatekSpawnu;
                LosoweCzanki(pozycjaSpawnu, Quaternion.identity);
            }

        }
    }

    void LosoweCzanki(Vector3 pozycjaDoSpawnu, Quaternion rotacjaCzanka)
    {
        int losowyCzank = Random.Range(0, czanki.Length);
        
        losowansko = Random.Range(0, 4);
        switch (losowansko)
        {
            case 0:
            rotacjaCzanka = Quaternion.Euler(-90, 0, 0);
            GameObject klon = Instantiate(czanki[losowyCzank], pozycjaDoSpawnu, rotacjaCzanka);
            break;

            case 1:
                //gameObject.transform.eulerAngles = new Vector3(-90, 90, 0);
                rotacjaCzanka = Quaternion.Euler(-90, 90, 0);
                GameObject klon2 = Instantiate(czanki[losowyCzank], pozycjaDoSpawnu, rotacjaCzanka);
                break;

            case 2:
                rotacjaCzanka = Quaternion.Euler(-90, 180, 0);
                GameObject klon3 = Instantiate(czanki[losowyCzank], pozycjaDoSpawnu, rotacjaCzanka);
                break;

            case 3:
                rotacjaCzanka = Quaternion.Euler(-90, 270, 0);
                GameObject klon4 = Instantiate(czanki[losowyCzank], pozycjaDoSpawnu, rotacjaCzanka);
                break;

        }
        //rotacjaCzanka = Quaternion.Euler(-90, 0, 0);
        
        
    }

}
