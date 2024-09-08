using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpensStore : MonoBehaviour
{
    public GameObject store_object;
    public GameObject store_warning;

    GameObject player_obj;

    public List <Weapon> weapons_sold;

    public GameObject shop_bg;
    public GameObject shop_item;

    // Start is called before the first frame update
    void Start()
    {
        RandomItens ();
        store_object.SetActive(false);

        player_obj = GameObject.FindGameObjectWithTag("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance (transform.position, player_obj.transform.position);
        if (dist < 1.8f)
        {
            store_warning.SetActive (true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                store_object.SetActive(true);
            }
        }
        else 
        {
           
            store_warning.SetActive(false);

            store_object.SetActive(false);
           
        }
    }

    void RandomItens ()
    {
        for (int i = 0; i < 3; i++)
        {
            int random_number = Random.Range(0, weapons_sold.Count);

            GameObject new_shop_item = Instantiate(shop_item, shop_bg.transform);
            new_shop_item.GetComponent<Shopitem>().w_ = weapons_sold[random_number];
            new_shop_item.GetComponent<Shopitem>().Setup(weapons_sold[random_number]);
        }
    }
}
