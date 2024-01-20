using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBreton : MonoBehaviour
{
    [SerializeField] Player player;
    private float _angle;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.W) && player.isPlayerAttacking())
        {
            player.Fire();
        }

            // Movement
        float x = player.gm.transform.position.x + Mathf.Cos(_angle) * player.getRadius();
        float y = player.gm.transform.position.y;
        float z = player.gm.transform.position.z + Mathf.Sin(_angle) * player.getRadius();

        transform.position = new Vector3(x, y, z);

        if (Input.GetKey(KeyCode.A))
        {
            _angle += player.getSpeed() * Time.deltaTime ;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _angle += -player.getSpeed() * Time.deltaTime;
        }
    }
}
