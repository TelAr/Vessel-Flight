using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{

    private GameObject[] bulletSets;


    private void Awake()
    {

        bulletSets = new GameObject[transform.childCount];
        for (int k = 0; k < transform.childCount; k++) {

            bulletSets[k] = transform.GetChild(k).gameObject;
            bulletSets[k].SetActive(false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }
}
