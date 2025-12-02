using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Background_Layer : MonoBehaviour
{
    public Sprite background_image;
    public float parallaxEffect;
    public Camera cam;

    private SpriteRenderer spriteRenderer;
    private Player_Physics player_Physics;
    private Vector2 startPos;
    private float width;
    private float height;


    private void Start()
    {
        startPos = (Vector2)transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = background_image;
        player_Physics = GameObject.FindWithTag("Player").GetComponent<Player_Physics>();
        width = background_image.bounds.size.x;
        height = background_image.bounds.size.y;
    }

    private void Update()
    {
        Debug.Log(Screen.width);
        Debug.Log(spriteRenderer.bounds.size.x);

        Vector2 distanceVec = (Vector2)cam.transform.position * parallaxEffect;
        Vector2 movementVec = (Vector2)cam.transform.position * (1 - parallaxEffect);

        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * 1 - parallaxEffect;

        transform.position = new Vector3(startPos.x + distanceVec.x, startPos.y + distanceVec.y, 0);

        if (movementVec.x > startPos.x + width) //0 30
        {
            startPos.x += width;
        }
        else if (movementVec.x < startPos.x - width)
        {
            startPos.x -= width;
        }

        if (movementVec.y > startPos.y + height) //not wigth
        {
            startPos.y += height;
        }
        else if (movementVec.y < startPos.y - height)
        {
            startPos.y -= height;
        }
    }


    public void Change_Background(Sprite _sprite)
    {
        background_image = _sprite;
        spriteRenderer.sprite = background_image;
        width = spriteRenderer.bounds.size.x;
        height = spriteRenderer.bounds.size.y;
    }

       





}
