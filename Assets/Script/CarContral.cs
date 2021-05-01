using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContral : MonoBehaviour
{
    public float FSpeed=50f,SSpeed=50f, HSpeed=50f;
    public float AFSpeed, ASSpeed, AHSpeed;
    public float FA=2.5f, SA=2f, HA=2f;

    public float LRSpeed = 100f, LRSA = 2f;
    private Vector2 LInput, ScreenCenter, MouseDistance;

    private float RInput;
    public float RSpeed = 90f, RA = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LInput.x = Input.GetAxis("Mouse X");
        LInput.y = Input.GetAxis("Mouse Y");
        RInput = Mathf.Lerp(RInput, Input.GetAxis("Roll"), RA * Time.deltaTime);

        MouseDistance.x = Mathf.Lerp(MouseDistance.x, LInput.x * LRSpeed, LRSA * Time.deltaTime);
        MouseDistance.y = Mathf.Lerp(MouseDistance.y, LInput.y * LRSpeed, LRSA * Time.deltaTime);

        MouseDistance = Vector2.ClampMagnitude(MouseDistance, 1f);

        transform.Rotate(-LInput.y * LRSpeed * Time.deltaTime, LInput.x * LRSpeed * Time.deltaTime, -RInput * RSpeed * Time.deltaTime, Space.Self);

        AFSpeed = Mathf.Lerp(AFSpeed, Input.GetAxisRaw("Vertical")*FSpeed, FA*Time.deltaTime);
        ASSpeed = Mathf.Lerp(ASSpeed, Input.GetAxisRaw("Horizontal") * SSpeed, SA * Time.deltaTime);
        AHSpeed =  Mathf.Lerp(AHSpeed, Input.GetAxisRaw("Hover") * HSpeed, HA * Time.deltaTime);


        transform.position += transform.forward * AFSpeed * Time.deltaTime;
        transform.position += (transform.right * ASSpeed * Time.deltaTime) + (transform.up * AHSpeed * Time.deltaTime);


    }
}
