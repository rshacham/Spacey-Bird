using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject bulletObject;
    private List<Action> shotTypes; //will hold functions for each of the shot types
    private Rigidbody2D bulletRigid;
    private Transform bulletTransform;
    [SerializeField] private float straightSpeed; //Speed of the bullet when it's shooted straight

    // Start is called before the first frame update
    void Awake()
    {
        //bulletObject = GetComponent<GameObject>();
        bulletRigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //shotTypes.Add(StraightShot);
        //shotTypes.Add(AimedShot);
        //shotTypes.Add(CircularShot);
    }

    void StraightShot()
    {
        bulletRigid.velocity = new Vector2(straightSpeed, 0f);
    }

    void AimedShot()
    {
        
    }

    void CircularShot()
    {
        
    }

    public void EnemyShoot(int type)
    {
        switch (type)
        {
            case 0:
                StraightShot();
                break;
            case 1:
                AimedShot();
                break;
            case 2:
                CircularShot();
                break;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BulletWall"))
        {
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Flappy"))
        {
            GameManager._shared.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
