using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody _rigidbody;
    private float xDirection;
    private float zDirection;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(speed * xDirection, _rigidbody.velocity.y, speed * zDirection);
    }
    public void ReadMovementX(InputAction.CallbackContext context)
    {
        xDirection = context.ReadValue<float>();
    }
    public void ReadMovementZ(InputAction.CallbackContext context)
    {
        zDirection = context.ReadValue<float>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("void"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("YellowDoor"))
        {
            SceneManager.LoadScene("Level2");
        }

        if (collision.gameObject.CompareTag("BlueDoor"))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
