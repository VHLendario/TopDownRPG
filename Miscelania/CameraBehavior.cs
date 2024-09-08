using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject target_object;
    Vector3 targert_transform;
    GameObject player_object;

    public List <Transform> boundaries;
    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.FindGameObjectWithTag("Player");
        target_object = player_object;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((player_object.transform.position.x < boundaries[0].position.x || player_object.transform.position.x > boundaries[1].position.x) && (player_object.transform.position.y < boundaries[2].position.y || player_object.transform.position.y > boundaries[3].position.y))
        {
            targert_transform = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        }
        else if (player_object.transform.position.x < boundaries[0].position.x || player_object.transform.position.x > boundaries[1].position.x)
        {
            targert_transform = new Vector3(gameObject.transform.position.x, target_object.transform.position.y, -10);
        }
        else if (player_object.transform.position.y < boundaries[2].position.y || player_object.transform.position.y > boundaries[3].position.y)
        {
            targert_transform = new Vector3(target_object.transform.position.x, gameObject.transform.position.y, -10);
        }
        else
        {
            targert_transform = new Vector3 (target_object.transform.position.x, target_object.transform.position.y, -10);
        }

        transform.position = Vector3.Lerp(this.transform.position, new Vector3(targert_transform.x, targert_transform.y, -10), 1 * Time.fixedDeltaTime);
    }
}
