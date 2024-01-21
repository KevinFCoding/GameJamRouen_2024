using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNormand : MonoBehaviour
{
    [SerializeField] Player player;
    private float _angle;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && player.isPlayerAttacking())
        {
            player.Fire();
        }

        float x = player.getTargetPosition().x + Mathf.Cos(_angle) * player.getRadius();
        float y = player.getTargetPosition().y;
        float z = player.getTargetPosition().z + Mathf.Sin(_angle) * player.getRadius();

        transform.position = new Vector3(x, y, z);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _angle += player.getSpeed() * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _angle += -player.getSpeed() * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.nextTroupes();
        }
    }
}
