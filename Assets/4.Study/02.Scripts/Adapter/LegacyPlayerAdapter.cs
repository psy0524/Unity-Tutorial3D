using System.Collections;
using UnityEngine;

public class LegacyPlayerAdapter : MonoBehaviour, ICharacter
{
    private LegacyPlayer legacyPlayer;
    
    void Awake()
    {
        legacyPlayer = new LegacyPlayer();
    }
    
    public void Attack()
    {
        legacyPlayer.LegacyAttack();
    }

    public void Move(Vector3 dir)
    {
        legacyPlayer.LegacyMove(dir.x, dir.y, dir.z);
    }

    //public void Move2(Vector3 dir)
    //{
    //    legacyPlayer.transform.position += dir * Time.deltaTime * speed;
    //}
}
