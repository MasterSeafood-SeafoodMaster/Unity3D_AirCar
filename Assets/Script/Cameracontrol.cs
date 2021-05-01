using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrol : MonoBehaviour
{
    public float Speed = 2f;
    public float ASpeed;
    public float SA = 0.5f;


    public Transform CT;


    void Update()
    {
        
        float VerD = Mathf.Abs(CT.localPosition.z);
        float RotD = Mathf.Abs(CT.localRotation.eulerAngles.z);

        Debug.Log(VerD);

        if ((VerD < 2) & (Input.GetAxisRaw("Vertical") != 0))
        {
            CT.position += CT.transform.forward * -Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime;
        }
        else if ((Input.GetAxis("Mouse X")!=0) & ((RotD < 30) | (RotD > 330)))
        {
            CT.Rotate(Vector3.forward * Speed * 0.2f * Input.GetAxis("Mouse X"));
        }
        else
        {
            CT.position = Vector3.MoveTowards(CT.position, transform.position, Speed * Time.deltaTime);
            CT.rotation = Quaternion.RotateTowards(CT.rotation, transform.rotation, Speed * 0.15f);
        }



    }
}
