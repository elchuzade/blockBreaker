using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
	public int totalCoins;
	public int totalDiamonds;
    public int activeBallSkinIndex;
    public int nextLevelTapsAmount;
    public int nextLevelIndex;
	public int[] passedLevelsWithStars;
	public int[] ballSkins;
    public int activeMapIndex;
    public int lastLevelCoins;

    public PlayerData(Player player)
	{
        passedLevelsWithStars = player.GetPassedLevelsWithStars();
        ballSkins = player.GetBallSkins();
        totalCoins = player.GetTotalCoins();
        totalDiamonds = player.GetTotalDiamonds();
        activeBallSkinIndex = player.GetActiveBallSkinIndex();
        nextLevelIndex = player.GetNextLevelIndex();
        activeMapIndex = player.GetActiveMapIndex();
        lastLevelCoins = player.GetLastLevelCoins();
    }
}

