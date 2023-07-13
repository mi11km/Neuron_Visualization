using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private Camera centerCamera;

    private CharacterController _controller;
    private AudioSource _audioSource;

    private bool _shouldShowMenu;
    private readonly float _speed = 30.0f;

    private Vector3 _movement;
    private Vector3 _moveDir = Vector3.zero;
    private float _moveH;
    private float _moveV;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _controller = GetComponent<CharacterController>();
        _shouldShowMenu = true;
        menu.SetActive(_shouldShowMenu);
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            _shouldShowMenu = !_shouldShowMenu;
            menu.SetActive(_shouldShowMenu);
            _audioSource.Play();
        }

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp) ||
            OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown) ||
            OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft) ||
            OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight))
        {
            _moveH = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).x;
            _moveV = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).y;
            _movement = new Vector3(_moveH, 0, _moveV);
            _moveDir = centerCamera.transform.forward * _movement.z + centerCamera.transform.right * _movement.x;
            _controller.Move(_speed * Time.deltaTime * _moveDir);
        }

        if (OVRInput.Get(OVRInput.Button.Two)) transform.Translate(_speed * Time.deltaTime * centerCamera.transform.up);
        if (OVRInput.Get(OVRInput.Button.One))
            transform.Translate(_speed * Time.deltaTime * -1 * centerCamera.transform.up);

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft)) transform.Rotate(0, -2 * _speed * Time.deltaTime, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight)) transform.Rotate(0, 2 * _speed * Time.deltaTime, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp)) transform.Rotate(-2 * _speed * Time.deltaTime, 0, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown)) transform.Rotate(2 * _speed * Time.deltaTime, 0, 0);
    }
}