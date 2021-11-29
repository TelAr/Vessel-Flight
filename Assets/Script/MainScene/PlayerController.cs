using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float speed=10;
    private Vector3 input;
    private const float x_limit = 10;
    private const float y_limit = 5;

    public GameObject bulletController;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
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

            this.gameObject.GetComponent<FlightUnit>().Damage(3);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
