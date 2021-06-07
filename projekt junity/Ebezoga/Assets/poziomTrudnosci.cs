using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class poziomTrudnosci : MonoBehaviour
{
    public void Easy()
    {
        LawaWyplywa.PSW = 1;
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void Medium()
    {
        LawaWyplywa.PSW = 2;
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void Hard()
    {
        LawaWyplywa.PSW = 3;
        SceneManager.LoadScene("Scenes/SampleScene");
    }

}
