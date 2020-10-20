using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodazanieZaKamera : MonoBehaviour
{

    public float KatReki;
    public Transform Reka;

    void Update()
    {
        RuchGoraDol();
    }

    void RuchGoraDol()
    {
        KatReki += Input.GetAxis("Mouse Y") * 500 * -Time.deltaTime;
        KatReki = Mathf.Clamp(KatReki, 30, 60);
        Reka.localRotation = Quaternion.AngleAxis(KatReki, Vector3.up);
    }
}
