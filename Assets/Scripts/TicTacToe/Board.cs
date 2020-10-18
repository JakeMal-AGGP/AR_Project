using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Board : MonoBehaviour
{

    public int[] board;
    public int playerTurn;
    public int gameState; // 0 = active game, 1 = draw, 2 = player 1 victory, 3 = player 2 victory
    public bool gameActive;

    public TextMeshPro text;
    public GameObject restart;

    public Board()
    {
        board = new int[9];
        playerTurn = 1;
        gameState = 0;
        gameActive = true;
    }

    public void checkGameState()
    {

        //Check for a draw
        if (board[0] != 0 && board[1] != 0 && board[2] != 0 && board[3] != 0 && board[4] != 0 && board[4] != 0 && board[5] != 0 && board[6] != 0 && board[7] != 0 && board[8] != 0)
        {
            gameState = 1;
            gameActive = false;
        }

        //Check for Player 1 Victory
        if (board[0] + board[1] + board[2] == 3) { gameState = 2; }
        else if (board[3] + board[4] + board[5] == 3) { gameState = 2; }
        else if (board[6] + board[7] + board[8] == 3) { gameState = 2; }
        else if (board[0] + board[3] + board[6] == 3) { gameState = 2; }
        else if (board[1] + board[4] + board[7] == 3) { gameState = 2; }
        else if (board[2] + board[5] + board[8] == 3) { gameState = 2; }
        else if (board[0] + board[4] + board[8] == 3) { gameState = 2; }
        else if (board[2] + board[4] + board[6] == 3) { gameState = 2; }

        //Check for Player 2 Victory
        if (board[0] + board[1] + board[2] == -3) { gameState = 3; }
        else if (board[3] + board[4] + board[5] == -3) { gameState = 3; }
        else if (board[6] + board[7] + board[8] == -3) { gameState = 3; }
        else if (board[0] + board[3] + board[6] == -3) { gameState = 3; }
        else if (board[1] + board[4] + board[7] == -3) { gameState = 3; }
        else if (board[2] + board[5] + board[8] == -3) { gameState = 3; }
        else if (board[0] + board[4] + board[8] == -3) { gameState = 3; }
        else if (board[2] + board[4] + board[6] == -3) { gameState = 3; }

        if(gameState != 0)
        {
            gameActive = false;
        }

    }

    public void placeMarker(GameObject vb)
    {

        int space = vb.transform.parent.GetComponent<ImageTargetHandler>().space;

        bool result = checkSpace(space);

        if(result)
        {

            if(playerTurn == 1)
            {

                board[space] = 1;
                playerTurn = 2;
                vb.transform.parent.GetComponent<ImageTargetHandler>().X.gameObject.SetActive(true);

            }
            else
            {
                board[space] = -1;
                playerTurn = 1;
                vb.transform.parent.GetComponent<ImageTargetHandler>().O.gameObject.SetActive(true);
            }

            checkGameState();

        }

    }

    public bool checkSpace(int s)
    {

        if(board[s] == 0) { return true; }

        return false;

    }

    public void displayBoard()
    {
        text.text = getString(board[0]) + " | " + getString(board[1]) + " | " + getString(board[2]) + "\n"
                    + getString(board[3]) + " | " + getString(board[4]) + " | " + getString(board[5]) + "\n"
                    + getString(board[6]) + " | " + getString(board[7]) + " | " + getString(board[8]) + "\n";

        if (!gameActive)
        {
            restart.gameObject.SetActive(true);
        }
    }

    string getString(int x)
    {
        string letter;

        if (x == 1) { letter = "X"; }
        else if (x == -1) { letter = "O"; }
        else { letter = " "; }

        return letter;
    }

}
