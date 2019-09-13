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

    public bool movable = true;
    public bool readyToTap;

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
        if (movable)
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
        } else
        {
            // Place an object in the center of the screen
            gameObject.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.06f, 10f));
        }
        LaunchBallAfterExtraTapsReceived();
    }

    private void LaunchBallAfterExtraTapsReceived()
    {
        if (!movable && readyToTap)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && gamePlay.levelTaps > 0)
            {
                ballRigidBody.velocity = Vector2.up * tapForce * 2 + Vector2.right * tapForce;
                gamePlay.OneTapUsed();
                movable = true;
                readyToTap = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && gamePlay.levelTaps > 0)
            {
                ballRigidBody.velocity = Vector2.up * tapForce * 2 - Vector2.right * tapForce;
                gamePlay.OneTapUsed();
                movable = true;
                readyToTap = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BottomWall")
        {
            movable = false;
            gamePlay.Lost();
        }
    }

    public void ToggleCollisionOption()
    {
        if (gameObject.GetComponent<CircleCollider2D>().enabled)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        } else
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        
    }
}
