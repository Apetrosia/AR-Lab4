using UnityEngine;
using UnityEngine.InputSystem;

public class TapInteraction : MonoBehaviour
{
    void Update()
    {
        var screen = Touchscreen.current;
        if (screen == null || !screen.primaryTouch.press.wasPressedThisFrame) return;

        Vector2 pos = screen.primaryTouch.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(pos);

        if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform.IsChildOf(transform))
            OnTapped();
    }

    void OnTapped()
    {
        transform.Rotate(0f, 45f, 0f);
        foreach (var r in GetComponentsInChildren<Renderer>())
            r.material.color = Random.ColorHSV(0f, 1f, 0.6f, 1f, 0.8f, 1f);
    }
}