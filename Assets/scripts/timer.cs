using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public  float maxtime;
    public  float timelift;
    //private GameConterolerFromMenu gp;
    private GameplayController gameplayController;


    public void Awake()
    {
        gameplayController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
        timelift = maxtime;
        
    }


    void Update()
    {
        if (gameplayController.gamebegin)
        {
            if (timelift > 0)
            {
                timelift -= Time.deltaTime;

            }
            else
            {
                print("gameover");
                gameplayController.gameover();
            }
            GetComponent<Slider>().value = timelift / maxtime;
        }
    }

}