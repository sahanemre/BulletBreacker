using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    ParticleSystem ps;

    public GameObject dieEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, speed);

        if (GameManager.instance.bulletSlowing == true)
        {
            rb.velocity = new Vector2(0, speed / 2);
        }
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //ps.Play();
            Instantiate(dieEffect,transform.position,Quaternion.identity);
            GameManager.instance.findAndDestroyEffect();
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("BaseWall"))
        {
            GameManager.instance.GameOverPanel();
            GameManager.instance.RestartLevel();
            Debug.Log("base");
        }

        if (collision.gameObject.CompareTag("BigExplosion"))
        {
            Destroy(gameObject);

            GameObjectsType bullet = gameObject.GetComponent<GameObjectsType>();
            GameManager.instance.DestroyBullet(bullet);
        }
    }

   
}
