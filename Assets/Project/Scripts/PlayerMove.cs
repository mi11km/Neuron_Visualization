using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float step;
    private float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Define step value for animation
        step = 7.0f * Time.deltaTime;
        speed = 2.0f * Time.deltaTime;

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft)) transform.Rotate(0, -5.0f * step, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight)) transform.Rotate(0, 5.0f * step, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp)) transform.Rotate( -5.0f * step, 0, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown)) transform.Rotate(5.0f * step, 0, 0);

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp)) transform.Translate(Vector3.forward * speed);
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown)) transform.Translate(Vector3.back * speed);
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft)) transform.Translate(Vector3.left * speed);
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight)) transform.Translate(Vector3.right * speed);

    }
}