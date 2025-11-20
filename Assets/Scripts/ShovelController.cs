using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpObjectController : MonoBehaviour
{
    public float PickUpCheckDistance = 2f;
    public LayerMask Pickup;
    private Camera playerCamera;

    private PlayerInputs inputAction;
    public bool isEquipped;

    public Transform chestHolder;

    private void Awake()
    {
        inputAction = new PlayerInputs();
        inputAction.Player.EquipShovel.performed += ctx => ToggleShovel();
        inputAction.Player.Use.performed += ctx => {
            if (isEquipped)
            {
                InteractObjects();
            }
        };
        inputAction.Player.PickUp.performed += ctx => TryPickUpChest();
    }

    private void Start()
    {
        inputAction.Player.Enable();
        playerCamera = Camera.main;
        gameObject.SetActive(isEquipped);
    }

    private void ToggleShovel()
    {
        isEquipped = !isEquipped;
        gameObject.SetActive(isEquipped);
    }

    private void InteractObjects()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, PickUpCheckDistance, Pickup))
        {
            Chest chest = hit.collider.GetComponent<Chest>();

            chest.MoveChest();
        }
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * PickUpCheckDistance, Color.red, 0.1f);
    }

    private void TryPickUpChest()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f,0.5f, 0f));
        if(Physics.Raycast(ray,out RaycastHit hit, PickUpCheckDistance, Pickup))
        {
            Chest chest = hit.collider.GetComponent<Chest>();
            
            chest.PickUp(chestHolder);

            if (chest.IsPickedUp())
            {
                isEquipped = false;
                gameObject.SetActive(false);

                inputAction.Player.EquipShovel.Disable();
            }
        }
    }
}