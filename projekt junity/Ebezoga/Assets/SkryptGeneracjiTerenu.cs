using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkryptGeneracjiTerenu : MonoBehaviour
{
    public GameObject[] czanki;
    public int siatkaX;
    public int siatkaY;
    public float odstep;
    public Vector3 poczatekSpawnu = Vector3.zero;

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
        rotacjaCzanka = Quaternion.Euler(-90, 0, 0);
        int losowyCzank = Random.Range(0, czanki.Length);
        GameObject klon = Instantiate(czanki[losowyCzank], pozycjaDoSpawnu, rotacjaCzanka);
    }

}
