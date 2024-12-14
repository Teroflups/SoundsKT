using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private AudioSource deadEnemy;
    private AudioSource deadBullet;
    void Start()
    {
        deadBullet = GameObject.FindWithTag("Dead").GetComponent<AudioSource>();
        Destroy(gameObject, 5);
        deadEnemy = GameObject.FindWithTag("DeadEnemy").GetComponent<AudioSource>();
    }

    
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Object") || collision.gameObject.CompareTag("Enemy"))
        {
            deadBullet.Play();
            Destroy(gameObject);
            if (collision.gameObject.CompareTag("Enemy"))
            {
                deadEnemy.Play();
                Destroy(collision.gameObject);
            }
        }
    }
}
