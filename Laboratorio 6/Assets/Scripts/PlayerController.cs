using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] public float speed;
    [SerializeField] private AudioSource doorSFX;
    public VolumeController volumeController;
    public UIControl uiControl;
    public NPCMovement movement;
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;
    private float xDirection;
    private float zDirection;
    private bool interaction = false;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(speed * xDirection, _rigidbody.velocity.y, speed * zDirection);
        if (xDirection != 0 || zDirection != 0)
        {
            if (!_audioSource.isPlaying) 
            {
                _audioSource.Play();
            }
        }
        else
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
        }
    }
    public void ReadMovementX(InputAction.CallbackContext context)
    {
        xDirection = context.ReadValue<float>();
    }
    public void ReadMovementZ(InputAction.CallbackContext context)
    {
        zDirection = context.ReadValue<float>();
    }
    public void ReadInteract(InputAction.CallbackContext context)
    {
        if (interaction == true)
        {
            movement.StartCoroutine("Interact");
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("void"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("RedDoor")|| collision.gameObject.CompareTag("GreenDoor"))
        {
            uiControl.StartCoroutine("Fade");
            volumeController.ChangeSong();
            doorSFX.Play();
        }
        if (collision.gameObject.CompareTag("NPC"))
        {
            interaction = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            interaction = false;
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
