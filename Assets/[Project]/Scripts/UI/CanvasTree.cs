using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CanvasTree : MonoBehaviour
{
    [SerializeField] private RectTransform _dragableContent;
    [SerializeField] private List<TreeNodeButton> _nodeList = new List<TreeNodeButton>();
    private Canvas _canvas;
    private TurretManager _turretManager;
    private bool _isNodeConnected;

    void Start()
    {
        _canvas = GetComponent<Canvas>();

        GetChildNode();
    }

    public void OpenCanvas()
    {
        print("Open canvas");
        _canvas.enabled = true;
        _dragableContent.anchoredPosition = Vector2.zero;
        if (!_isNodeConnected)
            ConnectNodes();
    }

    public void CloseCanvas()
    {
        print("Close canvas");
        _canvas.enabled = false;
        _dragableContent.anchoredPosition = Vector2.zero;

        _turretManager.OnCloseTurretTree();
    }

    private void GetChildNode()
    {
        _nodeList.Clear();
        foreach (var item in GetComponentsInChildren<TreeNodeButton>())
            _nodeList.Add(item);
    }

    private void ConnectNodes()
    {
        _isNodeConnected = true;
        for (int i = 0; i < _nodeList.Count; i++)
        {
            TreeNodeButton currentNode = _nodeList[i];
            for (int y = 0; y < _nodeList.Count; y++)
            {
                //! all dotP and distance are 0 while object disable ?!?
                Vector3 lookingNodeDirection = (currentNode.transform.position - _nodeList[y].transform.position).normalized;
                float dotP = Vector2.Dot(-currentNode.transform.up, lookingNodeDirection);
                float distance = Vector2.Distance(currentNode.transform.position, _nodeList[y].transform.position);

                // print(currentNode.name + " to " + _nodeList[y].name
                // + " | Dot : " + dotP + " | " + "| Dist : " + distance + " | ");

                if (dotP < -.9f && distance < 140f)
                {
                    print("Connect node");
                    _nodeList[y].AddNode = currentNode;
                    currentNode.AddNode = _nodeList[y];
                    break;
                }
            }
        }
    }

    public void Initialize(TurretManager turretManager)
    {
        _turretManager = turretManager;
    }
}
