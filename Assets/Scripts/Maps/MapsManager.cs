using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MapsManager : MonoBehaviour
{
    [SerializeField] Player player;
	public GameObject MapUnlocked;
	public GameObject MapLocked;
	public Transform Content;

	private int starsCount; // To count stars earned from each map
    private int[] starsCountList; // List of stars earned for each ten levels ie one map
    private int totalMaps = 10;
    private int counter; // To keep track of map indexes in starsCountList

    private void Awake()
    {
        player.LoadPlayer();
        starsCountList = new int[player.GetPassedLevelsWithStarsLength() / 10 + 1];
        // Loop through all levels of all maps
        for (int i = 0; i < totalMaps*10; i++)
        {
            // Check if the level is passed
            if (player.GetPassedLevelsWithStarsLength() > i)
            {
                // Indicate each map levels separation (10 levels in 1 map)
                if (i > 0 && i % 10 == 0)
                {
                    // Assign the cumulative value of stars of the current map and refresh the starsCount for the next map
                    starsCountList[counter] = starsCount;
                    counter++;
                    starsCount = 0;
                }
                // Add the amount of stars earned from that level to the starsCount
                starsCount += player.GetPassedLevelsWithStars()[i];
            } else
            {
                // This level has not been passed yet, thus add whatever amount of stars till not was earned in this map and break the loop
                starsCountList[counter] = starsCount;
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // For each map create its corresponding button if it is passed unlocked button else locked button
        for (int i = 0; i < totalMaps; i ++)
		{
            // If the map index is in less than starsCountList length, it means the map is passed
            if( i < starsCountList.Length)
            {
                // Create a new GameObject
                GameObject unlockedMap = Instantiate(MapUnlocked) as GameObject;
                // Connect to the Script
                UnlockedButton unlockedButton = unlockedMap.GetComponent<UnlockedButton>();
                unlockedButton.transform.SetParent(Content);

                unlockedButton.earnedStarsText.text = starsCountList[i].ToString();
                unlockedButton.index = i;
            }
            else
            {
                GameObject lockedMap = Instantiate(MapLocked) as GameObject;
                lockedMap.transform.SetParent(Content);
            }
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
