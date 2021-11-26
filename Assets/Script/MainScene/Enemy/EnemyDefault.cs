using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefault : MonoBehaviour
{
    private GameObject player;
    private float fire_timer;
    private bool is_fire;


    public EnemyFireType fire_type;
    public float start_delay = 1;
    public float fire_delay = 1;
    void Awake()
    {
        player = GameObject.Find("Player");
        if (this.gameObject.GetComponent<EnemyFireType>() != null)
        {
            fire_type = this.gameObject.GetComponent<EnemyFireType>();

        }
        fire_timer = 0;
        is_fire = false;


    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fire_type != null)
        {


            fire_timer += Time.deltaTime;
            if (!is_fire && fire_timer > start_delay)
            {

                is_fire = true;
                fire_type.Fire();
                fire_timer = 0;
            }
            if (is_fire && fire_timer > fire_delay)
            {

                fire_type.Fire();
                fire_timer = 0;
            }
        }
    }
}
