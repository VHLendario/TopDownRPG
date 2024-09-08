using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject projectile_;
    EntityStats entity_stats;

    bool can_attack = true;
    float cooldown_;

    GameObject player_obj;
    // Start is called before the first frame update
    void Start()
    {
        player_obj = GameObject.FindGameObjectWithTag("Player");
        entity_stats = gameObject.GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (can_attack == true)
        {
            GameObject projectile_instance = Instantiate (projectile_, transform.position, Quaternion.identity);
            
            projectile_instance.GetComponent<Projectile_Damage>().projectile_damage = entity_stats.attack_damage;
            projectile_instance.GetComponent<Projectile_Damage>().projectile_lifespan = entity_stats.attack_life;

            Vector2 projectile_direction = player_obj.transform.position - transform.position;
            projectile_direction.Normalize();
            
            projectile_instance.GetComponent<Rigidbody2D>().AddForce (projectile_direction * entity_stats.attack_range, ForceMode2D.Impulse);

            can_attack = false;
            cooldown_ = 0;
        }

        Cooldown ();

    }

    void Cooldown()
    {
        if (cooldown_ > entity_stats.attack_speed && can_attack == false)
        { 
            can_attack = true;
        }
        else 
        {
            cooldown_ += Time.deltaTime;
        }
    }
}
