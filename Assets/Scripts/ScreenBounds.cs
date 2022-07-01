using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager._shared.GameOver();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
