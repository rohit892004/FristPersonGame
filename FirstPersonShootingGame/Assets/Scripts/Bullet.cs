using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speeed;
    private Rigidbody rb;

    
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, 2f);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyController.instance.Takedamage();
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
    
}
        