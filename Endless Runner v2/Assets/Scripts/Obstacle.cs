using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public int damage;
    public float speed;
    public float increaseSpeed;
    public GameObject effect;
    //public Animator camAnim;

    private void Update()
    {
        speed += increaseSpeed;
        transform.Translate(-transform.forward * speed * Time.deltaTime);
        Debug.Log(speed);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            //camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);

            //other.GetComponent<Player>().health -= damage;
            other.GetComponent<Player>().TakeDamage(damage);
            Debug.Log(other.GetComponent<Player>().health);


            //When the player takes damage, the object gets deactivated. >>Maybee turn off the box collider.
           //gameObject.SetActive(false);
        }
    }
}
