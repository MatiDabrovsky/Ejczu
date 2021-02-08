using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboskrypt : MonoBehaviour
{
    public int combo = 0;
    public float czas = 0f;
    public float ileCzasuNaCombo;
    public string kombo = "";
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.B))
        {
            Abab();
            kombo += "C";
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Bbb();
            kombo += "B";
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            Aaa();
            kombo += "A";
        }

        if (czas > 0)
        {
            czas = czas - Time.deltaTime;
        }
        else if(czas <= 0)
        {
            if (czas < 0)
            {
                czas = 0;
            }
            Debug.Log(combo);
            // Sprawdzanko(combo);
            SprawdzankoKomba();
            combo = 0;
            kombo = "";
        }
    }
    void Abab()
    {
        Debug.Log("wcisnieto C");
        czas = ileCzasuNaCombo;
    }
    void Aaa()
    {
        Debug.Log("wcisnieto A");
        combo = combo * 10 + 1;
        czas = ileCzasuNaCombo;
    }
    void Bbb()
    {
        Debug.Log("wcisnieto B");
        combo = combo * 10 + 2;
        czas = ileCzasuNaCombo;
    }

    void SprawdzankoKomba()
    {
        if (kombo.Length > 3)
        {
            kombo = kombo.Substring(kombo.Length - 3, 3);
        }
       
        if (kombo.Contains("AAA"))
        {
            Debug.Log("AAA");
            kombo = "";
        }
        Debug.Log(kombo);
    }
    
    void Sprawdzanko(int kombo)
    {
        if(kombo == 111)
        {
            Debug.Log("AAA");
        }
        else if (kombo == 222)
        {
            Debug.Log("BBB");
        }
        
    }


}
