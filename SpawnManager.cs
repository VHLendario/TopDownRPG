using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject porta_;
    public List<GameObject> spawn_points_;
    public List<GameObject> enemies;

    public int enemies_alive = 0;
    bool dungeon_active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDungeonEnd();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            porta_.SetActive(true);
            SpawnEnemies();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            dungeon_active = true;
        }
    }

    void SpawnEnemies()
    {
        foreach(GameObject sp in spawn_points_)
        {
            int random_enemy = Random.Range(0, 2);
            GameObject new_enemy = Instantiate(enemies[random_enemy], sp.transform.position, Quaternion.identity);
            new_enemy.GetComponent<EntityStats>().spawn_manager = this;
            enemies_alive ++;
        }
    }

    void CheckDungeonEnd()
    {
        if (dungeon_active == true)
        {
            if (enemies_alive == 0)
            {
                porta_.SetActive(false);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
