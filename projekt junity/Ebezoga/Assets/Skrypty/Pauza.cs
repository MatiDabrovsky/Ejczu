using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauza : MonoBehaviour
{
    public static bool Zapauzowano = false;
    public GameObject pauzaMenuUI;

    void Start()
    {
        Wznow();    
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
