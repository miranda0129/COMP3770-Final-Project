using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiDisplay : MonoBehaviour
{
    Level levelManager;
    public Player player;

    public string health;
    public string score;
    public string enemiesKilled;
    public string level;

    public Text healthText;
    public Text scoreText;
    public Text killText;
    

    private void Start()
    {
        levelManager = GameObject.Find("Level").GetComponent<Level>();
       

    }

    private void Update()
    {
        player = levelManager.GetPlayer().GetComponent<Player>();
        health = player.hpRemaining.ToString();
        score = levelManager.score.ToString();
        enemiesKilled = levelManager.enemiesKilled.ToString();

        healthText.text = "Health: " + health;
        scoreText.text = "Coins: " + score;
        killText.text = "Kills: " + enemiesKilled;
    }
}
