using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFlightUnit : FlightUnit
{
    private Rigidbody rb;
    private float speed=10;
    private Vector3 input;
    private const float x_limit = 10;
    private const float y_limit = 5;
    private bool is_invincible;
    private float invincible_timer;
    public Material normal, invincible;

    public GameObject bulletController;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        is_invincible = false;
        invincible_timer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    public void OnFire() {

        bulletController.GetComponent<BulletController>().Fire();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) {

            Damage(3);
        }
    }

    override public void ReAwake() {

        base.ReAwake();
        input = new Vector3(0, 0);
        is_invincible = true;
    }

    public override void Damage(int d)
    {
        if (is_invincible) { 
        
        }
        else
        {
            base.Damage(d);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        base.FixedUpdate();

        if (is_invincible)
        {
            gameObject.GetComponent<Renderer>().material = invincible;
            invincible_timer += Time.deltaTime;
            if (invincible_timer > 2f)
            {

                is_invincible = false;
                invincible_timer = 0f;
            }
        }
        else {

            gameObject.GetComponent<Renderer>().material = normal;
        }


        transform.Translate(input * Time.deltaTime*speed);
        if (transform.position.y < -y_limit) {

            transform.position = transform.position - new Vector3(0, transform.position.y + y_limit);
        }
        else if (transform.position.y > y_limit)
        {

            transform.position = transform.position - new Vector3(0, transform.position.y - y_limit);
        }
        if (transform.position.x < -x_limit)
        {

            transform.position = transform.position - new Vector3(transform.position.x + x_limit, 0);
        }
        else if (transform.position.x > x_limit)
        {

            transform.position = transform.position - new Vector3(transform.position.x - x_limit, 0);
        }
    }

    void Update() {

    }

}
