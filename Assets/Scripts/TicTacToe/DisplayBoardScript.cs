using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayBoardScript : MonoBehaviour
{

    public GameObject restart;
    public TextMeshPro text;
    public GameScript game;
    public Board board;

    void Start()
    {

        board = new Board();

        board = game.board;
    }


    void Update()
    {

        text.text = getString(board.board[0]) + " | " + getString(board.board[1]) + " | " + getString(board.board[2]) + "\n"
                    + getString(board.board[3]) + " | " + getString(board.board[4]) + " | " + getString(board.board[5]) + "\n"
                    + getString(board.board[6]) + " | " + getString(board.board[7]) + " | " + getString(board.board[8]) + "\n";

        if(!board.gameActive)
        {
            restart.gameObject.SetActive(true);
        }
    }

    string getString(int x)
    {
        string letter;

        if(x == 1) { letter = "X"; }
        else if(x == -1) { letter = "O"; }
        else { letter = " "; }

        return letter;
    }
}
