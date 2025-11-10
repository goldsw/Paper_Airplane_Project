using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Start_Item/Start_Item_Information", order = 1)]
public class Start_Item_Information : ScriptableObject
{
    [Header("StartItem Info")]
    public Item_type item_type;
    public int price;
    public Image image;
    public string item_instruction;

    [Header("Start Item Effect")]
    public GameObject Effect;

    [Header("Start Item Value")]
    public Vector2 direction;
    public float speed;
    public float damage;
    public float max_magnitude;
    

    public enum Item_type
    {
        ªı√—,
        ∆»,
        ∑Œƒœ
    }
}
