using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake_raul : IMiniGame
{

    private GameManager gameManager;
    public GameObject game;
    public GameObject gameCamera;

    void Awake()
    {

    }

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
        game.SetActive(true);
        gameCamera.SetActive(true);
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public void EndGame(bool win)
    {
        if (win)
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
        else
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
    }

    public override string ToString()
    {
        return "Snake by Raul Reche";
    }
}