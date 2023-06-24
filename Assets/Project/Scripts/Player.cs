using UnityEngine;

public class Player : MonoBehaviour
{
    private float step;
    private float speed = 2.0f;

    void Update()
    {
        // Define step value for animation
        step = 7.0f * Time.deltaTime;
        speed = 10.0f * Time.deltaTime;

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft)) transform.Rotate(0, -5.0f * step, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight)) transform.Rotate(0, 5.0f * step, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp)) transform.Rotate(-5.0f * step, 0, 0);
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown)) transform.Rotate(5.0f * step, 0, 0);

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp)) transform.Translate(Vector3.forward * speed);
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown)) transform.Translate(Vector3.back * speed);
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft)) transform.Translate(Vector3.left * speed);
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight)) transform.Translate(Vector3.right * speed);
        if (OVRInput.Get(OVRInput.Button.Two)) transform.Translate(Vector3.up * speed);
        if (OVRInput.Get(OVRInput.Button.One)) transform.Translate(Vector3.down * speed);

        if (OVRInput.Get(OVRInput.Button.Three)) transform.position = new Vector3(0, 0, 0);
    }
}