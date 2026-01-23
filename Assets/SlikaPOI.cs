using UnityEngine;
using UnityEngine.InputSystem;

public class SlikaPOI : MonoBehaviour
{
    public GameObject textPlane;
    private InputAction tapAction;

    void Awake()
    {
        tapAction = new InputAction(type: InputActionType.Button, binding: "<Pointer>/press");
        if (textPlane != null) textPlane.SetActive(false);
    }

    void OnEnable()
    {
        tapAction.Enable();
        tapAction.performed += OnTap;
    }

    void OnDisable()
    {
        tapAction.performed -= OnTap;
        tapAction.Disable();
    }

    private void OnTap(InputAction.CallbackContext ctx)
    {
        if (Camera.main == null) return;

        Vector2 pos = Pointer.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Kosara"))
            {
                textPlane.SetActive(!textPlane.activeSelf);
            }
            else
            {
                if (textPlane.activeSelf) textPlane.SetActive(false);
            }
        }
        else
        {
            if (textPlane.activeSelf) textPlane.SetActive(false);
        }
    }
}