using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDisplay : MonoBehaviour
{

    public TextMeshPro text;
    public GameScript game;

    string playerTurn;
    string gameState;
    string gameResult;

    void Start()
    {
        text.text = "";
    }

    
    void Update()
    {

        setStrings();

        text.text = playerTurn + "\n" + gameState + "\n" + gameResult;

    }

    public void setStrings()
    {
        if (game.board.playerTurn == 1)
        {
            playerTurn = "Player 1";
        }
        else
        {
            playerTurn = "Player 2";
        }

        if (game.board.gameActive)
        {
            gameState = "Game in progress...";
        }
        else
        {
            gameState = "Game finished";
        }

        switch (game.board.gameState)
        {
            case 0:
                gameResult = "";
                break;
            case 1:
                gameResult = "Draw!";
                break;
            case 2:
                gameResult = "Player 1 wins!";
                break;
            case 3:
                gameResult = "Player 2 wins!";
                break;
        }
    }

}
