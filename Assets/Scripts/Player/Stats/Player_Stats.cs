using UnityEngine;
using UnityEngine.UI;


public class Player_Stats
{
    public Sprite player_sprite;
    public float agility;
    public float featherlight;
    public float lift;
    public float fuel;
    public float defense_Rate;
    
    public Player_Stats(Sprite _player_sprite, float _agility, float _featherlight, float _lift, float _fuel, float _defense_Rate)
    {
        player_sprite = _player_sprite;
        agility = _agility;
        featherlight = _featherlight;
        lift = _lift;
        fuel = _fuel;
        defense_Rate = _defense_Rate;
    }
}
