using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawaWyplywa : MonoBehaviour
{

    public float SzybkoscWyplywania;
    public float pozycjaY;
    static public int PSW = 0; //poziom szybkosci wyplywania lawy

    void Start()
    {
        if (PSW == 1)
        {
            SzybkoscWyplywania = 0.05f;
        }
        else if (PSW == 2)
        {
            SzybkoscWyplywania = 0.1f;
        }
        else if(PSW == 3)
        {
            SzybkoscWyplywania = 0.2f;
        }
    }
    void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, SzybkoscWyplywania * Time.deltaTime, 0);
        
    }


}
