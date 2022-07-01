using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet; 
    [SerializeField] private float bulletsAmount; //How many bullets should the enemy shooter have
    [SerializeField] private List<GameObject> enemyBullets;
    private float coolDown; //Cooldown time between 2 enemy shots
    private int shotType; //0 is straight, 1 will aim at you, 2 is kamikaza
    private bool startShooting = false;

    public bool FirstShot
    {
        get => firstShot;
        set => firstShot = value;
    }
    public bool firstShot = false;
    // Start is called before the first frame update
    void Awake()
    {

        for (int i = 0; i < bulletsAmount; i++)
        {
            GameObject temp = Instantiate(enemyBullet);
            enemyBullets.Add(temp);
            enemyBullets[i].SetActive(false);


        }

        coolDown = 3f;
    }
    
    public void SetShooter(float cool, int type)
    {
        coolDown = cool;
        shotType = type;
        startShooting = true;
    }

    void EnemyShoot()
    {
        GameObject temp; 
        EnemyBullet bulletScript;
        for (int i = 0; i < bulletsAmount; i++)
        {
            if (!enemyBullets[i].activeInHierarchy)
            {
                temp = enemyBullets[i];
                temp.transform.position = transform.position;
                temp.transform.rotation = transform.rotation;
                bulletScript = temp.GetComponent<EnemyBullet>();
                bulletScript.enabled = true;
                temp.SetActive(true);
                bulletScript.EnemyShoot(shotType);
                SoundManager._shared.PlaySound("enemyBullet");
                break;
            }
        }
    }
    
    IEnumerator DelayShot()
    {
        while (true)
        {
            EnemyShoot();
            yield return new WaitForSeconds(coolDown);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (startShooting && firstShot)
        {
            StartCoroutine(DelayShot());
            startShooting = false;
        }
    }
}
