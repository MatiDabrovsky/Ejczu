using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public float zycie;
    float poprzednieZycie = 100;
    public GameObject paliwkoUI;
    public GameObject pjorunUI;
    public GameObject zycieUI;
    public GameObject kilof;
    public GameObject pistolet;
    public ParticleSystem ogienJetpacka;
    public Light swiatloOgniaJetpacka;
    RaycastHit hitLawa;
    public GameObject paliSieUI;
    public int gold;
    public int blueCrystal;
    public int redCrystal;
    public int coal;
    public int stone;
    public Text goldText;
    public Text blueCrystalText;
    public Text redCrystalText;
    public Text coalText;
    public Text stoneText;
    public Text ammoText;
    public float ammo;
    public GameObject pocisk;
    float liczniczek = 100;
    float staryLiczniczek;
    public GameObject uderzenieRock;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            kilof.active = true;
            pistolet.active = false;
            ammoText.gameObject.active = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            kilof.active = false;
            pistolet.active = true;
            ammoText.gameObject.active = true;
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hitLawa, 0.5f))
        {
            if (hitLawa.collider.name.Equals("Lawa"))
            {
                paliSieUI.active = true;
                zycie -= 0.1f;
            }
            else
            {
                paliSieUI.active = false;
            }
        }
        Klikanie();
        Skok();
        if (stoiNaZiemii())
        {
            animatorek.SetBool("czyDotykaZiemii", true);
        }
        else
        {
            animatorek.SetBool("czyDotykaZiemii", false);
            paliSieUI.active = false;
        }

        if (Input.GetButtonDown("Fire1") && czyMoznaZaatakowac == true && kilof.active == true)
        {
            Strzal();
            animatorekReki.SetBool("czyKliknal", true);
            czyMoznaZaatakowac = false;
        }
        else
        {
            animatorekReki.SetBool("czyKliknal", false);
        }
        if(Input.GetButtonDown("Fire1") && pistolet.active == true)
        {
            strzalPistolet();
        }


        /*if (this.animatorekReki.GetCurrentAnimatorStateInfo(0).IsName("walonko"))
        {
            Debug.Log("odjeto");

        }*/

            goldText.text = ("" + gold);
            blueCrystalText.text = ("" + blueCrystal);
            redCrystalText.text = ("" + redCrystal);
            coalText.text = ("" + coal);
            stoneText.text = ("" + stone);
    }

    void FixedUpdate()
    {
        Ruch();
        paliwkoUI.transform.localScale = new Vector3(aktualnePaliwo / maksymalnePaliwo, 1, 1);
        zycieUI.transform.localScale = new Vector3(liczniczek / 100, 1, 1);
        if(zycie < poprzednieZycie)
        {
            staryLiczniczek = 100;
            liczniczek = Mathf.Lerp(poprzednieZycie, zycie, Time.deltaTime * 15f);
            staryLiczniczek -= 100 - liczniczek;
            poprzednieZycie = staryLiczniczek;
        }
        Debug.Log("licziczek " + liczniczek);
        Debug.Log("poprzedniezycie " +poprzednieZycie);
        if(zycie <= 0)
        {
            SceneManager.LoadScene("przegrales");
        }
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
            tornadoPrzeciwnik tornado = hit.transform.GetComponent<tornadoPrzeciwnik>();
            if(tornado != null)
            {
                tornado.zycie--;
            }
            if (cel != null)
            {
                cel.OdejmujeZycie(10);

            }
            GameObject efekcik = Instantiate(uderzenieRock, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(efekcik, 2f);
        }
    }

    void strzalPistolet()
    {
        ammoText.text = "Ammo: " + ammo + "/10";
        if(ammo > 0)
        {
            Instantiate(pocisk, kamera.transform.position, kamera.transform.rotation);
            ammo--;
        }
        ammoText.text = "Ammo: " + ammo + "/10";
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
