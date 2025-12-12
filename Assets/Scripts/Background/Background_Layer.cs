using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Background_Layer : MonoBehaviour
{
    public Sprite background_image;
    public float parallaxEffect;
    public Camera cam;
    public Background_Manager bg_manager;

    private SpriteRenderer spriteRenderer;
    private Player_Physics player_Physics;
    private Vector2 startPos;
    private float width;
    private float height;


    private void Start()
    {
        startPos = (Vector2)transform.position;

        player_Physics = GameObject.FindWithTag("Player").GetComponent<Player_Physics>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = background_image;


        width = background_image.bounds.size.x;
        height = background_image.bounds.size.y;
    }

    private void Update()
    {
        Vector2 distanceVec = (Vector2)cam.transform.position * parallaxEffect;
        Vector2 movementVec = (Vector2)cam.transform.position * (1 - parallaxEffect);


        //transform.position = new Vector3(startPos.x + distanceVec.x, startPos.y + distanceVec.y, 0);

        bg_manager.Check_out_range(this.transform);
    }


    public void Change_Background(Sprite _sprite)
    {
        background_image = _sprite;
        spriteRenderer.sprite = background_image;
        width = spriteRenderer.bounds.size.x;
        height = spriteRenderer.bounds.size.y;
    }

       





}
