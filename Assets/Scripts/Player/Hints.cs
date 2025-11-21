using UnityEngine;
using UnityEngine.InputSystem;

public class Hints : MonoBehaviour
{
    private PlayerInputs inputAction;
    public bool isEquipped;
    public Chest chest;
    private void Awake()
    {
        inputAction = new PlayerInputs();
        inputAction.Player.Hint.performed += ctx => ToggleHintMap();
    }

    private void Start()
    {
        inputAction.Player.Enable();
    }

    public void ToggleHintMap()
    {
        if (!chest.IsPickedUp())
        {
            isEquipped = !isEquipped;
            gameObject.SetActive(isEquipped);
        }
        if (chest.IsPickedUp())
        {
            gameObject.SetActive(false);
        }
    }
}
