using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    GamePlay level;

    private void Awake()
    {
        level = FindObjectOfType<GamePlay>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GamePlay>().AddCoins();
        Destroy(gameObject, 0f);
        // Decrease from total count
        level.BlockDestroyed();
    }
}
