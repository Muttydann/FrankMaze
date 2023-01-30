using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public GameObject WinText;

    public float speed = 0;
    public TextMeshProUGUI HealthText;
    

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        WinText.SetActive(false);

        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }


   
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    // How much Damage the player takes
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("WallPain"))
        {
            TakeDamage(1);
            cam.GetComponent<CameraController>().Shake();
        }
        if (collision.collider.gameObject.CompareTag("End"))
        {
            WinText.SetActive(true);
        }

    }
}
