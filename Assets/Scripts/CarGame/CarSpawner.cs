using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarSpawner : MonoBehaviour
{

    //CarSpawner also acts as a game controller


    //Game objects
    public GameObject car;
    public GameObject spawnParent;
    public List<GameObject> spawnPos;

    //Score / Display
    public TextMeshPro gameStatusText;
    public int score;
    
    //Game control
    private int gameTick; // Overall game timer. Ticks up 1 each frame
    private int gameSeconds; // Overall game timer. Ticks up 1 every 60 gameTicks
    public bool startGame; // Initial game start boolean (press to play)
    public bool gameActive; // If the game is active
    public string gameStatus; // End status of the game
    private int tick;
    private int waitTick;
    public bool spawnCar;
    public int minSpawnSeconds;
    public int maxSpawnSeconds;


    void Start()
    {
        gameActive = true;
        startGame = false;
        waitTick = Random.Range(60, 320);
        score = 0;
        minSpawnSeconds = 420;
        maxSpawnSeconds = 600;
        gameSeconds = 0;
        gameTick = 0;
    }

    
    void Update()
    {

        if(startGame)
        {
            gameTick += 1;

            if (gameTick >= 60)
            {
                gameSeconds += 1;
                gameTick = 0;
            }

            if (gameActive)
            {
                car_spawn_handler();
                updateText(1);
            }
            else
            {
                updateText(2);
            }
        }

    }

    public void start_game()
    {
        if(!startGame)
        {
            startGame = true;
        }
    }

    public void addPoints(int amount)
    {

        score += amount;

    }

    private void updateText(int state)
    {
        //1 = game active
        //2 = game over

        switch(state)
        {
            case 1:
                gameStatusText.text = "Score: " + score;
                gameStatusText.color = Color.blue;
                gameStatusText.transform.Rotate(0, .1f, 0);
                break;

            case 2:
                gameStatusText.text = "Game Over!\n" + gameStatus + "\nScore: " + score;
                gameStatusText.color = Color.red;
                gameStatusText.transform.Rotate(0, .1f, 0);
                break;
        }
    }

    private void car_spawn_handler()
    {
        tick += 1;

        if (tick >= waitTick)
        {
            spawn_car(Random.Range(0, 4));
            tick = 0;

            waitTick = Random.Range(minSpawnSeconds, maxSpawnSeconds);

        }

        if(gameSeconds >= 10) // increase spawn rate every 10 seconds
        {
            gameSeconds = 0;

            if(minSpawnSeconds > 30) { minSpawnSeconds -= 25; }
            if(maxSpawnSeconds > 60) { maxSpawnSeconds -= 50; }
            
            
        }

    }

    private void spawn_car(int spawn)
    {

        GameObject temp = Instantiate(car, spawnParent.transform);
        temp.transform.localScale = spawnPos[spawn].transform.localScale;
        temp.transform.position = spawnPos[spawn].transform.position;

        switch(spawn)
        {
            case 0:
                temp.transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;

            case 1:
                temp.transform.localRotation = Quaternion.Euler(0, 180, 0);
                break;

            case 2:
                temp.transform.localRotation = Quaternion.Euler(0, 270, 0);
                break;

            case 3:
                temp.transform.localRotation = Quaternion.Euler(0, 90, 0);
                break;
        }
        
    }
}
