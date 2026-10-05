using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _raycastLength;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private AudioSource _reloadSound;
    [SerializeField] private AudioSource _fireSound;

    private RaycastHit _hitInfo;

    private void Update()
    {
        Ray ray = new Ray(_shootPoint.position, _shootPoint.forward);

        Debug.DrawRay(ray.origin, ray.direction * _raycastLength, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            _fireSound.Play();

            if (Physics.Raycast(ray, out _hitInfo, _raycastLength))
            {
                _hitSound.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

    }


    public void Reload()
    {
        _reloadSound.Play();
    }
}
