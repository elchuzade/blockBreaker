using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] Player player;
    public GameObject LevelUnlockedStar0;
    public GameObject LevelUnlockedStar1;
    public GameObject LevelUnlockedStar2;
    public GameObject LevelUnlockedStar3;
    public GameObject LevelLocked;
    public Transform Content;

    private int mapIndex;
    private int[] levelsWithStars;
    private int totalLevelsPerMap = 10;

    private void Awake()
    {
        bool firstNonPassedLevel = true;
        player.LoadPlayer();
        mapIndex = player.GetActiveMapIndex();
        levelsWithStars = new int[10];
        for (int i = mapIndex*10; i < (mapIndex+1)*10; i++)
        {
            if (i < player.GetPassedLevelsWithStarsLength())
            {
                levelsWithStars[i%10] = player.GetPassedLevelsWithStars()[i];
            } else
            {
                if (firstNonPassedLevel)
                {
                    levelsWithStars[i % 10] = 0;
                    firstNonPassedLevel = false;
                } else
                {
                    levelsWithStars[i % 10] = -1;
                }
                
            }
        }
    }

    private void Start()
    {
        for (int i = 0; i < totalLevelsPerMap; i++)
        {
            switch (levelsWithStars[i])
            {
                case 0:
                    GameObject unlockedLevelStar0 = Instantiate(LevelUnlockedStar0) as GameObject;
                    UnlockedLevel unlockedButton0 = unlockedLevelStar0.GetComponent<UnlockedLevel>();
                    unlockedButton0.index = i;
                    unlockedLevelStar0.transform.SetParent(Content);
                    break;
                case 1:
                    GameObject unlockedLevelStar1 = Instantiate(LevelUnlockedStar1) as GameObject;
                    UnlockedLevel unlockedButton1 = unlockedLevelStar1.GetComponent<UnlockedLevel>();
                    unlockedButton1.index = i;
                    unlockedLevelStar1.transform.SetParent(Content);
                    break;
                case 2:
                    GameObject unlockedLevelStar2 = Instantiate(LevelUnlockedStar2) as GameObject;
                    UnlockedLevel unlockedButton2 = unlockedLevelStar2.GetComponent<UnlockedLevel>();
                    unlockedButton2.index = i;
                    unlockedLevelStar2.transform.SetParent(Content);
                    break;
                case 3:
                    GameObject unlockedLevelStar3 = Instantiate(LevelUnlockedStar3) as GameObject;
                    UnlockedLevel unlockedButton3 = unlockedLevelStar3.GetComponent<UnlockedLevel>();
                    unlockedButton3.index = i;
                    unlockedLevelStar3.transform.SetParent(Content);
                    break;
                default:
                    GameObject lockedLevel = Instantiate(LevelLocked) as GameObject;
                    lockedLevel.transform.SetParent(Content);
                    break;
            }
        }
    }

    public void ReturnToMaps()
    {
        SceneManager.LoadScene("Maps");
    }
}
