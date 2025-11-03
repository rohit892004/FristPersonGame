using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerShoting>().Addbullet(10);
            AudioManager.instance.PlaySFX(0);
            Destroy(gameObject);
        }
    }
}
