using System;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax_Background : MonoBehaviour, IBackground
{
    //public struct Background_Positioning_Values
    //{
    //    public float _parallax_scale;
    //    public float _next_background_x;
    //    public float _next_background_y;
    //    public float _tp_area_x_range;
    //    public float _tp_area_y_range;
    //}



    [Header("test values")]
    public Camera test_cam;
    public Sprite test_sprite;
    public float test_parallax_scale;

    public int offset_index_y;

    [Header("in game values")]
    private Camera _camera;
    private Player _player;
    private Sprite _background_sprite;

    [Header("positioning values")]
    private Vector3 _start_Pos;
    private float _parallax_scale;
    private float _background_size_x;
    private float _background_size_y;

    



    private void Start()
    {
        Initialize(test_cam, test_sprite, 1.5f, 1.5f, test_parallax_scale);
        _start_Pos = transform.position;
    }

    public void Initialize(Camera camera, Sprite background_sprite, float scale_x, float scale_y, float parallax_scale)
    {
        float background_size_x = background_sprite.bounds.size.x * scale_x;
        float background_size_y = background_sprite.bounds.size.y * scale_y;

        _background_size_x = background_size_x;
        _background_size_y = background_size_y;




        _background_sprite = background_sprite;
        _camera = camera;
        //_player = GameManager.Get_Player_Ref();

        _parallax_scale = parallax_scale;
    }

    public void OnEnter()
    {
        // 허~접 내꺼
    }

    private void Update()//test Update
    {
        Frame_Update();
    }

    public void Frame_Update()
    {
        //TODO : 

        Idkthisfuncname();
        //패럴렉스 
    }

    public void Physics_Update()
    {

    }

    public void OnExit()
    {

    }

    static readonly int[] offset_x_index_array =
    {
        -1, 0, 1
    };

    static readonly int[] offset_y_index_array =
    {
        -1, 0, 1
    };

    private void Parallax_Scale()
    {
        Vector3 scrolling_pos = _camera.transform.position * _parallax_scale;
        //TODO : 패럴렉스

        Move_Pos(new Vector3(_start_Pos.x + scrolling_pos.x, _start_Pos.y + scrolling_pos.y, transform.position.z));
    }

    private void Idkthisfuncname()
    {
        float cam_x_index = Mathf.Floor(_camera.transform.position.x / _background_size_x);
        float cam_y_index = Mathf.Floor(_camera.transform.position.y / _background_size_y);

        float _my_index_x = Mathf.RoundToInt(transform.position.x / _background_size_x);
        float _my_index_y = Mathf.RoundToInt(transform.position.y / _background_size_y);

        if (Mathf.Abs(cam_x_index - _my_index_x) > 1)
        {

            float sign = MathF.Sign(cam_x_index - _my_index_x);
            _my_index_x += (int)(3 * sign);
            


            //TODO : 라운드 함수 때문에 1/2 지점에 도달하면 배경이 스와이프 되어서 겹쳐버림 스와이프 되는 지점에 y축 크기 1/2을 더해서 해보자.
            Vector3 next_backgorund_pos = new Vector3(
                _my_index_x * _background_size_x,
                transform.position.y,
                0
            );

            Move_Pos(next_backgorund_pos);
        }


        if (Mathf.Abs(cam_y_index - _my_index_y) > 1)
        {

            float sign = MathF.Sign(cam_y_index - _my_index_y);
            _my_index_y += (int)(3 * sign);

            Debug.Log("he");

            Vector3 next_backgorund_pos = new Vector3(
                transform.position.x,
                _my_index_y * _background_size_y,
                0
            );

            Move_Pos(next_backgorund_pos);
        }

        //float stride = MathF.Abs(_camera.transform.position.y - transform.position.y);

        //offset_index_y = (int)((transform.position.y - (_camera.transform.position.y - _background_size_y)) / (_background_size_y - 1));
        //if (offset_index_y < 0)
        //{
        //    offset_index_y = 2;
        //}
        //else if (offset_index_y > 2)
        //{
        //    offset_index_y = 0;
        //}

        //float background_tile_y = _camera.transform.position.y / _background_size_y;

        //int background_tile_index_y = (int)background_tile_y;

        //Move_Pos(new Vector3(transform.position.x, background_tile_index_y * _background_size_y + offset_index_array[offset_index_y] * _background_size_y));

    }

    private void Move_Pos(Vector3 pos)
    {
        transform.position = pos;
    }

    // 레벨 바꾸는건 어디서??..

}
