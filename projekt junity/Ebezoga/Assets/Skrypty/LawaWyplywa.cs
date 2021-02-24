using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawaWyplywa : MonoBehaviour
{

    public float SzybkoscWyplywania;
    public float pozycjaY;

    void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, SzybkoscWyplywania * Time.deltaTime, 0);
        
    }


}
