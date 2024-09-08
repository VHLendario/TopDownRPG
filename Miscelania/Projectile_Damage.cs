using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Damage : MonoBehaviour
{
    public float projectile_damage;
    public float projectile_lifespan = 1;
    public bool is_player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, projectile_lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if  ((collision.gameObject.tag == "Enemy" && is_player == true) || (collision.gameObject.tag == "Player" && is_player == false) )
        {
            collision.gameObject.GetComponent<EntityStats>().RemoveHP(projectile_damage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Wall") 
        {
            Destroy(this.gameObject);
        }
    }
}
