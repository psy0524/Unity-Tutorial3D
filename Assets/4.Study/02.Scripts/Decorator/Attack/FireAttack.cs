using Pattern.Decorator;
using System.Collections;
using UnityEngine;

namespace Assets._4.Study._02.Scripts.Decorator
{
    public class FireAttack : AttackDecorator
    {
        public FireAttack(IAttack attack) : base(attack)
        {

        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("불 속성 추가 피해");
        }
    }
}