using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector3 move = Vector3.zero;

    private void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.z = Input.GetAxisRaw("Vertical");
        move.Normalize();

        transform.position += (moveSpeed * Time.deltaTime * move);
        transform.LookAt(transform.position + move);
    }
}
