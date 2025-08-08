using UnityEngine;

public class StudyDecoupling2 : MonoBehaviour
{
    public class Player
    {
        public Enemy enemy;

        public void AttackEnemy(IDamageable target, float damage)
        {
            target.TakeDamage(damage);
        }


    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        public float health = 10f;

        public void TakeDamage(float damage)
        {
            health -= damage;
            Debug.Log($"{damage}만큼 공격 받음");
        }
    }
}
