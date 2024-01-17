using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeCheckpoint : MonoBehaviour
{
    Camera mainCamera;

    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            mainCamera.orthographicSize = 10f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            mainCamera.orthographicSize = 5f;
        }
    }
}
