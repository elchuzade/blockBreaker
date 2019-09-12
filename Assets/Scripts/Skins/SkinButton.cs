using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinButton : MonoBehaviour
{
    [SerializeField] Player player;
    public int index;
    public int price;

    public void BuyNewSkin()
    {
        player.LoadPlayer();
        bool exists = false;
        int[] ballSkins = player.GetBallSkins();
        // Check if the ball you are clicking on is already purchased
        for (int i = 0; i < ballSkins.Length; i++)
        {
            if (ballSkins[i] == index)
            {
                exists = true;
                break;
            }
        }
        if (!exists)
        {
            int[] extendedBallSkins = new int[ballSkins.Length + 1];
            for (int i = 0; i < ballSkins.Length; i++)
            {
                extendedBallSkins[i] = ballSkins[i];
            }
            extendedBallSkins[extendedBallSkins.Length - 1] = index;
            System.Array.Sort(extendedBallSkins);
            player.SetBallSkins(extendedBallSkins);
            player.SetTotalCoins(player.GetTotalCoins() - price);
        }
        player.SetActiveBallSkinIndex(index);
        player.SavePlayer();
        SceneManager.LoadScene("Skins");
    }
}
