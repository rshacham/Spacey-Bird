using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private GameObject myShooter;
    private GameObject myEgg;
    [SerializeField] private GameObject flappyBird;
    [SerializeField] private float destroyTime;
    // Start is called before the first frame update

    void Awake()
    {

    }
    void OnEnable()
    {
        StartCoroutine(SelfDestroy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SelfDestroy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);
            transform.position = myShooter.transform.position;
        }
    }
}
