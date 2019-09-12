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
}
