using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float tapForce;
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    private Rigidbody2D ballRigidBody;
    GamePlay gamePlay;

    private void Awake()
    {
        gamePlay = FindObjectOfType<GamePlay>();
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballRigidBody.velocity = new Vector2(speedX, speedY);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && gamePlay.levelTaps > 0)
        {
            ballRigidBody.velocity = Vector2.up * tapForce * 2 + Vector2.right * tapForce;
            gamePlay.OneTapUsed();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gamePlay.levelTaps > 0)
        {
            ballRigidBody.velocity = Vector2.up * tapForce * 2 - Vector2.right * tapForce;
            gamePlay.OneTapUsed();
        }
    }
}
