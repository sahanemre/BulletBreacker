using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnipeController : MonoBehaviour
{
    Vector2 mousePosition;
    SpriteRenderer dotsSprite,snipeSprite;
    Vector2 direction;
    public bool mouseDown = false;

    BallController ballController;

    private void Awake()
    {
        dotsSprite = GetComponent<SpriteRenderer>();
        snipeSprite = GameObject.Find("Snipe").GetComponent<SpriteRenderer>();
        SpriteBool(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = new Vector2(-mousePosition.x, transform.position.y);
        float mouseX = Mathf.Clamp(mousePosition.x, -2.6f, 2.6f);
        float mouseY = Mathf.Clamp(mousePosition.y, -5, -4.2f);
        mousePosition = new Vector2(mouseX, mouseY);
        direction = (mousePosition - (Vector2)transform.position).normalized;
        transform.up = -direction;
        //Debug.Log(transform.up);

        if (Input.GetMouseButtonDown(0))
        {
            SpriteBool(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SpriteBool(false);
        }


    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseDrag()
    {
        
    }

    private void OnMouseUp()
    {
        
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
