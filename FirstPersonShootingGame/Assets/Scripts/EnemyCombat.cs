using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        //OnDrawGizmosSelected();
    }

    void attack()
    {
       Collider[] hitenemy = Physics.OverlapSphere(attackPoint.position, attackRadius,playerLayer);

        foreach(Collider enemy in hitenemy)
        {
            PlayerHealth playerhealth = enemy.GetComponent<PlayerHealth>();
            if(playerhealth != null)
            {
                AudioManager.instance.PlaySFX(2);
                playerhealth.heathdamge();
            }
            
            Debug.Log("damage");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
