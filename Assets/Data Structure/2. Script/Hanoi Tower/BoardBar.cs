using System.Collections.Generic;
using UnityEngine;

public class BoardBar : MonoBehaviour
{
    public enum BarType { Left, Center, Right };
    public BarType barType;

    public Stack<GameObject> barStack = new Stack<GameObject>();

    private void OnMouseDown() // 콜라이더만 있으면 됨
    {
        if (!HanoiTower.isSelected)
        {
            HanoiTower.selectedDonut = PopDonut();
        }
        else // 선택된 상태일 때
        {
            PushDonut(HanoiTower.selectedDonut);
        }
    }

    public bool CheckDonut(GameObject donut)
    {
        if (barStack.Count > 0)
        {
            int pushNumber = donut.GetComponent<Donut>().donutNumber;

            GameObject peekDonut = barStack.Peek();
            int peekNumber = peekDonut.GetComponent<Donut>().donutNumber;

            if (pushNumber < peekNumber)
            {
                return true;
            }
            else
            {
                Debug.Log($"현재 넣으려는 도넛은 {pushNumber}이고, 해당 기동의 제일 위의 도넛은 {peekNumber}입니다.");
                return false;
            }
        }
        return true;
    }
    public void PushDonut(GameObject donut)
    {
        if (!CheckDonut(donut))
            return;

        HanoiTower.moveCount++;
        HanoiTower.isSelected = false;
        HanoiTower.selectedDonut = null;

        donut.transform.position = transform.position + Vector3.up * 5f;
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        barStack.Push(donut);

    }

    public GameObject PopDonut()
    {
        if (barStack.Count > 0)
        {
            HanoiTower.currBar = this;
            HanoiTower.isSelected = true;
            GameObject donut = barStack.Pop();
            return donut;
        }
        return null;
    }
}
