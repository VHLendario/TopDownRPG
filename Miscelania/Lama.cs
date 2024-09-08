using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lama : MonoBehaviour
{
   EntityStats speed_player;
    //PlayerMoviment player;
    // Start is called before the first frame update
    void Start()
    {
        speed_player = gameObject.GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       collision.gameObject.GetComponent<EntityStats>().base_speed /= 2; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       collision.gameObject.GetComponent<EntityStats>().base_speed *= 2; 
    }
}
