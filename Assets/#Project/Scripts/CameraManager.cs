using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour
{
    public Camera cam;

    public void Initialize(Vector3 position, Quaternion rotation)
    {
        transform.SetPositionAndRotation(position, rotation);
        cam = GetComponent<Camera>();
    }

    public (Vector3, Vector3) GetRightBorderPoints(float z)
    {
        Vector3 top = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, z));
        Vector3 bottom = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, z));
        return (bottom, top);
    }

    public (Vector3, Vector3) GetLeftBorderPoints(float z)
    {
        Vector3 top = cam.ScreenToWorldPoint(new Vector3(Screen.height, 0f, z));
        Vector3 bottom = cam.ScreenToWorldPoint(new Vector3(0f, 0f, z));
        return (top, bottom);
    }
}
