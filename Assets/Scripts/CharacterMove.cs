using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // Start is called before the first frame update
    
    //основные параметры
    public float speedMove;

    //параметры перемещения для персонажа
    private float gravityForce;
    private Vector3 moveVector;

    private CharacterController ch_controller;



    //чувсвительность камеры
    public float sensitiveX = 3.0F;
    public float sensitiveY = 3.0F;

    //ограничения камеры
    public float minX = -360;
    public float maxX = 360;
    public float minY = 0;
    public float maxY = -0;

    public Quaternion originalRot;

    //переменные поворота камеры
    public float rotX = 0;
    public float rotY = 0;

    private void Start()
    {
        ch_controller = this.GetComponent<CharacterController>();
        originalRot = transform.localRotation;
    }

    // Update is called once per frame
    private  void Update()
    {
        ChrMove();
        GamingGravity();
    }

    private void ChrMove()//перемещение влево вправо
    {
        moveVector = Vector3.zero;
        moveVector.z = Input.GetAxis("Horizontal") * speedMove;
        moveVector.x = Input.GetAxis("Vertical") * speedMove;
        moveVector.y = gravityForce;

        ch_controller.Move(moveVector * Time.deltaTime);

        rotX += Input.GetAxis("Mouse X") * sensitiveX;
        rotY += Input.GetAxis("Mouse Y") * sensitiveY;

        rotX = rotX % 360;
        rotY = rotY % 360;

        //ограничение движения камеры по осям
        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);

        //поворот на угол вокруг осей
        Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = originalRot * xQuaternion * yQuaternion;
    }

    //метод гравитации
    private void GamingGravity()
    {
        if (!ch_controller.isGrounded)
            gravityForce -= 5f * Time.deltaTime;
        else
            gravityForce = -1f;
    }


}