using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nonARButtonHandler : MonoBehaviour
{
    bool isActive;
    public Image btn;

    void Start()
    {
        isActive = true;
        btn.color = Color.red;
    }

    
    void Update()
    {
        
    }

    public void setActive()
    {
        if(isActive)
        {
            isActive = false;
            gameObject.SetActive(false);
            btn.color = Color.green;
        }
        else
        {
            isActive = true;
            gameObject.SetActive(true);
            btn.color = Color.red;
        }
    }

}
