using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI healthText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameObject player;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        health = 5;

        SetCountText();
        SetHealthText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        player.SetActive(true);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();

        if (health == 0)
        {
            loseTextObject.SetActive(true);
            player.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }

        if (other.gameObject.CompareTag("DamageZone"))
        {
            health = health - 1;

            SetHealthText();
        }
        
    }
}
