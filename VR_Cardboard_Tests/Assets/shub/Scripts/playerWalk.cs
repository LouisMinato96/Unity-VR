using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerWalk : MonoBehaviour
{
  public int playerSpeed = 15;
  private bool gyroEnabled;
  private Gyroscope m_Gyro;

  // Start is called before the first frame update
  void Start()
  {
    gyroEnabled = EnableGyro();
  }

  // Update is called once per frame
  void Update()
  {
    // GyroscopeValue();
    Quaternion rotation = m_Gyro.attitude;
    Vector3 eulerAngle = rotation.ToEulerAngles();

    Debug.Log("MANDAL:------" + eulerAngle[1]);

    if (gyroEnabled && eulerAngle[1] >= 1.8 && eulerAngle[1] <= 2.0)
    {
      Debug.Log("FORWARD");
      transform.position = transform.position - Camera.main.transform.forward * playerSpeed * Time.deltaTime;
    }
    else if (gyroEnabled && eulerAngle[1] >= 1.2 && eulerAngle[1] <= 1.3)
    {
      Debug.Log("BACK");
      transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
    }
    Debug.Log("SHUB::::::" + transform.position);
  }

  private bool EnableGyro()
  {
    if (SystemInfo.supportsGyroscope)
    {
      m_Gyro = Input.gyro;
      m_Gyro.enabled = true;
      return true;
    }
    return false;
  }

  void GyroscopeValue()
  {
    //Output the rotation rate, attitude and the enabled state of the gyroscope as a Label
    Debug.Log("Gyro rotation rate " + m_Gyro.rotationRate);
    Debug.Log("Gyro attitude" + m_Gyro.attitude);
    Debug.Log("Gyro enabled : " + m_Gyro.enabled);
  }

}
