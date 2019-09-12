using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseManager : MonoBehaviour
{
    Player player;
    private int levelCoins;
    [SerializeField] Text loseScoreText;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        player.LoadPlayer();
        levelCoins = player.GetLastLevelCoins();

    }
}
