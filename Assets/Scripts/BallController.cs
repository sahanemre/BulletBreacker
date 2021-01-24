using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    Vector2 mousePosition;
    Vector2 direction;
    Vector2 tempVelocity;
    Vector2 ballStartPosition;
    Vector2 ballEndPosition;

    public GameObject Dot, Snip;


    public float xSpeed,ySpeed;
    public float constantV;
    public bool ballMoving = false;
    


    Rigidbody2D rb;
    SpriteRenderer dotsSprite, snipeSprite;
    TrailRenderer tr;
    LineRenderer lr;
    

    private Transform ballBaseTransform;

    private void Awake()
    {
      
        
        //Ball Trail Effect and Rigidbody
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        lr = GetComponent<LineRenderer>();
        ballStartPosition = transform.position;


        //Ball dots and snipe sprites renderer
        dotsSprite = Dot.GetComponent<SpriteRenderer>();
        snipeSprite = Snip.GetComponent<SpriteRenderer>();
        SpriteBool(false);

        //Debug.Log(ballStartPosition);

        //Circle that covering the ball(Transform) 
        ballBaseTransform = GameObject.Find("BallBase").transform;
        ballBaseTransform.position = ballStartPosition;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ////transform.position = new Vector2(-mousePosition.x, transform.position.y);
        //float mouseX = Mathf.Clamp(mousePosition.x, -2.6f, 2.6f);
        //float mouseY = Mathf.Clamp(mousePosition.y, -5, -4.2f);
        //mousePosition = new Vector2(mouseX, mouseY);
        //direction = (mousePosition - (Vector2)transform.position).normalized;
        //transform.up = -direction;
        ////Debug.Log(transform.up);


        //if (Input.GetMouseButtonUp(0) && ballMoving == false)
        //{
        //    rb.constraints = RigidbodyConstraints2D.None;
        //    Vector2 tempVelocity = new Vector2(transform.up.x, transform.up.y);
        //    rb.velocity = constantV * tempVelocity;
        //    ballMoving = true;
        //}

        //Debug.Log(transform.up);
        //Debug.Log(rb.velocity);
        
        
    }

    private void OnMouseUp()
    {
       
        if (ballMoving == false)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            Vector2 tempVelocity = new Vector2(transform.up.x, transform.up.y);
            rb.velocity = constantV * tempVelocity;
            ballMoving = true;
            SpriteBool(false);

           
        }
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = new Vector2(-mousePosition.x, transform.position.y);
        float mouseX = Mathf.Clamp(mousePosition.x, -2.6f, 2.6f);
        float mouseY = Mathf.Clamp(mousePosition.y, -5, -3.8f);
        mousePosition = new Vector2(mouseX, mouseY);
        direction = (mousePosition - (Vector2)transform.position).normalized;
        transform.up = -direction;

        lr.SetPosition(1, transform.up);

    }

    private void OnMouseDown()
    {
        if (ballMoving == false)
        {
            SpriteBool(true);
            lr.SetPosition(0, transform.position);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Prevention or Fix from balls stick to bug
        Vector2 deviation = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
        //Debug.Log(deviation);
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity += deviation;
        }
 
        //Ball when collision that BaseWall, appoint new transform for ball 
        if (collision.gameObject.CompareTag("BaseWall"))
        {
            ballEndPosition = transform.position;
            transform.position = ballEndPosition;
            transform.position = new Vector2(transform.position.x,ballStartPosition.y);
            //transform.position = ballStartPosition;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            ballMoving = false;

            tr.enabled = false;

            ballBaseTransform.position = new Vector2(transform.position.x, ballBaseTransform.position.y);
            
            
        }

        //Bullet number arrangement. Remove the bullet from the list and tpdate bullets number
        if (collision.gameObject.GetComponent<GameObjectsType>())
        {
            GameObjectsType bullet = collision.gameObject.GetComponent<GameObjectsType>();
            GameManager.instance.DestroyBullet(bullet);
        }

        //Boung Sound
        GetComponent<AudioSource>().Play();
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameManager.instance.triggerCoinSound();
            Destroy(collision.gameObject);
            GameManager.instance.updateCoinScore(+1);
        }
    }
    void SpriteBool(bool sprite)
    {
        if (sprite)
        {
            dotsSprite.enabled = true;
            snipeSprite.enabled = true;
        }
        else
        {
            dotsSprite.enabled = false;
            snipeSprite.enabled = false;
        }
    }

   



}
