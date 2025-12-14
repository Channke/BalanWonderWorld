using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject targetObj;
    Vector3 targetPos;
    public Vector3 offset;
    public float Xsensi = 1f;
    public float Ysensi = 1f;

    float mouseInputX, mouseInputY, current_mouseInputX, current_mouseInputY;
    public float dist;


    void Start()
    {
        transform.position = targetObj.transform.position + offset;
        dist = (this.transform.position -targetObj.transform.position).magnitude;
    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // マウスの移動量
        mouseInputX = Input.GetAxis("Mouse X") * Xsensi;
        mouseInputY = Input.GetAxis("Mouse Y") * Ysensi;

        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
        // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
        transform.RotateAround(targetPos, transform.right, -mouseInputY * Time.deltaTime * 200f);
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(targetPos, transform.position - targetPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, dist) && hit.collider.CompareTag("Ground"))
        {
            transform.position = hit.point;
        }
        Debug.DrawRay(ray.origin, ray.direction * dist, Color.red, 0.5f);
    }
}
