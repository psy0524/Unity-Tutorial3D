using UnityEngine;

namespace Pattern.factory
{
    public abstract class MonsterFactory : MonoBehaviour
    {
        public Monster SpawnMonster(string type)
        {
            Monster monster = CreateMonster(type);

            return monster;
        }

        public abstract Monster CreateMonster(string type);
    }
}

