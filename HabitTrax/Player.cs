using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    const float speed = 6;

    public void RenderTick()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey("a") && transform.position.x >= -3.88)
        {
            movement += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey("d") && transform.position.x <= 3.88)
        {
            movement += new Vector3(1, 0, 0);
        }
        if (Input.GetKey("w") && transform.position.y <= 2)
        {
            movement += new Vector3(0, 1, 0);
        }
        if (Input.GetKey("s") && transform.position.y >= -3.85)
        {
            movement += new Vector3(0, -1, 0);
        }

        movement.Normalize();
        transform.position += movement * speed * Time.deltaTime;

        if ((movement.x > 0 && transform.rotation.y == -1))
        {
            transform.Rotate(0, 180, 0);
        }
        if ((movement.x < 0 && transform.rotation.y == 0))
        {
            transform.Rotate(0, -180, 0);
        }
    }

    //0: Does not have the item
    //1: Has the item, not placed down
    //2: Has the item, placed down
    public static Dictionary<string, int> inventory = new Dictionary<string, int>()
    {
        {"crate", 1},
        {"bed", 1},
        {"shelf", 1},
        {"petBed", 1},
        {"table", 1},
        {"rug", 1},
        {"nightstand", 1},
        {"bookshelf", 1}
    };
}