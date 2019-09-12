using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinsManager : MonoBehaviour
{
    [SerializeField] Player player;
    public Sprite[] ballSkins = new Sprite[12];
    public GameObject Skin;
    public Transform Content;
    private int[] PlayerBallSkins;
    private int[] ballsWithPrices = { 0, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100 };

    private void Awake()
    {
        player.LoadPlayer();
        PlayerBallSkins = player.GetBallSkins();
        for(int i = 0; i < PlayerBallSkins.Length;i++)
        {
            Debug.Log(i + " - " + PlayerBallSkins[i] + " - " + PlayerBallSkins.Length);
        }
        int playerBallSkinIndex = 0;

        for (int i = 0; i < ballsWithPrices.Length; i++)
        {
            // Creating a new skin
            GameObject newSkin = Instantiate(Skin) as GameObject;
            // Conenct a SkinButton script to an object to be able to acceess index and price
            SkinButton newSkinButton = newSkin.GetComponent<SkinButton>();
            newSkinButton.index = i;
            newSkinButton.price = ballsWithPrices[i];
            // Setting a parent Content to scroll
            newSkin.transform.SetParent(Content);
            // Setting a ball sprite of each skin from sprites array
            GameObject SkinBallBG = newSkin.transform.GetChild(0).gameObject;
            SkinBallBG.GetComponent<SpriteRenderer>().sprite = ballSkins[i];
            // Setting a green frame around active ball
            GameObject ActiveBallSkinBG = newSkin.transform.GetChild(2).gameObject;
            if (player.GetActiveBallSkinIndex() != i)
            {
                ActiveBallSkinBG.GetComponent<SpriteRenderer>().enabled = false;
            }
            // Removing price tag from the skins that are already purchased
            // And making colors of affordable skins green the rest red
            if (playerBallSkinIndex < PlayerBallSkins.Length && PlayerBallSkins[playerBallSkinIndex] == i)
            {
                newSkinButton.price = 0;
                playerBallSkinIndex++;
            }
            else
            {
                GameObject SkinPriceText = newSkin.transform.GetChild(1).gameObject;
                SkinPriceText.GetComponent<Text>().text = ballsWithPrices[i].ToString();
                if (player.GetTotalCoins() >= ballsWithPrices[i])
                {
                    // Affordable
                    SkinPriceText.GetComponent<Text>().color = new Color(0.0f / 255.0f, 255.0f / 255.0f, 0.0f / 255.0f);
                }
                else
                {
                    // Unaffordable
                    SkinPriceText.GetComponent<Text>().color = new Color(255.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
                    // Make button untouchable
                    newSkinButton.GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
