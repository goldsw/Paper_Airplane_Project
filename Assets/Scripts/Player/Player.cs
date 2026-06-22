using UnityEngine;

public class Player : MonoBehaviour
{
    Player_Stats stats;
    public Player_Physics Physics;

    [SerializeField]
    float speed;
    [SerializeField]
    float max_gravity;
    [SerializeField]
    float air_darg;

    private void Start() //test
    {
        stats = new Player_Stats(null, speed, air_darg, max_gravity, 0f, 0f); // 테스트용
        Initialize(stats);
    }

    public void Initialize(Player_Stats _stats)
    {
        stats = _stats;
        Physics = GetComponent<Player_Physics>();
        Physics.Initialize_Stats(stats);
    }

    //static




}
