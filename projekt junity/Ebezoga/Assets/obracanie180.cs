using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obracanie180 : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
