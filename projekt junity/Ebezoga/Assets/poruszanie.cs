using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszanie : MonoBehaviour
{
    public float szybkoscPoruszania;
    public float sprint;
    public float silaSkoku;
    public Rigidbody cialko;
    public Animator animatorek;
    void Update()
    {
        Skok();
        if (stoiNaZiemii())
        {
            animatorek.SetBool("czyDotykaZiemii", true);
        }
        else
        {
            animatorek.SetBool("czyDotykaZiemii", false);
        }
    }

    void FixedUpdate()
    {
        Ruch();
    }

    void Ruch()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            szybkoscPoruszania = sprint;
        }
        else
        {
            szybkoscPoruszania = 7;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animatorek.SetBool("czyChodzi", true);
        }
        else
        {
            animatorek.SetBool("czyChodzi", false);
        }
            float ruchHoryzontalny = Input.GetAxisRaw("Horizontal");
            float ruchVertykalny = Input.GetAxisRaw("Vertical");

            Vector3 ruch = new Vector3(ruchHoryzontalny, 0, ruchVertykalny) * szybkoscPoruszania * Time.fixedDeltaTime;
            Vector3 NowaPozycja = cialko.position + cialko.transform.TransformDirection(ruch);

            cialko.MovePosition(NowaPozycja);



    }


    void Skok()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (stoiNaZiemii())
            {
                cialko.AddForce(0, silaSkoku, 0, ForceMode.Impulse);
                Debug.Log("skok");
            }

        }
    }

    bool stoiNaZiemii()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.5f);
    }
    
}
