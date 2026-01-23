using UnityEngine;
using UnityEngine.InputSystem;

public class KlikNaSliku : MonoBehaviour
{
    public GameObject infoCanvas;
    private InputAction tapAction;
    void Awake()
    {
        tapAction = new InputAction(type: InputActionType.Button, binding: "<Pointer>/press");
        if (infoCanvas != null)
            infoCanvas.SetActive(false);
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
            if (hit.collider.CompareTag("Slika"))
            {
                if (infoCanvas != null)
                {
                    infoCanvas.SetActive(true);
                }
            }
        }
    }
    public void Zatvori(){
        if (infoCanvas!= null)
        {
            infoCanvas.SetActive(false);
        }
    }
}
