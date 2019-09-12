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

    private int breakableBlocks;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        player.LoadPlayer();

        GameObject ballSkin = ball.transform.GetChild(0).gameObject;
        ballSkin.GetComponent<SpriteRenderer>().sprite = ballSpriteList[player.GetActiveBallSkinIndex()];

        levelsData = FindObjectOfType<LevelsData>();
        levelTaps = levelsData.allLevelsTapsAmounts[levelIndex];
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        showScorePanel();
        showStars();
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

    public void TouchedPaddle()
    {
        starsAmount--;
        levelTaps = levelsData.allLevelsTapsAmounts[levelIndex];
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RefreshTaps()
    {
        levelTaps = levelsData.allLevelsTapsAmounts[levelIndex];
        starsAmount--;
    }
}
