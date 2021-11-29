using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefault : FlightUnit
{
    private GameObject player;
    private float fire_timer;
    private bool is_fire;


    public EnemyFireType fire_type;
    public float movementSpeed = 1;
    public float start_delay = 1;
    public float fire_delay = 1;
    public float bullet_speed = 3;
    public int score = 100;

    public void DefaultSetting() {

        if (this.gameObject.GetComponent<EnemyFireType>() != null)
        {
            fire_type = this.gameObject.GetComponent<EnemyFireType>();
        }
        else {

            fire_type = null;
        }
        fire_timer = 0;
        is_fire = false;

        if (this.gameObject.GetComponent<EnemyMovement>() == null)
        {
            this.gameObject.AddComponent<EnemyStraightDown>();
        }
    }

    

    void Awake()
    {
        player = GameObject.Find("Player");
        DefaultSetting();
    }
    public void ReAwake() {
        DefaultSetting();
        base.ReAwake();
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        base.FixedUpdate();

        if (this.gameObject.GetComponent<EnemyFireType>() != null&&fire_type==null)
        {
            fire_type = this.gameObject.GetComponent<EnemyFireType>();
        }

        if (fire_type != null)
        {
            fire_type.bulletSpeed = bullet_speed;

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

    override public void Object_Disable() {

        MainGameContoller.score += score;
        base.Object_Disable();
    }
}
