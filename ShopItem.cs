using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopitem : MonoBehaviour
{
    public Weapon w_;

    public Text item_name_holder;
    public Text item_value_holder;
    public Image item_icon_holder;
    public Text item_info_holder;

    public Button shop_button;

    GameObject store_object;

    // Start is called before the first frame update
    void Start()
    {
        Setup(w_);

        store_object = GameObject.FindGameObjectWithTag("StoreUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup (Weapon w)
    {
        item_name_holder.text = w.weapon_name;
        item_value_holder.text = w.weapon_value.ToString();
        item_icon_holder.sprite = w.weapon_icon;
        item_info_holder.text = "Attack Damage: " + w.weapon_damage.ToString() + "\nAttack speed: " + w.weapon_speed.ToString() + "\nRange: " + w.weapon_range.ToString();

        if (Inventory_Manager.Instance.gold_coins < w.weapon_value)
        {
            shop_button.interactable = false;
        } 
        else
        {
            shop_button.interactable = true;
        }
    }

    public void BuyWeapon ()
    {
        if (Inventory_Manager.Instance.inventory_[4] != null)
        {

        }
        else 
        {
            for (int i = 0; i < 5; i++)
            {
                if (Inventory_Manager.Instance.inventory_[i] == null)
                {
                    Inventory_Manager.Instance.inventory_[i] = w_;
                    break;
                }
            }

            Inventory_Manager.Instance.AddGold(w_.weapon_value * -1);
            RefreshShop ();
            Destroy(this.gameObject);
            store_object.SetActive(false);
        }
    }

    public void RefreshShop ()
    {
        GameObject[] shop_buttons = GameObject.FindGameObjectsWithTag("Shopitem");
        foreach (GameObject go in shop_buttons)
        {
            go.GetComponent<Shopitem>().Setup(go.GetComponent<Shopitem>().w_);
        }
    }
}
