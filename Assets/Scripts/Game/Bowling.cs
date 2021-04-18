using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowling : MonoBehaviour
{
    private bool puntaje = true;
    private const int AngleMax = 45;

    void Update()
    {
        if (puntaje)
        {
            if (Vector3.Angle(transform.up, Vector3.up) >= AngleMax)
            {
                puntaje = !puntaje;
                GameManager.addToScore(10);
            }
        }
    }
}
