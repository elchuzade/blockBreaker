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
    private int levelTaps;
    public int starsAmount = 3;
    private int totalCoins;
    [SerializeField] Text tapsText;
    [SerializeField] Text coinsText;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        player.LoadPlayer();
        levelsData = FindObjectOfType<LevelsData>();
        levelTaps = levelsData.allLevelsTapsAmounts[levelIndex];
        tapsText.text = levelTaps.ToString();
        coinsText.text = player.GetTotalCoins().ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    

    public void RefreshTaps()
    {
        levelTaps = levelsData.allLevelsTapsAmounts[levelIndex];
    }
}
