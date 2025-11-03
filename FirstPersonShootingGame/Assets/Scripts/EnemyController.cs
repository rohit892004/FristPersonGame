using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [Header("Enemey Controller")]
    public GameObject Player;
    public float detectRange;
    public float moveSpeed;
    private Animator anim;

    public float attackRange = 3;
    private bool isAttacking = false;
    public float timebetweenAttack = 0.5f;

    [Header("Health")]
    public float CurrentHeath;
    public float MaxHealth;
    public float damageHeath;

    [Header("ScriptRef")]
    public static EnemyController instance;

    [Header("AmmoContanier")]
    public GameObject ammoContanier;
    // Start is called before the first frame update

    private NavMeshAgent NavMesh;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        CurrentHeath = MaxHealth;
        NavMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        chasingPlayer();
    }

    void chasingPlayer()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        Debug.Log(distance);
        if (distance <= detectRange)
        {
            anim.SetBool("Inrange", true);
            if(distance<attackRange && !isAttacking)
            {
                StartCoroutine(AttackAfterDealy());
            }
            else if (!isAttacking)
            { 
            enenmyrun();
            }
        }
        else
        {
            anim.SetBool("Inrange", false);
        }
    }

    void enenmyrun()
    {
        Vector3 playerpoisiton = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
        /*  Vector3 dirtection = (playerpoisiton - transform.position).normalized;
         transform.position = Vector3.MoveTowards(transform.position, playerpoisiton, moveSpeed*Time.deltaTime);
         transform.LookAt(playerpoisiton);
        */
        NavMesh.SetDestination(playerpoisiton);
    }
     IEnumerator AttackAfterDealy()
    {
        isAttacking = true;
        anim.SetTrigger("Attack");
        //PlayerHealth.instance.heathdamge();
        yield return new WaitForSeconds(timebetweenAttack);
        isAttacking = false;
    }

    public void Takedamage()
    {
        CurrentHeath -= damageHeath;
        if(CurrentHeath <= 0)
        {
            AudioManager.instance.PlaySFX(3);
            anim.SetTrigger("Dead");
            if (ammoContanier != null)
            {
                Instantiate(ammoContanier, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }
            GetComponent<Collider>().enabled = false;
            GetComponent<EnemyController>().enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}

