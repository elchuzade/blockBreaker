using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    GamePlay gamePlay;


    private void Awake()
    {
        gamePlay = FindObjectOfType<GamePlay>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            gamePlay.RefreshTaps();
            if (gamePlay.starsAmount == 1)
            {
                DestroyPaddle();
            }
        }
    }
    private void DestroyPaddle()
    {
        Destroy(gameObject, 0.5f);
    }
}
