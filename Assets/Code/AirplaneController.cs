using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float FlySpeed = 5;
    public float YawAmount = 120;
    public float InputDamping = 0.5f; // 殮溘高 馬潸 啗熱

    private float Yaw;

    float horizontalInput;
    float verticalInput;

    private void Update()
    {
        // inputs 馬潸 瞳辨
        float targetHorizontalInput = Input.GetAxis("Horizontal");
        float targetVerticalInput = Input.GetAxis("Vertical");

        horizontalInput = Mathf.Lerp(horizontalInput, targetHorizontalInput, Time.deltaTime * InputDamping);
        verticalInput = Mathf.Lerp(verticalInput, targetVerticalInput, Time.deltaTime * InputDamping);
    }

    void FixedUpdate()
    {
        // move forward
        transform.position += transform.forward * FlySpeed * Time.fixedDeltaTime;

        // yaw, pitch, roll
        Yaw += horizontalInput * YawAmount * Time.fixedDeltaTime;
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * -Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        // apply rotation
        transform.localRotation = Quaternion.Euler((Vector3.up * Yaw) + (Vector3.right * pitch) + (Vector3.forward * roll));
    }
}
