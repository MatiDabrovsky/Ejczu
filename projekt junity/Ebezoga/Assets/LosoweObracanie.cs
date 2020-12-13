using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosoweObracanie : MonoBehaviour
{
    int losowansko;
    void Start()
    {
        losowansko = Random.Range(0, 4);
        switch (losowansko)
        {
            case 0:
            gameObject.transform.eulerAngles = new Vector3(-90, 0, 0);
            break;
            case 1:
            gameObject.transform.eulerAngles = new Vector3(-90, 90, 0);
            break;
            case 2:
            gameObject.transform.eulerAngles = new Vector3(-90, 180, 0);
            break;
            case 3:
            gameObject.transform.eulerAngles = new Vector3(-90, 270, 0);
            break;

        }
    }


}
