using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseManager : MonoBehaviour
{
    Player player;
    private int levelCoins;
    [SerializeField] Text loseScoreText;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        // Debug
        player.LoadPlayer();
        player.SetLastLevelCoins(20);
        player.SavePlayer();
        // Debug
        player.LoadPlayer();
        levelCoins = player.GetLastLevelCoins();
    }

    private void Update()
    {
        loseScoreText.text = (player.GetTotalCoins() + levelCoins).ToString();
        Invoke("DecreaseLevelCoins", 1f);
    }

    private void DecreaseLevelCoins()
    {
        if(levelCoins > 0)
        {
            levelCoins--;
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene("Level"+player.GetNextLevelIndex());
    }
}
