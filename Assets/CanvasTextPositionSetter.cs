using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTextPositionSetter : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;

    private Vector3 OffSet;
    private void Start()
    {
        OffSet.x = 1; 
        OffSet.y = 0;
        OffSet.z = 1;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = _playerTransform.position + OffSet;
    }
}
