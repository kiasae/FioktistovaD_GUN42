using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveVector;
    public AudioSource moveSound;
    public Transform cam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);

        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");

        moveVector = Vector3.ClampMagnitude(moveVector, 1f);

        transform.Translate(moveVector * speed * Time.deltaTime);

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.35f)
        {
            if (moveSound.isPlaying) return;
            moveSound.Play();
        }
        else
        {
            moveSound.Stop();
        }
    }
}