using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruchKamery : MonoBehaviour
{
    public float sensitivity;
    public float wygladzanieRuchuKamery;
    public GameObject gracz;
    Vector2 wygladzacz;
    Vector2 kierunekPatrzenia;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        RotacjaKamery();
    }

    void RotacjaKamery()
    {
        Vector2 XYkamery = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        XYkamery = Vector2.Scale(XYkamery, new Vector2(sensitivity * wygladzanieRuchuKamery, sensitivity * wygladzanieRuchuKamery));
        wygladzacz.x = Mathf.Lerp(wygladzacz.x, XYkamery.x, 1f / wygladzanieRuchuKamery);
        wygladzacz.y = Mathf.Lerp(wygladzacz.y, XYkamery.y, 1f / wygladzanieRuchuKamery);

        kierunekPatrzenia += wygladzacz;

        transform.localRotation = Quaternion.AngleAxis(-kierunekPatrzenia.y, Vector3.right);
        gracz.transform.localRotation = Quaternion.AngleAxis(kierunekPatrzenia.x, gracz.transform.up);
        kierunekPatrzenia.y = Mathf.Clamp(kierunekPatrzenia.y, -60f, 30f);
    }
}
