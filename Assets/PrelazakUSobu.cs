using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PrelazakUSobu : MonoBehaviour
{
    public Camera arCamera;
    private InputAction tapAction;

    void Awake()
    {
        tapAction = new InputAction(type: InputActionType.Button, binding: "<Pointer>/press");
    }

    void OnEnable() => tapAction.Enable();
    void OnDisable() => tapAction.Disable();

    void Update()
    {
        if (tapAction.WasPerformedThisFrame())
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        Vector2 screenPos = Pointer.current.position.ReadValue();
        Ray ray = arCamera.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.CompareTag("Portal"))
            {
                SceneManager.LoadScene("UnutraSobaPainting");
            }
        }
    }
}