using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityStats : MonoBehaviour
{
    public float max_hp;
    public float hp_;
    public float base_speed;
    public float attack_damage;
    public float attack_speed;
    public float attack_life;
    public float attack_range;
    public int gold_carry;

    //apenas inimigos
    public SpawnManager spawn_manager;

    //apenas jogador
    public int level = 1;
    public int exp = 0;
    public float bonus_attack;
    public float bonus_atkspeed;
    


    Shopitem shop_;

    // Start is called before the first frame update
    void Start()
    {
        shop_ = gameObject.GetComponent<Shopitem>();
        hp_ = max_hp;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void Death ()
    {
        if (hp_ <= 0)
        {
            //Dá ouro pro jogador
            if (this.gameObject.tag != "Player")
            {
                Inventory_Manager.Instance.AddGold(gold_carry); 
                GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>().AddExp(exp);
            }

            //Computa a morte do inimigo
            if (this.gameObject.tag == "Enemy")
            {
                spawn_manager.enemies_alive --;
            }

            Destroy (this.gameObject);
            //shop_.RefreshShop();
        }
    }

    public void RemoveHP (float hp_to_remove)
    {
        GameObject new_popup = Instantiate (HUD.Instance.damage_popup, this.gameObject.transform.position, Quaternion.identity);
        new_popup.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), 5), ForceMode2D.Impulse);
        new_popup.GetComponentInChildren<Text>().text = hp_to_remove.ToString();
        Destroy (new_popup, 1);

        hp_ -= hp_to_remove;
        Death ();
    }

    void AddExp(int exp_)
    {
        exp += exp_;

        if (exp >= level * 100)
        {
            exp = 0;
            level ++;
            HUD.Instance.SetupLevelUp();
        }
    }
}
