using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBreton : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _speed;
    [SerializeField] Player player;

    public float _distanceRadius;
    public float _angle;
    public bool isAttacking;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) && player.isPlayerAttacking())
        {
            player.Fire();
        }

            // Movement
            float x = _target.position.x + Mathf.Cos(_angle) * _distanceRadius;
        float y = _target.position.y;
        float z = _target.position.z + Mathf.Sin(_angle) * _distanceRadius;

        transform.position = new Vector3(x, y, z);

        if (Input.GetKey(KeyCode.A))
        {
            _angle += _speed * Time.deltaTime ;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _angle += -_speed * Time.deltaTime;
        }
    }
}
