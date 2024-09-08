using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Manager : MonoBehaviour
{
    public static Inventory_Manager Instance { get; private set; }

    public GameObject inv_background;
    public GameObject inv_slot;

    public List<Weapon> inventory_;
    public int active_slot;

    int selected_slot = 0;

    EntityStats player_stats;

    //Gold
    public int gold_coins;
    public Text gold_text;

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
        player_stats = GameObject.FindGameObjectWithTag ("Player").GetComponent<EntityStats>();
        SelectWeapon(1);
    }

    // Update is called once per frame
    void Update()
    {
        InventorySelection ();
    }

    void RefreshInventory()
    {
        //Refresh
        gold_text.text = gold_coins.ToString();

        //Destrói todos os slots antes de continuar
        GameObject [] destroy_slots = GameObject.FindGameObjectsWithTag("Slots");
        foreach (GameObject go in destroy_slots)
        {
            Destroy(go);
        }

        int hotkey_ = 1;

        foreach (Weapon w in inventory_)
        {
            GameObject slot_instance = Instantiate (inv_slot, inv_background.transform);

            if (w == null)
            {
                slot_instance.GetComponentInChildren<Image>().enabled = false;
            }
            else 
            {
                slot_instance.GetComponentInChildren<Image>().enabled = true;
                slot_instance.GetComponentInChildren<Image>().sprite = w.weapon_icon;

                //Desabilita outline e habilita caso esteja selecionado
                slot_instance.GetComponentInChildren<Outline>().enabled = false;
                    if (selected_slot == hotkey_)
                    {
                        slot_instance.GetComponentInChildren<Outline>().enabled = true;
                    }
            }
            
            slot_instance.GetComponentInChildren<Text>().text = hotkey_.ToString();
            hotkey_++;
            
        }
    }

    void SelectWeapon (int hotkey_)
    {
        Weapon selected_weapon = inventory_[hotkey_ - 1];
        active_slot = hotkey_ - 1;

        player_stats.attack_damage = selected_weapon.weapon_damage;
        player_stats.attack_speed = selected_weapon.weapon_speed;
        player_stats.attack_range = selected_weapon.weapon_range;
        player_stats.attack_life = selected_weapon.weapon_life;

        selected_slot = hotkey_;
        RefreshInventory();
    }

    void InventorySelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectWeapon(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectWeapon(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectWeapon(5);
        }
    }

    public void AddGold(int g)
    {
        gold_coins += g;
        RefreshInventory ();
    }

    public void DiscardWeapon ()
    {
        if (active_slot != 0)
        {
            inventory_[active_slot] = null;
            SelectWeapon(1);
            RefreshInventory ();
        }
    }
}
