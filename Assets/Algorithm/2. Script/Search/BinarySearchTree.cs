using UnityEngine;

public class BinarySearchTree : MonoBehaviour
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int value)
        {
            this.value = value;
        }
    }

    private TreeNode root;
    private int[] array = { 8, 3, 10, 1, 6, 14, 4, 7, 13 }; // �迭

    private string result;

    private void Start()
    {
        foreach (var v in array)
        {
            root = Insert(root, v);
        }

        PreOrder(root);
        Debug.Log($"PreOrder : {result.TrimEnd().TrimEnd(',')}");
        result = string.Empty;

        InOrder(root);
        Debug.Log($"InOrder : {result.TrimEnd().TrimEnd(',')}");
        result = string.Empty;

        PostOrder(root);
        Debug.Log($"PostOrder : {result.TrimEnd().TrimEnd(',')}");
        result = string.Empty;
    }

    private TreeNode Insert(TreeNode node, int value)
    {
        if (node == null)
        {
            return new TreeNode(value);
        }

        if (value < node.value)
        {
            node.left = Insert(node.left, value);
        }
        else
        {
            node.right = Insert(node.right, value);
        }
        return node;
    }
    private void PreOrder(TreeNode node) // ���� ��ȸ
    {
        if(node == null)
        {
            return;
        }
        result += $"{node.value}, ";
        PreOrder(node.left);
        PreOrder(node.right);
    }

    private void InOrder(TreeNode node) // ���� ��ȸ
    {
        if (node == null)
        {
            return;
        }
        InOrder(node.left);
        result += $"{node.value}, ";
        InOrder(node.right);
    }

    private void PostOrder(TreeNode node) // ���� ��ȸ
    {
        if (node == null)
        {
            return;
        }
        PostOrder(node.left);
        PostOrder(node.right);
        result += $"{node.value}, ";
    }
}
