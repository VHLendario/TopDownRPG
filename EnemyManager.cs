using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameObject player;
    EntityStats entity_stats;

    Animator animator_enemy;
    public float move_speed;
    // Start is called before the first frame update
    void Start()
    {
        entity_stats = gameObject.GetComponent<EntityStats>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator_enemy = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveEnemy ();
    }

    void MoveEnemy ()
    {
        transform.position = Vector3.MoveTowards (transform.position, player.transform.position, move_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player")
       {
        collision.gameObject.GetComponent<EntityStats>().RemoveHP(entity_stats.attack_damage);
        
        entity_stats.RemoveHP(entity_stats.max_hp + 1);
       }
    }
}
