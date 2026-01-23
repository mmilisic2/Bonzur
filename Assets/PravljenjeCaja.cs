using UnityEngine;
using UnityEngine.InputSystem;

public class PravljenjeCaja : MonoBehaviour
{
    public GameObject teaset;
    public Canvas canvas;

    public ParticleSystem[] smokeovi;

    private int brojLatica;
    private InputAction tapAction;

    void Awake()
    {
        tapAction = new InputAction(type: InputActionType.Button, binding: "<Pointer>/press");

        if (teaset != null)
            teaset.SetActive(false);

        if (canvas != null)
            canvas.gameObject.SetActive(false);

        foreach (ParticleSystem s in smokeovi)
        {
            if (s != null)
                s.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        brojLatica = GameObject.FindGameObjectsWithTag("Latica").Length;
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
            if (hit.collider.CompareTag("Latica"))
            {
                hit.collider.gameObject.SetActive(false);
                brojLatica--;

                if (brojLatica <= 0)
                {
                    if (teaset != null)
                        teaset.SetActive(true);

                        if (canvas != null)
                        canvas.gameObject.SetActive(true);
                        
                    foreach (ParticleSystem s in smokeovi)
                    {
                        if (s == null) continue;

                        s.gameObject.SetActive(true);
                        s.Clear();
                        s.Play();
                    }
                }
            }
        }
    }
}
