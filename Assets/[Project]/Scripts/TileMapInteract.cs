using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TileMapInteract : MonoBehaviour
{
    [Header("Managers :")]
    [SerializeField] private TurretManager _turretManager;
    [Header("TileMap")]
    [SerializeField] private Tilemap _tileMap;
    [Space]
    [SerializeField] private GameObject _selectedElement; //TODO ui + methode pour set l'item
    [SerializeField] private Tile _turretSlotTile;
    private Tile _tileUnderMouse;
    private Vector3 _worldMousePos;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
        _turretManager = GetComponentInChildren<TurretManager>();
    }

    private void Update()
    {
        _worldMousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _tileUnderMouse = (Tile)_tileMap.GetTile(_tileMap.WorldToCell(_worldMousePos));
    }

    private void OnMouseLeft()
    {
        // print("Input");
        if (!_tileUnderMouse)
            return;
        // print("Baouaouaoua");
        if (_tileUnderMouse == _turretSlotTile)
            OnTurretSlotClic();
    }

    private void OnTurretSlotClic()
    {
        // print("Clic on slot");
        _turretManager.OnClicTurretSlot(_selectedElement, _tileMap.WorldToCell(_worldMousePos));
    }
}
