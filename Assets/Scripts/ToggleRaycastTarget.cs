using UnityEngine;
using UnityEngine.UI;

public class ToggleRaycastTarget : MonoBehaviour
{
    [SerializeField]
    private Graphic target;

    private bool isRaycastingEnable;

    private void Awake()
    {
        isRaycastingEnable = target.raycastTarget;
    }

    public void ToggleRaycastingEnable()
    {
        isRaycastingEnable = !isRaycastingEnable;
        target.raycastTarget = isRaycastingEnable;
    }
}
