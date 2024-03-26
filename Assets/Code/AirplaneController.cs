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

    float targetHorizontalInput;
    float targetVerticalInput;

    private void Update()
    {
        // inputs 馬潸 瞳辨
        targetHorizontalInput = Input.GetAxis("Horizontal");
        targetVerticalInput = Input.GetAxis("Vertical");

        horizontalInput = Mathf.Lerp(horizontalInput, targetHorizontalInput, Time.deltaTime * InputDamping);
        verticalInput = Mathf.Lerp(verticalInput, targetVerticalInput, Time.deltaTime * InputDamping);

        // move forward
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        // yaw, pitch, roll
        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * -Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        // apply rotation
        transform.rotation = Quaternion.Euler((Vector3.up * Yaw) + (Vector3.right * pitch) + (Vector3.forward * roll));
    }
}
