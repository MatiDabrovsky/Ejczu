using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauza : MonoBehaviour
{
    public static bool Zapauzowano = false;
    public static bool ekwipunekON = false;
    public GameObject pauzaMenuUI;
    public GameObject ekwipunekUI;

    void Start()
    {
        Wznow();    
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ekwipunekON == false)
        {
            if (Zapauzowano)
            {
                Wznow();
            }
            else
            {
                Pauzuj();
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && Zapauzowano == false)
        {
            if (ekwipunekON)
            {
                WylaczEkwipunek();
            }
            else
            {
                WlaczEkwipunek();
            }
        }
    }

    public void WylaczEkwipunek()
    {
        Time.timeScale = 1f;
        ekwipunekUI.SetActive(false);
        ekwipunekON = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void WlaczEkwipunek()
    {
        ekwipunekUI.SetActive(true);
        ekwipunekON = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void Wznow()
    {
        Time.timeScale = 1f;
        pauzaMenuUI.SetActive(false);
        Zapauzowano = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Pauzuj()
    {
        pauzaMenuUI.SetActive(true);
        Zapauzowano = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void przejscieDoMenu()
    {
        SceneManager.LoadScene("Main");
    }
    public void wyjscieZgry()
    {
        Application.Quit();
    }

}
