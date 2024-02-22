using System.Collections.Generic;
using UnityEngine;

public class TreeBaker : MonoBehaviour
{
    [SerializeField] private List<TreeNode> _nodeList;

    void Start()
    {
        _nodeList.Clear();
        foreach (var item in GetComponentsInChildren<TreeNode>())
            _nodeList.Add(item);

        BakeTree();
    }

    private void BakeTree()
    {
        for (int i = 0; i < _nodeList.Count; i++)
        {
            TreeNode currentNode = _nodeList[i];
            for (int y = 0; y < _nodeList.Count; y++)
            {
                Vector3 lookingNodeDirection = (currentNode.transform.position - _nodeList[y].transform.position).normalized;
                float dotP = Vector2.Dot(-currentNode.transform.up, lookingNodeDirection);
                float distance = Vector2.Distance(currentNode.transform.position, _nodeList[y].transform.position);

                if (dotP < -.9f && distance < 140f)
                {
                    _nodeList[y].AddNode = currentNode;
                    currentNode.AddNode = _nodeList[y];
                    break;
                }
            }
        }
    }
}
