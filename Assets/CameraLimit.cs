using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraLimit : MonoBehaviour
{
    Player enemy;

    // Use this for initialization
    void Start()
    {
        enemy = GetComponentInParent<Player>();
        enemy.cameraLimit = true;
    }

    void OnDestroy()
    {
        enemy.cameraLimit = false;
    }
}
