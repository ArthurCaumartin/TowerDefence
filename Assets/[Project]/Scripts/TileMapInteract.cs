using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapInteract : MonoBehaviour
{
    [SerializeField] private Tilemap _tileMap;
    [SerializeField] private TurretSelector _turretSelector;
    [SerializeField] private GameObject _turretPrefab;
    [Space]
    [SerializeField] private Tile _turretSlotTile;
    private Tile _tileUnderMouse;
    private Vector3 _worldMousePos;
    private Camera _mainCam;
    private Dictionary<Vector3Int, GameObject> _useSlotDictionary = new Dictionary<Vector3Int, GameObject>();

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        _worldMousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        _tileUnderMouse = (Tile)_tileMap.GetTile(_tileMap.WorldToCell(_worldMousePos));

        
    }

    private void OnTurretSlotClic()
    {
        if (_useSlotDictionary.ContainsKey(_tileMap.WorldToCell(_worldMousePos)))
        {
            Destroy(_useSlotDictionary[_tileMap.WorldToCell(_worldMousePos)]);
            _useSlotDictionary.Remove(_tileMap.WorldToCell(_worldMousePos));
            return;
        }
        
        Vector3 spawnPos = _tileMap.WorldToCell(_worldMousePos);
        // _turretSelector.DisplaySelector((Vector2)spawnPos + (Vector2.one / 2));

        GameObject newTurret = Instantiate(_turretPrefab, spawnPos + (Vector3.one * .5f), Quaternion.identity);
        newTurret.transform.position = new Vector3(newTurret.transform.position.x, newTurret.transform.position.y, 0);

        _useSlotDictionary.Add(_tileMap.WorldToCell(_worldMousePos), newTurret);
    }

    private void OnMouseLeft()
    {
        if (!_tileUnderMouse)
            return;

        if (_tileUnderMouse == _turretSlotTile)
            OnTurretSlotClic();
    }
}
