using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //[SerializeField] private GameObject jt;
    [HideInInspector] public bool DelayFollow;
    private Vector3 startCameraPosition;
    private Vector3 startPlayerPosition;
    private void Start()
    {
        //DelayFollow = true;
        //Player p = GameManager.Instance.player;
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
        transform.position = startCameraPosition + (player.transform.position - startPlayerPosition);/* + Vector3.up * player.petCount * 0.03f + Vector3.back * player.petCount * 0.03f;*/
    }
}
