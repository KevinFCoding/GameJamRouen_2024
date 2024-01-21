using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    [SerializeField] Transform _pointToFollow;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = _pointToFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _pointToFollow.position;
    }
}
