using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed;

    ParticleSystem ps;

    public GameObject dieEffect;

    public BulletManager bulletManager;
    //public RandomSpeed randomSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
        //bulletManager = bulletManager.GetComponent<BulletManager>();
        
        //speed = Random.Range(-0.6f, -0.3f);
        //rb.velocity = new Vector2(0, speed);
        
    }


    void Start()
    {
 
        switch (GameManager.instance.column)
        {
            case 1:

                rb.velocity = new Vector2(0, GameManager.instance.bulletRandomSpeed1);
                break;
            case 2:

                rb.velocity = new Vector2(0, GameManager.instance.bulletRandomSpeed1);
                break;
            case 3:

                rb.velocity = new Vector2(0, GameManager.instance.bulletRandomSpeed1);
                break;
            case 4:

                rb.velocity = new Vector2(0, GameManager.instance.bulletRandomSpeed1);
                break;
            case 5:

                rb.velocity = new Vector2(0, GameManager.instance.bulletRandomSpeed1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //switch (bulletManager.bulletColumn)
        //{
        //    case 1:
        //        Debug.Log(bulletManager.bulletColumn);
        //        rb.velocity = new Vector2(0, -1);
        //        break;
        //    case 2:

        //        rb.velocity = new Vector2(0, GameManager.instance.bulletRandomSpeed2);
        //        break;
        //    case 3:

        //        rb.velocity = new Vector2(0, GameManager.instance.bulletRandomSpeed3);
        //        break;
        //    case 4:

        //        rb.velocity = new Vector2(0, GameManager.instance.bulletRandomSpeed4);
        //        break;
        //    case 5:

        //        rb.velocity = new Vector2(0, GameManager.instance.bulletRandomSpeed5);
        //        break;
        //}

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
            //GameManager.instance.RestartLevel();
            
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
