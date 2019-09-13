using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int totalCoins;
    private int lastLevelStars;
    private int totalDiamonds;
    private int activeBallSkinIndex;
    private int nextLevelIndex = 1;
    private int[] passedLevelsWithStars;
    private int[] ballSkins = { 0 };
    private int activeMapIndex;
    private int activeLevelIndex;
    private int lastLevelCoins;
    private int maxLevelPassed;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        lastLevelStars = data.lastLevelStars;
        activeMapIndex = data.activeMapIndex;
        nextLevelIndex = data.nextLevelIndex;
        totalCoins = data.totalCoins;
        totalDiamonds = data.totalDiamonds;
        activeBallSkinIndex = data.activeBallSkinIndex;
        passedLevelsWithStars = data.passedLevelsWithStars;
        ballSkins = data.ballSkins;
        lastLevelCoins = data.lastLevelCoins;
        maxLevelPassed = data.maxLevelPassed;
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
    // Next Level Index
    public void SetNextLevelIndex(int index)
    {
        nextLevelIndex = index;
    }
    public int GetNextLevelIndex()
    {
        return nextLevelIndex;
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
    // Last level coins
    public void SetLastLevelCoins(int coins)
    {
        lastLevelCoins = coins;
    }
    public int GetLastLevelCoins()
    {
        return lastLevelCoins;
    }
    // Last level stars
    public void SetLastLevelStars(int stars)
    {
        lastLevelStars = stars;
    }
    public int GetLastLevelStars()
    {
        return lastLevelStars;
    }
    // Max level passed
    public void SetMaxLevelPassed(int maxLevel)
    {
        maxLevelPassed = maxLevel;
    }
    public int GetMaxLevelPassed()
    {
        return maxLevelPassed;
    }
}
