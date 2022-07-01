using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public static Shooter _shooter;
    [SerializeField] private GameObject myEgg;
    [SerializeField] private List<GameObject> myEggs;
    [SerializeField] private float eggsAmount; //How many eggs should i add to shooter's list,
    [SerializeField] private float shotPower; //Power of the egg shot
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp;
        for (int i = 0; i < eggsAmount; i++)
        {
            temp = Instantiate(myEgg);
            temp.SetActive(false);
            myEggs.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(Transform flappyTransform)
    {
        GameObject temp;
        Rigidbody2D rigid;
        for (int i = 0; i < eggsAmount; i++)
        {
            if (!myEggs[i].activeInHierarchy)
            {
                temp = myEggs[i];
                temp.transform.position = transform.position;
                temp.transform.rotation = transform.rotation;
                temp.SetActive(true);
                rigid = temp.GetComponent<Rigidbody2D>();
                rigid.velocity = new Vector2(-1f *shotPower, flappyTransform.rotation.z*-30f);
                SoundManager._shared.PlaySound("shotSound");
                print("shot");
                break;
            }
        }
    }
}
