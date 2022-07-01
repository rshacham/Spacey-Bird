using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _shared;

    [SerializeField] private float minBulletCooldown, maxBulletCooldown; //The starting minDelay and maxDelay of the enemyBullets, may change as the game progress
    [SerializeField] private Vector2 yRange; //The ranges of the camera and specifically where enemies can spawn
    [SerializeField] private Vector2 astFreqRange; //The minimum and maximum cooldown time between 2 generated asteroids
    [SerializeField] private float enemyX; //The x value of the enemies when they spawn
    [SerializeField] private float asteroidX;
    [SerializeField] private int enemyTypesAmount; //How many different kinds of enemies are they, to choose from
    [SerializeField] private GameObject myEnemy;
    [SerializeField] private int enemyMaxAmount; //How many different enemies can live together
    [SerializeField] private List<GameObject> myEnemies;
    [SerializeField] private GameObject myAsteroid;
    [SerializeField] private List<GameObject> myAsteroids;
    [SerializeField] private GameObject gameOverMsg;

    public bool Over
    {
        get => gameOver;
        set => gameOver = value;
    }
    private bool gameOver = false;

    public int highscore
    {
        get { return highScore;}
        set { highScore = value;}
    }
    public int score
    {
        get { return myScore;}
        set { myScore = value; }
    }

    public int MyLevel
    {
        get => myLevel;
        set => myLevel = value;
    }

    public int myScore;
    public int myLevel;
    [SerializeField] private int highScore;
    [SerializeField] private float secondsPerPoints;
    [SerializeField] private int asteroidsCheckpoint;
    public int livingEnemies = 0;

    public int AsteroidsCheckpoint
    {
        get => asteroidsCheckpoint;
        set => asteroidsCheckpoint = value;
    }
    public int AsteroidsDestroyed
    {
        get => asteroidsDestroyed;
        set => asteroidsDestroyed = value;
    }
    public int asteroidsDestroyed = 0;
    private bool enemyActive;

    private void Awake()
    {
        _shared = this;
        highScore = ScoreHolder._shared.HighScore;
        score = 10;
    }

    void Start()
    {
        for (int i = 0; i < enemyMaxAmount; i++)
        {
            GameObject temp;
            temp = Instantiate(myEnemy);
            myEnemies.Add(temp);
            myEnemies[i].SetActive(false);
        }
        
        for (int i = 0; i < 7; i++)
        {
            GameObject temp;
            temp = Instantiate(myAsteroid);
            myAsteroids.Add(temp);
            myAsteroids[i].SetActive(false);
        }
        myLevel = 1;
        
        StartCoroutine(GenerateAsteroids());
        StartCoroutine(UpdateScore());

    }

    public void GenerateEnemy()
    {
        GameObject enemy;
        Enemy enemyScript;
        float coolDown;
        int type;
        float yPosition = Random.Range(yRange.x, yRange.y);
        for (int i = 0; i < enemyMaxAmount; i++)
        {
            if (!myEnemies[i].activeInHierarchy)
            {
                livingEnemies += 1;
                enemy = myEnemies[i];
                enemy.transform.position = new Vector3(enemyX, yPosition, -1f);
                enemy.SetActive(true);
                coolDown = Random.Range(minBulletCooldown, maxBulletCooldown);
                type = Random.Range(0, enemyTypesAmount);
                enemyScript = enemy.GetComponent<Enemy>();
                enemyScript.SetEnemy(coolDown, type);
                break;
            }
            
        }
    }

    void GenerateEnemies()
    {
        int amount = Random.Range(1, MyLevel);
        for (int i = 0;i < amount; i++)
        {
            GenerateEnemy();
        }
    }

    void GenerateAsteroid()
    {
        GameObject asteroid;
        float yPosition = Random.Range(yRange.x, yRange.y);

        for (int i = 0; i < enemyMaxAmount; i++)
        {
            if (!myAsteroids[i].activeInHierarchy)
            {
                asteroid = myAsteroids[i];
                asteroid.transform.position = new Vector3(asteroidX, yPosition, -1f);
                asteroid.SetActive(true);
                break;
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {


        if (gameOver && (Input.GetKey(KeyCode.R)))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        if (asteroidsCheckpoint == asteroidsDestroyed)
        {
            //StopCoroutine(GenerateAsteroids());
            GenerateEnemy();
            asteroidsDestroyed = 0;
        }
        print(asteroidsDestroyed);
    }

    private IEnumerator GenerateAsteroids()
    {
        
        while (true)
        {
            float coolDown = Random.Range(astFreqRange.x, astFreqRange.y);
            if (!enemyActive)
            {
                GenerateAsteroid();
            }
            yield return new WaitForSeconds(coolDown);
        }
    }

    private IEnumerator UpdateScore()
    {
        while (true)
        {
            myScore += 10;
            yield return new WaitForSeconds(secondsPerPoints);
        }
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        gameOverMsg.SetActive(true);
        if (score > highScore)
        {
            highScore = score;
            ScoreHolder._shared.HighScore = score;
        }
    }

}
