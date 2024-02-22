using UnityEngine;

public class ElementSelector : MonoBehaviour
{
    [SerializeField] private TileMapInteract _tileMapInteract;
    [SerializeField] private GameObject _selectedElement;

    public void SelectElement(GameObject toSelect)
    {
        if(toSelect == _selectedElement)
        {
            _selectedElement = null;
            return;
        }
        _selectedElement = toSelect;
    }
}
