using System.Collections.Generic;
using UnityEngine;


namespace Pattern.Command
{
    public class PlayerController : MonoBehaviour
    {
        public Player player;

        private ICommand attackCommand, jumpCommand, skillCommand;

        private Queue<ICommand> commandQueue = new Queue<ICommand>();
        private Stack<ICommand> excuteCommand = new Stack<ICommand>();

        private void Awake()
        {
            attackCommand = new AttackCommand(player);
            jumpCommand = new JumpCommand(player);
            skillCommand = new SkillCommand(player, "Fireball");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) // 공격 기능
            {
                attackCommand.Excute();
                excuteCommand.Push(attackCommand);
            }

            else if (Input.GetKeyDown(KeyCode.W)) // 점프 기능
            {
                jumpCommand.Excute();
                excuteCommand.Push(jumpCommand);
            }

            else if (Input.GetKeyDown(KeyCode.E)) // 스킬 기능
            {
                skillCommand.Excute();
                excuteCommand.Push(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) // 공격 기능
            {
                commandQueue.Enqueue(attackCommand);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2)) // 점프 기능
            {
                commandQueue.Enqueue(jumpCommand);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3)) // 스킬 기능
            {
                commandQueue.Enqueue(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("턴 종료 및 명령 실행");
                while(commandQueue.Count > 0)
                {
                    ICommand command = commandQueue.Dequeue();
                    command.Excute();
                }
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if(excuteCommand.Count > 0)
                {
                    ICommand lastCommand = excuteCommand.Pop(); // 가장 최근에 실행한 명령
                    Debug.Log($"명령 취소 : {lastCommand.GetType().Name}");

                    lastCommand.Cancel(); // Undo
                }
                else
                {
                    Debug.Log("되돌릴 명령이 없습니다.");
                }
            }
        }
    }
}

