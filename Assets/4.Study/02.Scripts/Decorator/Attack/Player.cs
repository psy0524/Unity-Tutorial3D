using Assets._4.Study._02.Scripts.Decorator;
using System.Collections;
using UnityEngine;

namespace Pattern.Decorator
{
    public class Player : MonoBehaviour
    {
        private void Start()
        {
            IAttack attack = new BasicAttack();

            attack = new FireAttack(attack);
            attack.Execute();

            attack = new IceAttack(attack);
            attack.Execute();
        }
    }
}