using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile_;
    float cooldown_;
    bool can_attack = true;

    EntityStats entity_stats;
    // Start is called before the first frame update
    void Start()
    {
        entity_stats = gameObject.GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && can_attack == true)
        {
            GameObject projectile_instance = Instantiate (projectile_, transform.position, Quaternion.identity);
            
            projectile_instance.GetComponent<Projectile_Damage>().projectile_damage = entity_stats.attack_damage * ((entity_stats.bonus_attack +100)/100);
            projectile_instance.GetComponent<Projectile_Damage>().projectile_lifespan = entity_stats.attack_life;

            Vector2 projectile_direction = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
            projectile_direction.Normalize();
            
            projectile_instance.GetComponent<Rigidbody2D>().AddForce (projectile_direction * entity_stats.attack_range, ForceMode2D.Impulse);

            can_attack = false;
            cooldown_ = 0;
        }

        Cooldown ();

        if (Input.GetKeyDown(KeyCode.G))
        {
            Inventory_Manager.Instance.DiscardWeapon();
        }
    }

    void Cooldown()
    {
        if (cooldown_ > (entity_stats.attack_speed * ((100 - entity_stats.bonus_atkspeed))/100) && can_attack == false)
        { 
            can_attack = true;
        }
        else 
        {
            cooldown_ += Time.deltaTime;
        }
    }
}
