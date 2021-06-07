using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class misja : MonoBehaviour
{
    public Text goldText;
    public Text blueCrystalText;
    public Text redCrystalText;
    public Text coalText;
    public Text stoneText;
    public Text uraniumText;
    public GameObject menuMisji;
    GameObject graczek;
    int g;
    int bc;
    int rc;
    int c;
    int s;
    int u;
    int[] misjaIlosc = new int [6];
    static public int zrobionaMisja = 0;

    private void Start()
    {
        graczek = GameObject.Find("gracz");
        g = graczek.GetComponent<poruszanie>().gold;
        bc = graczek.GetComponent<poruszanie>().blueCrystal;
        rc = graczek.GetComponent<poruszanie>().redCrystal;
        c = graczek.GetComponent<poruszanie>().coal;
        s = graczek.GetComponent<poruszanie>().stone;
        for (int i = 0; i < 7; i++)
        {
            misjaIlosc[i] = Random.Range(1+LawaWyplywa.PSW, 4+LawaWyplywa.PSW);
        }
    }


    void Update()
    {
        if(menuMisji.active == true && Input.GetKeyUp(KeyCode.Q))
        {
            menuMisji.active = false;
        }
        else if (menuMisji.active == false && Input.GetKeyDown(KeyCode.Q))
        {
            menuMisji.active = true;
            OtwartoMenu();
        }
        if(g >= misjaIlosc[0] &&
            bc >= misjaIlosc[1] &&
            rc >= misjaIlosc[2] &&
            c >= misjaIlosc[3] &&
            s >= misjaIlosc[4])
        {
            zrobionaMisja = 1;
            Debug.Log("Skonczono misje");
        }
    }
    //Input.GetKeyDown(KeyCode.Q)
    void OtwartoMenu()
    {
        g = graczek.GetComponent<poruszanie>().gold;
        bc = graczek.GetComponent<poruszanie>().blueCrystal;
        rc = graczek.GetComponent<poruszanie>().redCrystal;
        c = graczek.GetComponent<poruszanie>().coal;
        s = graczek.GetComponent<poruszanie>().stone;

        goldText.text = g + "/" + misjaIlosc[0];
        blueCrystalText.text = bc + "/" + misjaIlosc[1];
        redCrystalText.text = rc + "/" + misjaIlosc[2];
        coalText.text = c + "/" + misjaIlosc[3];
        stoneText.text = s + "/" + misjaIlosc[4];
        uraniumText.text = "1/" + 1;
    }
}
