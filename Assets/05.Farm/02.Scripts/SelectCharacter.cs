using System.Collections;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private Transform centerPivot;
    [SerializeField] private Button[] turnButtons;
    [SerializeField] private Button selectButton;

    private bool isTurn;
    private int currentIndex;
    [SerializeField] private Animator[] characterAnims;

    private void Start()
    {
        turnButtons[0].onClick.AddListener(() => Turn(true));
        turnButtons[1].onClick.AddListener(() => Turn(false));

        selectButton.onClick.AddListener(Select);
        
    }

    private void Turn(bool isLeft)
    {
        if (!isTurn)
        {
            int value = isLeft ? -1 : 1;
            currentIndex += value;

            //캐릭터가 4개이기 때문에 0~3 까지 범위로 설정
            if (currentIndex < 0)
            {
                currentIndex = 3;
            }
            else if (currentIndex > 3)
            {
                currentIndex = 0;
            }

            float turnValue = value * 90;
            var targetRot = centerPivot.rotation * Quaternion.Euler(0, turnValue, 0);


            isTurn = true;
            StartCoroutine(TurnRoutine(targetRot));
        }

    }

    IEnumerator TurnRoutine(Quaternion targetRot)
    {
        while (true)
        {
            yield return null;

            centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, targetRot, 10f * Time.deltaTime);

            Debug.Log("Turn");

            var angle = Quaternion.Angle(centerPivot.rotation, targetRot);
            if (angle <= 0.1f)
            {
                isTurn = false;
                centerPivot.rotation = targetRot;
                yield break;
            }
        }
    }

    private void Select()
    {
        characterAnims[currentIndex].SetTrigger("Select");
        Debug.Log($"현재 선택한 캐릭터는 {currentIndex}번째 캐릭터입니다.");
    }
}
