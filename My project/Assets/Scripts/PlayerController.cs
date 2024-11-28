using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class PlayerController : MonoBehaviour
{
 
    [Header("UI")]
    public float timer;
    public TMP_Text timerTxt;
 
    [Header("Health")]
    public Slider healthSlider;
    public int maxHealth;
    public int currentHealth;
 
    [Header("Movement")]
 
    public float moveSpeed;
    public float jumpForce;
    public float inputs;
 
    [Header("Components")]
 
    public Rigidbody2D rb;
    public float groundDistance;
    public LayerMask layerMask;
 
    RaycastHit2D hit;
 
    Vector2 startPos;
   
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = maxHealth;

        currentHealth = maxHealth;
        startPos = transform.position;
    }
 
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerTxt.text = timer.ToString("F2");
 
        Movement();
        Health();
    }
 
    void Movement()
    {
        inputs = Input.GetAxis("Horizontal");
        rb.velocity = new UnityEngine.Vector2(inputs * moveSpeed, rb.velocity.y);
 
        hit = Physics2D.Raycast(transform.position, -transform.up, groundDistance, layerMask);
        Debug.DrawRay(transform.position, -transform.up * groundDistance, Color.red);
 
        if (hit.collider)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
 
    void Health()
    {
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       
    }
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Hazard")
        {
            transform.position = startPos;
        }
        else if(other.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(other.gameObject.tag == "Checkpoint")
        {
            startPos = transform.position;
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            currentHealth--;
            Destroy(other.gameObject);
        }
    }
 
}