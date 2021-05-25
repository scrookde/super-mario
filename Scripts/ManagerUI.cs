using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerUI : MonoBehaviour
{
    public PlayerMovement playerMovementScript;
    public AudioManager audioManagerScript;

    //https://strategywiki.org/wiki/Super_Mario_Bros./Enemies Score Lookup
    //https://www.mariowiki.com/Super_Mario_Bros. Score Lookup

    //Score Values
    public int score = 0;
    private int goombaScore = 100;
    private int koopaTroopaScore = 100;
    private int coinsScore = 200;
    private int mushroomScore = 1000;
    private int coinScore = 200;

    //Coins Values
    public int coins = 0;
    private int coinsValue = 1;

    //World Values


    //Time Values
    public float timer = 400.0f;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI worldText;
    public TextMeshProUGUI timeText;

    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime * 2.5f;
            timeText.text = "TIME\n" + timer.ToString("000");
        }
        else if (timer <= 0)
        {
            playerMovementScript.anim.SetBool("dead", true);
        }
        return;
    }

    public void ForGoomba()
    {
        score = score + goombaScore;
        scoreText.text = "MARIO\n" + score.ToString("000000");
    }

    public void ForKoopaTroopa()
    {
        score = score + koopaTroopaScore;
        scoreText.text = "MARIO\n" + score.ToString("000000");
    }

    public void ForCoins()
    {
        audioManagerScript.CoinAudio();
        score = score + coinScore;
        scoreText.text = "MARIO\n" + score.ToString("000000");
    }

    public void ForMushroom()
    {
        score = score + mushroomScore;
        scoreText.text = "MARIO\n" + score.ToString("000000");
    }

    public void ForScore()
    {
        score = score + coinScore;
        scoreText.text = "MARIO\n" + score.ToString("000000");

        coins++;
        coinsText.text = "0x" + coins.ToString("00");
    }
}
