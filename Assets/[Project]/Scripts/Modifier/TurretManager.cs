using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private Dictionary<Vector3Int, GameObject> _turretDictionary = new Dictionary<Vector3Int, GameObject>();
    private CanvasTree _openTree;

    public void OnClicTurretSlot(GameObject turret, Vector3Int tilePosition)
    {
        // print("TurretSlot pos : " + tilePosition);
        if (_openTree && _turretDictionary.Count != 0)
            return;

        if (_turretDictionary.ContainsKey(tilePosition))
        {
            _openTree = _turretDictionary[tilePosition].GetComponentInChildren<CanvasTree>();
            _openTree.OpenCanvas();
            return;
        }

        SpawnNewTurret(turret, tilePosition);
    }

    public void OnCloseTurretTree()
    {
        _openTree = null;
    }

    private void SpawnNewTurret(GameObject turret, Vector3Int tilePos)
    {
        GameObject newElement = Instantiate(turret, tilePos + (Vector3.one * .5f), Quaternion.identity);
        newElement.GetComponentInChildren<CanvasTree>().Initialize(this);
        _turretDictionary.Add(tilePos, newElement);
    }

    public void RemoveElement(Vector3Int elementPosition)
    {
        if (_turretDictionary.ContainsKey(elementPosition))
        {
            Destroy(_turretDictionary[elementPosition]);
            _turretDictionary.Remove(elementPosition);
        }
    }







}
