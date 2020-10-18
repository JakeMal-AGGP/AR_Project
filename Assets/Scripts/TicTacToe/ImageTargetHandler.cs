using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargetHandler : MonoBehaviour
{

    public GameObject X;
    public GameObject O;
    public int space;

    void Start()
    {
        X.gameObject.SetActive(false);
        O.gameObject.SetActive(false);
    }

}
