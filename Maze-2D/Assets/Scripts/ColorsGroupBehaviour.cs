using UnityEngine;
using UnityEngine.UI;

public class ColorsGroupBehaviour : MonoBehaviour
{
    [SerializeField] private ToggleGroup _toggleGroup = null;

    private void OnEnable()
    {
        GUIManager.Instance.SetPlayerColor(_toggleGroup);
    }


}