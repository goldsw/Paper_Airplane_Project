using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item/Item_Information", order = 1)]
public class Item_Information : ScriptableObject
{
    [Header("아이템 정보")]
    Item_type item_Type;
    public int price;
    public Sprite item_sprite;
    public string item_instruction;

    [Header("아이템 이펙트")]
    public GameObject Effect;

    [Header("아이템 밸류")]
    public Vector2 direction;
    public float speed;
    public float damage;
    public float cooltime;

    enum Item_type
    {
        무기,
        부스터,
        효과
    }
}
