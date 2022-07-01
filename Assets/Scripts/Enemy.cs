using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject myEnemy;
    private Rigidbody2D enemyRigid;
    private int enemyLife;
    private EnemyShooter myShooter;
    private bool shootBullet = false; // Enemy won't shoot bullets until this is true
    private int direction = 1;
    [SerializeField] private float startShooting; //The X position where the enemy would start shooting
    [SerializeField] private float yBounds; //The y coordinates enemy shouldn't pass
    [SerializeField] private float enemySpeed;
    
    


    // Start is called before the first frame update
    void Awake()
    {
        myShooter = GetComponentInChildren<EnemyShooter>();
        enemyRigid = gameObject.GetComponent<Rigidbody2D>();



    }

    private void OnEnable()
    {
        enemyLife = 5;
    }

    public void SetEnemy(float cool, int type) 
    {
            myShooter.SetShooter(cool, type);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FlappyBullet"))
        {
            SoundManager._shared.PlaySound("hitSound");
            enemyLife -= 1;
            if (enemyLife == 0)
            {
                GameManager._shared.score += 300;
                gameObject.SetActive(false);
                GameManager._shared.livingEnemies -= 1;
                if (GameManager._shared.MyLevel < 3)
                {
                    GameManager._shared.MyLevel += 1;
                    GameManager._shared.AsteroidsCheckpoint += 3;
                }

            }
            other.gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= startShooting)
        {
            myShooter.FirstShot = true;
        }
        
        if (((transform.position.y > yBounds) && (direction == 1)) || ((transform.position.y < -yBounds) && (direction == -1)))
        {
            direction *= -1;
        }
        if (shootBullet)
        {
            if (direction == 1)
            {
                enemyRigid.velocity = new Vector2(0, enemySpeed);
            }
            else
            {
                enemyRigid.velocity = new Vector2(0, -enemySpeed);
            }
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x < startShooting)
        {
            enemyRigid.velocity = new Vector2(enemySpeed*4f, 0);
        }

        if ((transform.position.x >= startShooting) && shootBullet is false)
        {
            shootBullet = true;
            
        }
    }
}
