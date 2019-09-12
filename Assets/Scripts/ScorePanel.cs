using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] Text diamondsText;
    [SerializeField] Text coinsText;
    [SerializeField] Text tapsText;
    [SerializeField] Player player;
    [SerializeField] LevelsData levelsData;

    private int diamonds;
    private int coins;
    private int taps;
    void Awake()
    {
        player.LoadPlayer();
        taps = levelsData.getLevelTaps(player.GetNextLevelIndex());
        coins = player.GetTotalCoins();
        diamonds = player.GetTotalDiamonds();
    }

    void Start()
    {
        diamondsText.text = diamonds.ToString();
        coinsText.text = coins.ToString();
        tapsText.text = taps.ToString();
    }
}
