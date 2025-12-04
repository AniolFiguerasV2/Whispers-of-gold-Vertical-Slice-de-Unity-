using UnityEngine;

public class MonstersSpawn : MonoBehaviour
{
    public GameObject monsterPrefab;   // El monstruo que spawneará
    public Transform spawnPoint;       // Donde aparece
    public float activeTime = 10f;     // Tiempo que dura activo

    private GameObject currentMonster;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentMonster == null)
            {
                SpawnMonster();
            }
        }
    }

    private void SpawnMonster()
    {
        currentMonster = Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
        Invoke(nameof(HideMonster), activeTime);
    }

    private void HideMonster()
    {
        if (currentMonster != null)
        {
            Destroy(currentMonster);
            currentMonster = null;
        }
    }
}
