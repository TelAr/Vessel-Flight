using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float speed=10;
    private Vector3 input;

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

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(input * Time.deltaTime*speed);
        if (transform.position.y < -5) {

            transform.position = transform.position - new Vector3(0, transform.position.y + 5);
        }
        else if (transform.position.y > 5)
        {

            transform.position = transform.position - new Vector3(0, transform.position.y - 5);
        }
        if (transform.position.x < -12)
        {

            transform.position = transform.position - new Vector3(transform.position.x + 12, 0);
        }
        else if (transform.position.x > 12)
        {

            transform.position = transform.position - new Vector3(transform.position.x - 12, 0);
        }
    }

    void Update() {

    }

}
