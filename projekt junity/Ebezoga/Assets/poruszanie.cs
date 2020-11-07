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
    public Animator animatorekReki;
    public Camera kamera;
    public float zasieg;
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

        if (Input.GetButtonDown("Fire1"))
        {
            Strzal();
            animatorekReki.SetBool("czyKliknal", true);
        }
        else
        {
            animatorekReki.SetBool("czyKliknal", false);
        }
        
    }

    void FixedUpdate()
    {
        Ruch();
    }


    void Strzal()
    {
        



        RaycastHit hit;
        if(Physics.Raycast(kamera.transform.position, kamera.transform.forward, out hit, zasieg))
        {
            Debug.Log(hit.transform.name);

            Cel cel = hit.transform.GetComponent<Cel>();
            if(cel != null)
            {
                cel.OdejmujeZycie(10);
            }
        }
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
