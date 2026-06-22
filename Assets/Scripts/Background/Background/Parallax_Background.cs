using UnityEngine;

public class Parallax_Background : MonoBehaviour, IBackground
{
    private Player _player;
    private Sprite _sprite;
    private Camera _camera

    private Vector2 _cam2sprite_dst;
    private float _max_velocity;
    public void Initialize(Camera camera, Sprite sprite, Vector2 maxVelocity)
    {
        _sprite = sprite;
        _camera = camera;
        _maxVelocity = maxVelocity;
        _player = GameManager.Get_Player_Ref();

        _cam2sprite_dst = gameObject.transform.position - camera.transform.position;

    }

    override public void OnEnter()
    {
        // Çã~Á¢ ³»²¨
    }

    private float _x_stride;
    private float _y_stride;

    override public void Frame_Update()
    {
        if()

        //ÆÐ·²·º½º 
    }

    override public void Physics_Update()
    {

    }

    override public void OnExit()
    {

    }


}
