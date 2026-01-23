using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class KlikNaCovjeka : MonoBehaviour
{
    private InputAction tapAction;
    void Awake()
    {
        tapAction = new InputAction(type: InputActionType.Button, binding: "<Pointer>/press");
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
            if (hit.collider.CompareTag("Covjek"))
            {
                SceneManager.LoadScene("MiniGameMemory");
            }
        }
    }
}
