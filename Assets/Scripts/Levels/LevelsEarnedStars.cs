using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsEarnedStars : MonoBehaviour
{
    [SerializeField] Text earnedStarsText;

    [SerializeField] Player player;
    private int earnedStars;
    private int totalStars = 30;
    private int mapIndex;

    private void Awake()
    {
        player.LoadPlayer();
        mapIndex = player.GetActiveMapIndex();
        for(int i = mapIndex*10; i < (mapIndex+1)*10; i++)
        {
            if (i < player.GetPassedLevelsWithStars().Length)
            {
                earnedStars += player.GetPassedLevelsWithStars()[i];
            } else
            {
                break;
            }
        }
        
    }

    private void Start()
    {
        earnedStarsText.text = earnedStars.ToString();
    }
}
