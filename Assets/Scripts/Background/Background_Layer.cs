using UnityEngine;
using UnityEngine.UI;

public class Background_Layer : MonoBehaviour
{
    public Sprite background_image;
    private Player_Physics player_Physics;
    private float bg_x;
    private float bg_y;


    private void Start()
    {
        player_Physics = GameObject.FindWithTag("Player").GetComponent<Player_Physics>();
    }

    private void Update()
    {
           
    }


    public void Change_Background(Sprite _sprite)
    {
        background_image = _sprite;
        bg_x = background_image.bounds.size.x;
        bg_y = background_image.bounds.size.y;
    }

       





}
