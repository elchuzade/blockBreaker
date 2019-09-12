using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int totalCoins = 90;
    private int totalStars;
    private int totalDiamonds = 30;
    private int activeBallSkinIndex;
    private int nextLevelIndex = 1;
    private int[] passedLevelsWithStars = { 3, 2, 3, 1, 3, 3, 1, 3, 3, 3, 1, 2, 3, 3, 2, 1, 1, 2, 2, 1, 3, 1, 2, 3, 1};
    private int[] ballSkins = { 0 };
    private int activeMapIndex;
    private int activeLevelIndex;
    private int lastLevelCoins;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        activeMapIndex = data.activeMapIndex;
        activeLevelIndex = data.activeLevelIndex;
        totalCoins = data.totalCoins;
        totalDiamonds = data.totalDiamonds;
        activeBallSkinIndex = data.activeBallSkinIndex;
        passedLevelsWithStars = data.passedLevelsWithStars;
        ballSkins = data.ballSkins;
    }
    // Active Map Index
    public void SetActiveMapIndex(int index)
    {
        activeMapIndex = index;
    }
    public int GetActiveMapIndex()
    {
        return activeMapIndex;
    }
    // Active Level Index
    public void SetActiveLevelIndex(int index)
    {
        activeLevelIndex = index;
    }
    public int GetActiveLevelIndex()
    {
        return activeLevelIndex;
    }
    // Total Coins
    public void SetTotalCoins(int coins)
    {
        totalCoins = coins;
    }
    public int GetTotalCoins()
    {
        return totalCoins;
    }
    // Total Diamonds
    public void SetTotalDiamonds(int diamonds)
    {
        totalDiamonds = diamonds;
    }
    public int GetTotalDiamonds()
    {
        return totalDiamonds;
    }
    // Passed levels with stars (Debug purpose only)
    public void SetPassedLevelsWithStars(int[] levels)
    {
        passedLevelsWithStars = levels;
    }
    public int[] GetPassedLevelsWithStars()
    {
        return passedLevelsWithStars;
    }
    // Get Length of passedLevelsWithStars
    public int GetPassedLevelsWithStarsLength()
    {
        return passedLevelsWithStars.Length;
    }
    // Next level index
    public void SetNextLevelIndex(int index)
    {
        nextLevelIndex = index;
    }
    public int GetNextLevelIndex()
    {
        return nextLevelIndex;
    }
    // Balls skins
    public void SetBallSkins(int[] skins)
    {
        ballSkins = skins;
    }
    public int[] GetBallSkins()
    {
        return ballSkins;
    }
    // Active ball skin index
    public void SetActiveBallSkinIndex(int index)
    {
        activeBallSkinIndex = index;
    }
    public int GetActiveBallSkinIndex() {
        return activeBallSkinIndex;
    }
    // Set Last level coins
    public void SetLastLevelCoins(int coins)
    {
        lastLevelCoins = coins;
    }
    public int GetLastLevelCoins()
    {
        return lastLevelCoins;
    }
}
