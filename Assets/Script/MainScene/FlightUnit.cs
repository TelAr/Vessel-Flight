using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightUnit : UnitDefault
{

    public int maxHealth = 1;

    public int nowHealth = 1;

    void Awake()
    {
        if (maxHealth <= 0)
        {

            maxHealth = 1;
        }
        nowHealth = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        base.FixedUpdate();
        if (nowHealth <= 0)
        {

            Object_Disable();
        }
    }
    virtual public void ReAwake() {

        nowHealth = maxHealth;
        this.gameObject.SetActive(true);
    }

    virtual public void Damage(int d) {

        nowHealth -= d;
    }
}
