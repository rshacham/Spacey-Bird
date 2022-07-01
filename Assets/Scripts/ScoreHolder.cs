using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreHolder : MonoBehaviour
{
    public static ScoreHolder _shared;

    public int HighScore
    {
        get => highScore;
        set => highScore = value;
    }
    private int highScore = 0;

    private void Awake()
    {
        _shared = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
