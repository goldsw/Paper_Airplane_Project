using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    Item Item;
    Button button;

    private void Start() // 아이템이 없다고 가정
    {
        button = GetComponent<Button>();
        //사진 = 기본 사진으로 설정
        //버튼 끄기;
    }

    public void Initialize(Item _Item)
    {
        Item = _Item;
        //버튼 키기
        //사진 Item의 사진으로 install
        
    }

    public void On_Click()
    {
        Item.OnClick();
    }
}
