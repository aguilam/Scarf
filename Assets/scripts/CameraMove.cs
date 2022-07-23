using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;



    public float camera_speed_follow = 10f;


    void FixedUpdate()
    {
        Vector3 position_camera = transform.position;

        Vector3 camera_Transform = new Vector3(position_camera.x, position_camera.y, -10f);
        Vector3 target_Transform = new Vector3(target.position.x, target.position.y, 0);
        position_camera = Vector3.Lerp(camera_Transform, target_Transform, camera_speed_follow * Time.deltaTime);



        transform.position = position_camera;
    }
}
