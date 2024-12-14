using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private PlayerHP playerHP;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private AudioSource Shoot;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHP = GameObject.FindWithTag("DeadPlayer").GetComponent<PlayerHP>();
        Shoot = GameObject.FindWithTag("DeadEnemy").GetComponent<AudioSource>();
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadPlayer"))
        {
            playerHP.TakeDamage(damage);
            Shoot.Play();
            Destroy(gameObject);
        }
    }
}
