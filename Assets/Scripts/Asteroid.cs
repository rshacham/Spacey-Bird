using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D asteroidRigid;

    [SerializeField] private float asteroidSpeed;
    // Start is called before the first frame update
    void Start()
    {
        asteroidRigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BulletWall"))
        {
            gameObject.SetActive(false);
            GameManager._shared.AsteroidsDestroyed += 1;
        }

        if (other.CompareTag("FlappyBullet"))
        {
            GameManager._shared.score += 100;
            SoundManager._shared.PlaySound("hitSound");
            gameObject.SetActive(false);

        }
        
        if (other.CompareTag("Flappy"))
        {
            GameManager._shared.GameOver();
        }

    }

    // Update is called once per frame
    void Update()
    {
        asteroidRigid.velocity = new Vector3(-1f* asteroidSpeed*(GameManager._shared.MyLevel/1.75f), 0, 0);
        if (gameObject.transform.position.x < 0)
        {
            //GameManager._shared.score +=100;
        }
    }
}
