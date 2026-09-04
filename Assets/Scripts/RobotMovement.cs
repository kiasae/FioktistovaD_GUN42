using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float raySize = 2f;
    [SerializeField] private LayerMask obstacleMask;


    [SerializeField] private float moveSpeed = 3f; 
    [SerializeField] private float turnSpeed = 150f;


    private float variationTime = 2f;
    private float currentVariationAngle = 0f;


    //Звуки
    [SerializeField] private AudioClip moveSound;
    [SerializeField] private AudioClip collisionSound;
    [SerializeField] private float moveVolume = 0.3f;
    [SerializeField] private float collisionVolume = 0.7f;
    [SerializeField] private float collisionCooldown = 0.5f;

    private bool frontBlocked;
    private bool leftBlocked;
    private bool rightBlocked;

    //Звук
    private AudioSource audioSource;
    private float collisionTimer = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false; 
    }

    void Update()
    {

        ScanForObstacles();

        if (frontBlocked || leftBlocked || rightBlocked)
        {
            if (collisionTimer <= 0f)
            {
                PlayCollisionSound();
                collisionTimer = collisionCooldown;
            }
        }

        if (collisionTimer > 0f)
        {
            collisionTimer -= Time.deltaTime;
        }

        if (moveSpeed > 0f && (!audioSource.isPlaying || audioSource.clip != moveSound))
        {
            PlayMoveSound();
        }
        else if (moveSpeed == 0f && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        float turnDirection = CalculateTurnDirection();
        
        transform.Rotate(Vector3.up, turnDirection * turnSpeed * Time.deltaTime);
        
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);


        variationTime -= Time.deltaTime;

        if (variationTime <= 0f)
        {
            float randomAngle = Random.Range(10f, 30f);
            currentVariationAngle = Random.value > 0.5f ? randomAngle : -randomAngle;
            variationTime = 2f;
        }

        if (Mathf.Abs(currentVariationAngle) > 0.1f)
        {
            float turnThisFrame = Mathf.Sign(currentVariationAngle) * Mathf.Min(Mathf.Abs(currentVariationAngle), turnSpeed * Time.deltaTime);

            transform.Rotate(Vector3.up, turnThisFrame);

            currentVariationAngle -= turnThisFrame;
        }
    }

    private void ScanForObstacles()
    {
        frontBlocked = Physics.Raycast(transform.position, transform.forward, raySize, obstacleMask);
        leftBlocked = Physics.Raycast(transform.position, -transform.right, raySize, obstacleMask);
        rightBlocked = Physics.Raycast(transform.position, transform.right, raySize, obstacleMask);

        //Debug.Log($"Front: {frontBlocked}, Left: {leftBlocked}, Right: {rightBlocked}");
    }

    private float CalculateTurnDirection()
    {

        if (frontBlocked)
        {
            if (!leftBlocked) return -1f;  
            if (!rightBlocked) return 1f;  
            return 1f;
        }
        else
        {
            if (leftBlocked) return 1f; 
            if (rightBlocked) return -1f; 
        }

        return 0f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = frontBlocked ? Color.red : Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * raySize);

        Gizmos.color = leftBlocked ? Color.red : Color.blue;
        Gizmos.DrawRay(transform.position, -transform.right * raySize);

        Gizmos.color = rightBlocked ? Color.red : Color.green;
        Gizmos.DrawRay(transform.position, transform.right * raySize);
    }

    private void PlayMoveSound()
    {
        if (moveSound != null)
        {
            audioSource.clip = moveSound;
            audioSource.volume = moveVolume;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void PlayCollisionSound()
    {
        if (collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound, collisionVolume);
        }
    }

}
