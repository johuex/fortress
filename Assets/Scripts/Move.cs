using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{

    public float speed = 10.0f;
    Rigidbody rigidBody;
    float horizontal;
    float vertical;

    //чувсвительность камеры
    public float sensitiveX = 3.0F;
    public float sensitiveY = 3.0F;

    //ограничения камеры
    public float minX = -360;
    public float maxX = 360;
    public float minY = 0;
    public float maxY = -0;

    public Quaternion originalRot;
    Quaternion xQuaternion;
    Quaternion yQuaternion;

    //переменные поворота камеры
    public float rotX = 0;
    public float rotY = 0;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        //ограничение движения после остановки мышки
        originalRot = transform.localRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rigidBody.AddForce(((transform.forward * -5)) * speed / Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        //horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rigidBody.AddForce(((transform.right * horizontal) + (transform.forward * vertical)) * speed / Time.deltaTime);

        rotX += Input.GetAxis("Mouse X") * sensitiveX;
        rotY += Input.GetAxis("Mouse Y") * sensitiveY;

        rotX = rotX % 360;
        rotY = rotY % 360;

        //ограничение движения камеры по осям
        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);

        //поворот на угол вокруг осей
        xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = originalRot * xQuaternion * yQuaternion;



        //////////

    }
}
