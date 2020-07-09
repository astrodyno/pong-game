using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    bool gamePaused;
    Rigidbody2D ball;
    int player1Score = 0;
    int player2Score = 0;
    int roundCount = 0;
    GameObject Scoreboard;
    public float maxSpeed = 7f;
    public float maxVelocity = 30f;



    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        Scoreboard = GameObject.FindWithTag("Scoreboard");
        Scoreboard.SetActive(false);
        pushBall();
        gamePaused = false;
    }

    
    
    
    void Update()
    {
        ball.velocity = Vector2.ClampMagnitude(ball.velocity, maxVelocity);
        if (Input.GetKeyDown("space"))
        {
            if (!gamePaused) return;

            Scoreboard.SetActive(false);
            pushBall();
            Time.timeScale = 1f;
            gamePaused = false;
        }
    }
    void OnCollisionExit2D(Collision2D other)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    
    
    void pushBall()
    {
        if (roundCount % 2 == 0)
        {
            ball.velocity = new Vector3(1f * 8f, 0, 0);
        }
        else
        {
            ball.velocity = new Vector3(-1f * 8f, 0, 0);
        }
    }

    public void changeP1Score(int amount)
    {
        player1Score += amount;
        resetAndPrintCurrentStatus();
    }

    public void changeP2Score(int amount)
    {
        player2Score += amount;
        resetAndPrintCurrentStatus();
    }

    void resetAndPrintCurrentStatus()
    {


        gamePaused = true;
        roundCount++;

        Player1Controller p1 = GameObject.FindWithTag("player1")
            .GetComponent<Player1Controller>();

        Player2Controller p2 = GameObject.FindWithTag("player2")
            .GetComponent<Player2Controller>();

        p1.resetPos();
        p2.resetPos();

        transform.position = initialPosition;

        Time.timeScale = 0f;
        Scoreboard.SetActive(true);
        GameObject.FindWithTag("score1")
            .GetComponent<UnityEngine.UI.Text>().text = player1Score + "";

        GameObject.FindWithTag("score2")
            .GetComponent<UnityEngine.UI.Text>().text = player2Score + "";
    }
}