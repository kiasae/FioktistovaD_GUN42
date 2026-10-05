using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public Transform player; 
    public AudioSource enemySound;

    public float minDistance = 2f;
    public float maxDistance = 20f; 

    public float minPitch = 0.8f;
    public float maxPitch = 1.3f;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        float t = Mathf.InverseLerp(minDistance, maxDistance, distance);

        enemySound.pitch = Mathf.Lerp(maxPitch, minPitch, t);
    }
}
