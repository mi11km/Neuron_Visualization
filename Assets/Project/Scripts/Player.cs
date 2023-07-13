using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private AudioSource _audioSource;
    private bool _shouldShowMenu;
    private float _step;
    private float _speed;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _shouldShowMenu = false;
        menu.SetActive(_shouldShowMenu);
    }

    void Update()
    {
        _step = 7.0f * Time.deltaTime;
        _speed = 15.0f * Time.deltaTime;

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft)) transform.Rotate(0, -5.0f * _step, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight)) transform.Rotate(0, 5.0f * _step, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp)) transform.Rotate(-5.0f * _step, 0, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown)) transform.Rotate(5.0f * _step, 0, 0);

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp)) transform.Translate(Vector3.forward * _speed);
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown)) transform.Translate(Vector3.back * _speed);
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft)) transform.Translate(Vector3.left * _speed);
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight)) transform.Translate(Vector3.right * _speed);
        if (OVRInput.Get(OVRInput.Button.Two)) transform.Translate(Vector3.up * _speed);
        if (OVRInput.Get(OVRInput.Button.One)) transform.Translate(Vector3.down * _speed);

        if (OVRInput.Get(OVRInput.Button.Three)) transform.position = new Vector3(0, 0, 0);

        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            _shouldShowMenu = !_shouldShowMenu;
            menu.SetActive(_shouldShowMenu);
            _audioSource.Play();
        }
    }
}