using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    LevelsData levelsData;
    Player player;
    private int levelIndex;
    public int levelTaps;
    public int starsAmount;
    private int totalCoins;
    private int levelCoins;
    [SerializeField] Text tapsText;
    [SerializeField] Text coinsText;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    [SerializeField] Sprite[] ballSpriteList = new Sprite[12];

    [SerializeField] Ball ball;

    [SerializeField] GameObject extraTaps;

    [SerializeField] Text extraTapsTimerDigit;

    private int breakableBlocks;
    private bool extraTapsUsed;
    private float timer;
    private int secondsToDecideExtraTaps = 5;
    private bool tapsReceived;


    private void Awake()
    {
        player = FindObjectOfType<Player>();
        player.LoadPlayer();

        GameObject ballSkin = ball.transform.GetChild(0).gameObject;
        ballSkin.GetComponent<SpriteRenderer>().sprite = ballSpriteList[player.GetActiveBallSkinIndex()];

        levelsData = FindObjectOfType<LevelsData>();
        RefreshLevelTapsWithoutStarCharge();
    }

    void Update()
    {
        showScorePanel();
        showStars();
        if (extraTapsUsed && !tapsReceived)
        {
            CountDownExtraTaps();
        }
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            // Passed the levels load win scene
            Debug.Log("won level!!!");
        }
    }

    public void AddCoins()
    {
        levelCoins++;
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void showScorePanel()
    {
        tapsText.text = levelTaps.ToString();
        coinsText.text = (player.GetTotalCoins()+levelCoins).ToString();
    }

    public void showStars()
    {
        switch (starsAmount)
        {
            case 3:
                star1.GetComponent<Image>().enabled = true;
                star2.GetComponent<Image>().enabled = true;
                star3.GetComponent<Image>().enabled = true;
                break;
            case 2:
                star1.GetComponent<Image>().enabled = true;
                star2.GetComponent<Image>().enabled = true;
                star3.GetComponent<Image>().enabled = false;
                break;
            case 1:
                star1.GetComponent<Image>().enabled = true;
                star2.GetComponent<Image>().enabled = false;
                star3.GetComponent<Image>().enabled = false;
                break;
            default:
                star1.GetComponent<Image>().enabled = false;
                star2.GetComponent<Image>().enabled = false;
                star3.GetComponent<Image>().enabled = false;
                break;
        }
    }

    public void OneTapUsed()
    {
        levelTaps--;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RefreshTaps()
    {
        RefreshLevelTapsWithoutStarCharge();
        starsAmount--;
    }

    public void Lost()
    {
        if (!extraTapsUsed)
        {
            // Give extra life
            extraTapsUsed = true;
            extraTaps.SetActive(true);
            ball.ToggleCollisionOption();
        } else
        {
            // Lose the game take to the lose window
            player.SetLastLevelCoins(levelCoins);
            player.SavePlayer();
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void CountDownExtraTaps()
    {
        timer += Time.deltaTime;
        int seconds = (int)(timer % 60);
        int timeLeft = secondsToDecideExtraTaps - seconds;
        extraTapsTimerDigit.text = timeLeft.ToString();
        if (timeLeft == 0)
        {
            Lost();
        }
    }

    public void ReceiveExtraTaps()
    {
        tapsReceived = true;
        RefreshLevelTapsWithoutStarCharge();
        extraTaps.SetActive(false);
        ball.readyToTap = true;
        ball.ToggleCollisionOption();
    }

    public void RefreshLevelTapsWithoutStarCharge()
    {
        levelTaps = levelsData.allLevelsTapsAmounts[levelIndex];
    }
}
