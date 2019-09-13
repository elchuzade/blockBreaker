using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockedLevel : MonoBehaviour
{
    [SerializeField] Player player;
    public int index;

    public void LoadLevelByIndex()
    {
        player.LoadPlayer();
        int levelIndex = player.GetActiveMapIndex() * 10 + index;
        player.SetNextLevelIndex(index);
        player.SavePlayer();
        SceneManager.LoadScene("Level" + levelIndex);
    }
}
