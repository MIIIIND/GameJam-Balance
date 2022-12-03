using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform pfFireball;

    void Start()
    {
        GetComponent<Aim>().OnShoot += ShootProjectiles_OnShoot;
    }

    private void ShootProjectiles_OnShoot(object sender, Aim.OnShootEventArgs e)
    {
        Transform fireballTransform = Instantiate(pfFireball,e.tracker,Quaternion.identity);

        Vector3 shootDir = (e.shootPosition - e.tracker).normalized;
        fireballTransform .GetComponent<fireball>().Setup(shootDir,e.angle);
    }
}
