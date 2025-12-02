using UnityEngine;

public class CameraManager : MonoBehaviour
{
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = Screen.height / 2;
    }

}
