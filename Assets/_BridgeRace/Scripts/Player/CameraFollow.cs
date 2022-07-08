using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [HideInInspector] public bool DelayFollow;
    private Vector3 startCameraPosition;
    private Vector3 startPlayerPosition;
    private void Start()
    {
        startPlayerPosition = player.transform.position;
        startCameraPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            FollowPlayer();
        }
    }
    private void FollowPlayer()
    {
        transform.position = startCameraPosition + (player.transform.position - startPlayerPosition);
    }
}
