﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Player player;

    public void SetFakePlayerValues()
    {
        player.SetTotalCoins(0);
        player.SetTotalDiamonds(0);
        player.SetNextLevelIndex(1);
        player.SetMaxLevelPassed(1);
        int[] passedLevelsList = { };
        player.SetPassedLevelsWithStars(passedLevelsList);
        int[] ballSkins = { 0 };
        player.SetBallSkins(ballSkins);
        player.SetActiveBallSkinIndex(0);
        player.SavePlayer();
        SceneManager.LoadScene("MainMenu");
    }

    private void Awake()
    {
        player.LoadPlayer();
    }

    public void PlayNextLevel()
    {
        SceneManager.LoadScene("Level" + player.GetMaxLevelPassed());

    }
    public void OpenMaps()
    {
        SceneManager.LoadScene("Maps");
    }
    public void OpenSkins()
    {
        SceneManager.LoadScene("Skins");
    }
    public void OpenShop()
    {
        Debug.Log("Opened Shop");

    }
    public void OpenOptions()
    {
        SceneManager.LoadScene("MainMenuOptions");
    }

}
