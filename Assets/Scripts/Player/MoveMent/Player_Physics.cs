using System;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class Player_Physics : MonoBehaviour
{

    #region Physics properties

    Rigidbody2D Player_RB;

    public bool isStart = true;

    [SerializeField] private Vector2 gravity  = new Vector2(0, -9.8f);
    [SerializeField] private Vector2 air_drag = new Vector2(0, 6);

    private Vector2 input_acceleration        = new Vector2(0, 0);
    private Vector2 acceleration              = new Vector2(0, 0);
    private Vector2 gravity_velocity          = new Vector2(0, 0);
    private Vector2 input_velocity            = new Vector2(0, 0);

    public float max_speed_stats;
    public float max_speed;
    public float max_gravity_speed;



    #endregion


    #region tests

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Start_Item_Physics_Delegate += Manager_PhysicsUpdate;
        GameManager.Start_Item_Update_Delegate += Manager_Update;
        Manager_Start();
        Player_RB = GetComponent<Rigidbody2D>();
        //Initialize_Stats(new Vector2(0, 2), 10, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Add_Force(new Vector2(0, 2));
        //}
        //Manager_Update();
    }

    private void FixedUpdate()
    {
        //Manager_PhysicsUpdate();
    }

    #endregion

    public void Initialize_Stats(Vector2 _air_drag_up, float _max_speed, float _max_gravity_speed)
    {
        air_drag = _air_drag_up;
        max_speed_stats = _max_speed;
        max_speed = _max_gravity_speed;
        max_gravity_speed = _max_gravity_speed;
    }

    public void Initialize_Stats(Player_Stats _stats)
    {
        air_drag = new Vector2(0, _stats.featherlight);
        max_speed_stats = _stats.agility;
        max_gravity_speed = _stats.lift;
    }

    #region Manager Callbackfucs

    public void Manager_Start()
    {
        input_velocity = Vector2.zero;
        gravity_velocity = Vector2.zero;
    }
    public void Manager_Update()
    {

    }
    public void Manager_PhysicsUpdate()
        //가속도
        //속도 += 가속도
        //위치 += 속도
    {
        if(isStart)
        { 
            acceleration = gravity + air_drag;
            Add_Force(new Vector2(3f, 0));
        }
        


        //가속도 계산
        gravity_velocity += acceleration * Time.fixedDeltaTime;
        gravity_velocity = Vector2.ClampMagnitude(gravity_velocity, max_gravity_speed);
        input_velocity += input_acceleration * Time.fixedDeltaTime;
        input_velocity = Vector2.ClampMagnitude(input_velocity, max_speed);


        Vector3 velocity = gravity_velocity + input_velocity;



        Vector3 next_pos = (transform.position + new Vector3(velocity.x, velocity.y) * Time.fixedDeltaTime);
        Vector3 dir = next_pos - transform.position;

        //각도계산
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //위치
        transform.position = next_pos;
        Camera.main.transform.position = new Vector3(next_pos.x, next_pos.y, Camera.main.transform.position.z);

        //물리 밸류 초기화
        input_acceleration = Vector2.zero;
        acceleration = Vector2.zero;
        max_speed = max_speed_stats;

        //Debug.Log(next_pos);
        Debug.DrawLine(transform.position, next_pos);
    }
    public void Manager_Exit()
    {

    }

    #endregion

    public void Add_Force(Vector2 force)
    {
        input_acceleration += force / Player_RB.mass;
    }

    public void Add_Max_Speed(float _max_speed)
    {
        max_speed += _max_speed;
    }

    public void Set_air_drag(Vector2 _air_drag)
    {
        air_drag = _air_drag;
    }
    
    public void Add_air_drag(Vector2 _air_drag)
    {
        air_drag += _air_drag;
    }


}
