using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockedButton : MonoBehaviour
{
    [SerializeField] Player player;
    public Text earnedStarsText;
    public int index;

    public void LoadMapByIndex()
    {
        player.LoadPlayer();
        player.SetActiveMapIndex(index);
        player.SavePlayer();
        // Load scene as Map1, Map2, Map3...
        SceneManager.LoadScene("Levels");
    }
}
