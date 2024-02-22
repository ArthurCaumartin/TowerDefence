using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapInteract : MonoBehaviour
{
    [SerializeField] private Tilemap _tileMap;
    [SerializeField] private GameObject _selectedElement;
    [Space]
    [SerializeField] private Tile _turretSlotTile;
    private Tile _tileUnderMouse;
    private Vector3 _worldMousePos;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _worldMousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _tileUnderMouse = (Tile)_tileMap.GetTile(_tileMap.WorldToCell(_worldMousePos));
    }

    private void OnTurretSlotClic()
    {
        GameManager.instance.PlaceElement(_selectedElement, _tileMap.WorldToCell(_worldMousePos));
    }

    private void OnMouseLeft()
    {
        if (!_tileUnderMouse)
            return;

        if (_tileUnderMouse == _turretSlotTile)
            OnTurretSlotClic();
    }
}
