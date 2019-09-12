using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapsEarnedStars : MonoBehaviour
{
    [SerializeField] Text earnedStarsText;
    [SerializeField] Text totalStarsText;
    [SerializeField] Player player;

    private int earnedStars;
    private int totalStars;
    // Start is called before the first frame update
    private void Awake()
    {
        player.LoadPlayer();
        totalStars = player.GetPassedLevelsWithStarsLength() * 3;
        for (int i = 0; i < player.GetPassedLevelsWithStarsLength(); i++)
        {
            earnedStars += player.GetPassedLevelsWithStars()[i];
        }
    }

    void Start()
    {
        earnedStarsText.text = earnedStars.ToString();
        totalStarsText.text = totalStars.ToString();
    }
}
