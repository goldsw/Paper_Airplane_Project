using UnityEngine;

public class Parallax_Background : MonoBehaviour, IBackground
{
    private Sprite _sprite;
    private float _maxVelocity;
    private Player _player;
    public void Initialize(Sprite sprite, Vector2 maxVelocity)
    {
        _sprite = sprite;
        _maxVelocity = maxVelocity;
    }

    override public void OnEnter()
    {
        _player = GameManager.Get_Player_Ref();
    }

    override public void Frame_Update()
    {

    }

    override public void Physics_Update()
    {

    }

    override public void OnExit()
    {

    }


}
