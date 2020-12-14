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
    public float aktualnePaliwo;
    public float maksymalnePaliwo;
    public float silnik;
    public float odnawianiePaliwa;
    public bool czyMoznaZaatakowac;
    public float cooldown;
    public GameObject paliwkoUI;
    public GameObject pjorunUI;
    public ParticleSystem ogienJetpacka;
    public Light swiatloOgniaJetpacka;

    void Update()
    {
        Klikanie();
        Skok();
        if (stoiNaZiemii())
        {
            animatorek.SetBool("czyDotykaZiemii", true);
        }
        else
        {
            animatorek.SetBool("czyDotykaZiemii", false);
        }

        if (Input.GetButtonDown("Fire1") && czyMoznaZaatakowac == true)
        {
            Strzal();
            animatorekReki.SetBool("czyKliknal", true);
            czyMoznaZaatakowac = false;
        }
        else
        {
            animatorekReki.SetBool("czyKliknal", false);
        }


        /*if (this.animatorekReki.GetCurrentAnimatorStateInfo(0).IsName("walonko"))
        {
            Debug.Log("odjeto");

        }*/
    }

    void FixedUpdate()
    {
        Ruch();
        paliwkoUI.transform.localScale = new Vector3(aktualnePaliwo / maksymalnePaliwo, 1, 1);
    }

    void Klikanie()
    {

        if (czyMoznaZaatakowac == false)
        {
            cooldown = Mathf.Max(0, cooldown - Time.deltaTime);
        }
        if (cooldown == 0)
        {
            czyMoznaZaatakowac = true;
            cooldown = .5f;
        }
    }
    void Strzal()
    {
        RaycastHit hit;
        if (Physics.Raycast(kamera.transform.position, kamera.transform.forward, out hit, zasieg))
        {
            Debug.Log(hit.transform.name);

            Cel cel = hit.transform.GetComponent<Cel>();
            if (cel != null)
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
            pjorunUI.SetActive(true);
        }
        else
        {
            szybkoscPoruszania = 7;
            pjorunUI.SetActive(false);
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
        if (Input.GetKey(KeyCode.Space))
        {
            if (!stoiNaZiemii() && aktualnePaliwo > 0f)
            {
                cialko.AddForce(Vector3.up * silnik * Time.deltaTime, ForceMode.Acceleration);
                aktualnePaliwo = Mathf.Max(0, aktualnePaliwo - Time.deltaTime);
                ogienJetpacka.Play();
                swiatloOgniaJetpacka.enabled = true;
            }

        }
        if (stoiNaZiemii())
        {
            aktualnePaliwo = Mathf.Min(maksymalnePaliwo, aktualnePaliwo + Time.deltaTime * odnawianiePaliwa);
        }
        if (stoiNaZiemii() || aktualnePaliwo <= 0f || !Input.GetKey(KeyCode.Space))
        {
            ogienJetpacka.Stop();
            swiatloOgniaJetpacka.enabled = false;
        }

    }

    bool stoiNaZiemii()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.5f);
    }
    
}
