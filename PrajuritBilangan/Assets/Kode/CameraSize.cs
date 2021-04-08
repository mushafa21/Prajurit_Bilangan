using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public SpriteRenderer border;
    void Start()
    {
        float orthosize = border.bounds.size.x * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = orthosize;
        
    }


}
