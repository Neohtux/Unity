using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. 위치 벡터
//2. 방향 벡터
struct MyVector
{
    public float x;
    public float y;
    public float z;

    //
    //       + 
    //   +---+
    //+------+
    public float magnitude { get { return Mathf.Sqrt(x*x + y*y +z*z); } } //방향 벡터의 크기

    public MyVector normalized {  get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); } }

    public MyVector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);
    }
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }
    public static MyVector operator *(MyVector a, float d)
    {
        return new MyVector(a.x * d, a.y * d, a.z * d);
    }
}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        MyVector to = new MyVector(10.0f, 0.0f, 0.0f);
        MyVector from = new MyVector(5.0f, 0.0f, 0.0f);
        MyVector dir = to-from; //{-5.0f,0.0f,0.0f}

        dir = dir.normalized; //{1.0f,0.0f,0.0f}; 단위벡터 얻어오기

        MyVector newPos = from + dir * _speed;

        //방향 벡터
        //1. 거리 (크기)    5 //manitude
        //2. 실제 방향      -> //단위벡터 nomalized
    }
    //GameObject (Player)
     //Transform
     //PlayerController
    void Update()
    {
        //World -> Local 좌표변환
        //transform.InverseTransformDirection

        //Local -> World 좌표변환
        //transform.TransformDirection

        //transform.Translate
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * _speed); //현재 시간과 비례한 수치를 곱
        if (Input.GetKey(KeyCode.S))
            transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed);

        if (Input.GetKey(KeyCode.A))
            transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);

        if (Input.GetKey(KeyCode.D))
            transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);
        //transform
    }
}
