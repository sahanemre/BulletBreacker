using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveObjScript : MonoBehaviour
{
    public GameObject ExplosionParticle;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.CompareTag("Ball"))
        {
            //bd.SetActive(true);
            GameManager.instance.triggerExplosionSound();

            Destroy(gameObject);
            
            Instantiate(ExplosionParticle, collision.transform.position, Quaternion.identity);
            GameManager.instance.findAndDestroyBigExplosionEffect();
        }

       

    }

    
}
