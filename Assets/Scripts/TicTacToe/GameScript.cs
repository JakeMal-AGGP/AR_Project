using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using TMPro;

public class GameScript : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject[] vbGameObject = new GameObject[9];
    public Board board;

    public TextMeshPro text;
    public GameObject restart;

    void Start()
    {
        

        for(int i = 0; i < 9; i++)
        {

            vbGameObject[i].GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        }

        board = new Board();

        board.text = text;
        board.restart = restart;
    }

    
    void Update()
    {
        board.displayBoard();
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("vb Pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("vb Released");

        if(board.gameActive == false)
        {
            if(vb.VirtualButtonName == "five")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            board.placeMarker(vb.gameObject);
        }

    }

}
