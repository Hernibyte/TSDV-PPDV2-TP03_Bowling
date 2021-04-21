using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private Ball ballScript;
    private float timer;
    public static int fails { set;  get; }
    private bool failCountFix = true;

    private void Awake()
    {
        ballScript = ball.GetComponent<Ball>();
        ballScript.shoot = false;
        ball.SetActive(false);
        fails = 3;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SetActiveGame();
        }

        if (ballScript.shoot && ConstData.Score < 80 && fails != 0)
        {
            ResetShoot();
        } 
        if (ConstData.Score == 80 || fails == 0)
        {
            EndGame();
        }
    }

    void SetActiveGame()
    {
        ball.SetActive(true);
    }

    void ResetShoot()
    {
        Debug.Log("Timer activated");
        timer += Time.deltaTime;

        if (timer >= 6f)
        {
            if (failCountFix)
            {
                fails -= 1;
                failCountFix = false;
            }
            Debug.Log("Press Return key to reset");
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Reseted");
                ballScript.ResetParameters();
                timer = 0f;
                ballScript.shoot = false;
                failCountFix = true;
                Debug.Log("---------------");
            }
        }
    }

    public static void addToScore(int _score)
    {
        ConstData.Score += _score;
    }

    public static void EndGame()
    {
        SceneManager.LoadScene("EndGameScreen");
    }
}
