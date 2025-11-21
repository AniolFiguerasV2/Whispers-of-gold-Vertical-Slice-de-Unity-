using UnityEngine;

public class Chest : MonoBehaviour
{
    public Vector3 changeMove = new Vector3(0, 0.1f, 0);
    public Vector3 changeRotation = new Vector3(0, 0, 7.5f);

    public int maxMoves = 10;
    private int moveCount = 0;

    private bool canPickUp = false;
    private bool isPickedUp = false;

    public void MoveChest()
    {
        if (moveCount < maxMoves)
        {
            transform.position += changeMove;
            transform.Rotate(changeRotation);
            moveCount++;

            if (moveCount >= maxMoves)
            {
                canPickUp = true;
            }
        }
    }

    public void PickUp(Transform chestHolder)
    {
        if (canPickUp && !isPickedUp)
        {
                transform.SetParent(chestHolder);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;

                Collider col = GetComponent<Collider>();
                col.enabled = false;

                isPickedUp = true;
        }
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }
}
