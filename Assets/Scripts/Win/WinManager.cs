using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    Player player;
    [SerializeField] Text totalCoinsText;
    [SerializeField] Text levelCoinsText;
    [SerializeField] Text levelCoinsMultiplierText;
    [SerializeField] Text levelStarsText;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    [SerializeField] Button adButton;
    [SerializeField] Button collectButton;

    private int levelCoins;
    private int totalCoins;
    private int levelStars;
    private bool adWatched;
    private int levelMultiplier;
    private bool collecting;
    private int resultantLevelCoins;
    private bool multiplierHide;
    private int passedLevelIndex;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        player.LoadPlayer();

        totalCoins = player.GetTotalCoins();
        levelCoins = player.GetLastLevelCoins();
        levelStars = player.GetLastLevelStars();
        levelMultiplier = levelStars;
        resultantLevelCoins = levelCoins;
        passedLevelIndex = player.GetNextLevelIndex();
    }

    public void Start()
    {
        levelStarsText.text = "x " + levelMultiplier;
        totalCoinsText.text = totalCoins.ToString();
        levelCoinsText.text = resultantLevelCoins.ToString();
        ShowStars();
    }

    private void Update()
    {
        if(collecting && resultantLevelCoins > 0)
        {
            if(levelMultiplier > 1)
            {
                Multiplying();
            } else
            {
                if (!multiplierHide)
                {
                    levelStarsText.text = "";
                    multiplierHide = true;
                }
                Collecting();
            }
        }
    }

    private void ShowStars()
    {
        switch (levelStars)
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

    private void Multiplying()
    {
        levelMultiplier--;
        resultantLevelCoins += levelCoins;
        levelStarsText.text = "x " + levelMultiplier;
        levelCoinsText.text = resultantLevelCoins.ToString();
    }

    private void Collecting()
    {
        resultantLevelCoins--;
        totalCoins++;
        levelCoinsText.text = resultantLevelCoins.ToString();
        totalCoinsText.text = totalCoins.ToString();
        // If statement in a shorter version
        collecting &= resultantLevelCoins != 0;
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene("Level" + player.GetNextLevelIndex());
    }

    public void WatchAd()
    {
        if (!adWatched)
        {
            levelMultiplier *= 2;
            levelStarsText.text = "x " + levelMultiplier;
            adButton.interactable = false;
        }
    }

    public void CollectPrize()
    {
        collecting = true;
        if (adButton.interactable)
        {
            adButton.interactable = false;
        }
        collectButton.interactable = false;
    }

    public void ReturnToMainMenu()
    {
        AddLevelToPassedLevels();
        player.SetNextLevelIndex(player.GetNextLevelIndex() + 1);

        if (resultantLevelCoins > 0)
        {
            resultantLevelCoins = levelCoins * levelMultiplier;
            totalCoins += resultantLevelCoins;
        }

        player.SetTotalCoins(totalCoins);

        if (player.GetMaxLevelPassed() < player.GetNextLevelIndex())
        {
            player.SetMaxLevelPassed(player.GetNextLevelIndex());
        }

        player.SavePlayer();
        SceneManager.LoadScene("MainMenu");
    }

    private void AddLevelToPassedLevels()
    {
        if (player.GetNextLevelIndex() > player.GetPassedLevelsWithStars().Length)
        {
            // This is a new level passed
            int[] passedLevelsWithStars = player.GetPassedLevelsWithStars();
            int[] passedLevelsWithStarsPlus = new int[passedLevelsWithStars.Length + 1];
            for (int i = 0; i < passedLevelsWithStars.Length; i++)
            {
                passedLevelsWithStarsPlus[i] = passedLevelsWithStars[i];
            }
            passedLevelsWithStarsPlus[passedLevelsWithStarsPlus.Length - 1] = levelStars;
            player.SetPassedLevelsWithStars(passedLevelsWithStarsPlus);
        } else
        {
            int[] passedLevelsWithStars = player.GetPassedLevelsWithStars();
            // This is a repeated level passed
            if (passedLevelsWithStars[player.GetNextLevelIndex() - 1] < levelStars)
            {
                passedLevelsWithStars[player.GetNextLevelIndex() - 1] = levelStars;
                player.SetPassedLevelsWithStars(passedLevelsWithStars);
            }
        }
        

    }
    public void PlayNextLevel()
    {
        AddLevelToPassedLevels();
        player.SetNextLevelIndex(passedLevelIndex + 1);

        if (resultantLevelCoins > 0)
        {
            resultantLevelCoins = levelCoins * levelMultiplier;
            totalCoins += resultantLevelCoins;
        }

        player.SetTotalCoins(totalCoins);

        if (player.GetMaxLevelPassed() < player.GetNextLevelIndex())
        {
            player.SetMaxLevelPassed(player.GetNextLevelIndex());
        }

        player.SavePlayer();
        SceneManager.LoadScene("Level" + (passedLevelIndex + 1));
    }
}
