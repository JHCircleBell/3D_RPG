using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float distance = 5f; // 캐릭터와 카메라 사이의 거리
    [SerializeField] private float minDistance = 4f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float zoomSpeed = 1f;



    private float currentZoom = 10f;


    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        distance -= scrollInput * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        Vector3 cameraPos = target.position - transform.forward * distance;

        transform.position = cameraPos + offset;
    }

    

}
