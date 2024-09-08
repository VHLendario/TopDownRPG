using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance { get; private set; }
    
    EntityStats player_stats;

    public Slider hp_bar;
    public Slider exp_bar;
    
    public GameObject level_up_screen;
    public Text[] stats_info;

    public GameObject damage_popup;
    private void Awake() 
        {  
            if (Instance != null && Instance != this) 
            { 
                 Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            } 
        }
    // Start is called before the first frame update
    void Start()
    {
        player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHUD();
    }

    void PlayerHUD ()
    {
        //hp
        hp_bar.maxValue = player_stats.max_hp;
        hp_bar.value = player_stats.hp_;

        //exp
        exp_bar.maxValue = player_stats.level * 100;
        exp_bar.value = player_stats.exp;
    }

    public void SelectStat(string stat)
    {
        if (stat == "hp")
        {
            player_stats.max_hp += 5;
            player_stats.hp_ += 5;
        }

        if (stat == "atk")
        {
            player_stats.bonus_attack += 5;
        }

        if (stat == "atkspeed")
        {
            player_stats.bonus_atkspeed += 2.5f;
        }

        if (stat == "move")
        {
            player_stats.base_speed += 3;
        }

        level_up_screen.SetActive(false);
    }

    public void SetupLevelUp()
    {
        level_up_screen.SetActive(true);

        stats_info[0].text = player_stats.max_hp.ToString();
        stats_info[1].text = player_stats.bonus_attack.ToString() + 5;
        stats_info[2].text = player_stats.bonus_atkspeed.ToString() + 2.5f;
        stats_info[3].text = (Mathf.CeilToInt(player_stats.base_speed/10)).ToString();
    }
}
