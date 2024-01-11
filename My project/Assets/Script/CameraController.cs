using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    public float movementSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // 이동 입력 처리 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 상하 좌우 이동
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(moveDirection * movementSpeed * Time.deltaTime, Space.World);
    }

    // 버튼 클릭 이벤트

    public void MoveUp()
    {
        transform.Translate(Vector3.up);
    }

    public void MoveDown()
    {
        transform.Translate(Vector3.down);
    }

    public void MoveLeft()
    {
        transform.Translate(Vector3.left);
    }

    public void MoveRight()
    {
        transform.Translate(Vector3.right);
    }

    public void MoveForward()
    {
        transform.Translate(Vector3.forward);
    }

    public void MoveBack()
    {
        transform.Translate(Vector3.back);
    }
}
