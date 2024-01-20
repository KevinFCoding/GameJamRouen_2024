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
        float x = player.getTargetPosition().x + Mathf.Cos(_angle) * player.getRadius();
        float y = player.getTargetPosition().y;
        float z = player.getTargetPosition().z + Mathf.Sin(_angle) * player.getRadius();

        transform.position = new Vector3(x, y, z);

        if (Input.GetKey(KeyCode.A))
        {
            _angle += player.getSpeed() * Time.deltaTime ;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _angle += -player.getSpeed() * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.nextTroupes();
        }
    }
}
