using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Text Try;
    [SerializeField] private Text Points;
    [SerializeField] private Text Finish;

    void Start()
    {
        
    }

    void Update()
    {
        updateTrys();
        updatePoints();
        updateFinish();
    }

    void updateTrys()
    {
        Try.text = "Try: " + GameManager.fails.ToString();
    }

    void updatePoints()
    {
        Points.text = "Points: " + ConstData.Score.ToString();
    }

    void updateFinish()
    {
        if (ConstData.Score == 80 && GameManager.fails == 3)
        {
            Finish.text = "Strike!";
        }
        if (ConstData.Score == 80 && GameManager.fails != 3)
        {
            Finish.text = "You Win!";
        }
        if (ConstData.Score != 80 && GameManager.fails == 0)
        {
            Finish.text = "Try again!";
        }
    }
}
