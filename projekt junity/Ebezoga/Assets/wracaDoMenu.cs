using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wracaDoMenu : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(passiveMe(5));
    }
    IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene("Main");
    }

}
