using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Player player;

    private void SetFakePlayerValues()
    {
        player.SetTotalCoins(1600);
        player.SetTotalDiamonds(50);
        int[] passedLevelsList = { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2};
        player.SetPassedLevelsWithStars(passedLevelsList);
        int[] ballSkins = { 0 };
        player.SetBallSkins(ballSkins);
        player.SetActiveBallSkinIndex(0);
        player.SavePlayer();
    }

    private void Awake()
    {
        SetFakePlayerValues();
        player.LoadPlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayNextLevel()
    {
        Debug.Log("Launching next level");

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
