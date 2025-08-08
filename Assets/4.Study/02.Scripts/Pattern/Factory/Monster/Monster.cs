using UnityEngine;

namespace Pattern.factory
{
    public abstract class Monster : MonoBehaviour
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Attack { get; protected set; }

        protected virtual void Initialize(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Debug.Log($"»ý¼º : {Name} / {Health} / {Attack}");
        }
    }
}

