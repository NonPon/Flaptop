using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class Player : MonoBehaviour {

    private Vector2 targetPos;
    public float Xincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public float health = 100;
    public float pointIncreasePerSecond;
    public float maxHealth = 100;

    public Text healthDisplay;

    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        pointIncreasePerSecond = 1;
        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Battery") && health <= 90)
        {
            other.gameObject.SetActive(false);
            health = health + 10;
        }
        else if (other.gameObject.CompareTag("Battery")){
            other.gameObject.SetActive(false);
            health = 100;
        }
    }
    // Update is called once per frame
    void Update()
    {
        health -= pointIncreasePerSecond * Time.deltaTime;

        healthDisplay.text = Math.Round(health).ToString() + "%";
        //This will reset the game the moment you die.
        if (health <= 0)
        {
            //SceneManager.LoadScene("Gameover");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }



        void FixedUpdate()
         {

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.AddForce(movement * speed);

        //Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, 0.0f);
        //rigidbody.velocity = movement * speed;

        //transform.Translate(Input.acceleration.x * speed * Time.deltaTime,
        //                    0, 0);
        //transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        //if (Input.GetKeyUp(KeyCode.LeftArrow) && transform.position.x > maxHeight)
        //{
        //    targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);

        //}

        //else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < minHeight)
        //{
        //    targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);

        //}


    }

    //public void SetSpeed(float modifier)
    //{
    //    speed = 5.0f + modifier;
    //}

    public void TakeDamage(float damage)
    {
        health = health - damage;
    }
}



