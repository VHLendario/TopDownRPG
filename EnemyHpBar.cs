using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    Slider hp_slider;
    EntityStats entity_stats;

    // Start is called before the first frame update
    void Start()
    {   
        hp_slider = gameObject.GetComponentInChildren<Slider>();
        entity_stats = gameObject.GetComponentInParent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        hp_slider.maxValue = entity_stats.max_hp;
        hp_slider.value = entity_stats.hp_;
    }
}
