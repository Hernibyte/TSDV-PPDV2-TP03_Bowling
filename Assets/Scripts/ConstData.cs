using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstData : MonoBehaviour
{
    private static ConstData Instance;
    public static int Score { set; get; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
