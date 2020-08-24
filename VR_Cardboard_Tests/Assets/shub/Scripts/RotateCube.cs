using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
  public float spinForce = 40;
  Vector3 rotateInstruction = new Vector3(0, 1, 0);

  // Start is called before the first frame update
  void Start()
  {
    changeSpin();
  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(rotateInstruction * spinForce * Time.deltaTime);
    // Debug.Log("SHUBHAM1" + (transform.rotation).ToEulerAngles());
    // Debug.Log(Camera.main.transform.forward);
  }

  float rangeFloat()
  {
    return (float)(Random.Range(0, 20) - 10) / 10.0f;
  }

  Vector3 set_rotateInstruction()
  {
    float x = rangeFloat();
    float y = rotateInstruction[1];
    float z = rangeFloat();

    return new Vector3(x, y, z);
  }
  public void interactWith_GvrReticlePointer()
  {
    changeSpin();
  }
  public void changeSpin()
  {
    Vector3 get_rotateInstruction = set_rotateInstruction();
    rotateInstruction = get_rotateInstruction;
    rotateInstruction[1] = -rotateInstruction[1];
    Debug.Log(rotateInstruction);
    transform.Rotate(rotateInstruction * spinForce);
    Debug.Log("SHUBHAM--" + (transform.rotation).ToEulerAngles());
  }

}
