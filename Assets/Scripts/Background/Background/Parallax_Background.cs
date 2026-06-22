using System;
using UnityEngine;

public class Parallax_Background : MonoBehaviour, IBackground
{
    private Player _player;
    private Sprite _sprite;
    private Camera _camera;

    private Vector2 _max_velocity;

    private float _next_background_x;
    private float _next_background_y;
    public void Initialize(Camera camera, Sprite sprite, Vector2 maxVelocity)
    {

        if (Set_Background_Next_Pos(sprite.bounds.size.x, sprite.bounds.size.y))
        {
            Debug.Log("Background Sprite is not valueble");
            return;
        }

        _sprite = sprite;
        _camera = camera;
        _player = GameManager.Get_Player_Ref();

        _max_velocity = maxVelocity;

    }

    public void OnEnter()
    {
        // Çã~Á¢ ³»²¨
    }

    public void Frame_Update()
    {
        Vector3 cam2sprite_dst = Get_Dst2Camera(_camera);
        Check_OutofCameraRange(cam2sprite_dst);


        //ÆÐ·²·º½º 
    }

    public void Physics_Update()
    {

    }

    public void OnExit()
    {

    }

    private bool Set_Background_Next_Pos(float bg_width_x, float bg_size_y)
    {
        Vector2 camera_world_size = new Vector2(0, 0)
        {
            x = Screen.width / (Screen.height / _camera.orthographicSize),
            y = _camera.orthographicSize
        };

        if (bg_width_x < camera_world_size.x || bg_size_y < camera_world_size.y) return false;

        _next_background_x = bg_width_x + camera_world_size.x;
        _next_background_y = bg_size_y + camera_world_size.y;

        return true;
    }

    private Vector3 Get_Dst2Camera(Camera camera)
    {
        return camera.transform.position - transform.position;
    }

    private void Check_OutofCameraRange(Vector3 dst)
    {
        if (Math.Abs(dst.x) > _next_background_x)
        {
            float dst_error_stride = dst.x - _next_background_x;
            int sign = (int)(dst_error_stride / dst_error_stride);

            Vector3 next_pos_x = transform.position + new Vector3(sign * (_next_background_x - dst_error_stride), 0, 0);
            Move_Position(next_pos_x);
        }

        if (Math.Abs(dst.y) > _next_background_y)
        {
            float dst_error_stride = dst.y - _next_background_y;
            int sign = (int)(dst_error_stride / dst_error_stride);

            Vector3 next_pos_y = transform.position + new Vector3(0, sign * (_next_background_y - dst_error_stride), 0);
            Move_Position(next_pos_y);
        }
    }

    private void Move_Position(Vector3 pos)
    {
        transform.position = pos;
    }
}
