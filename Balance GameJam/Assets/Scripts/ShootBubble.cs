using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBubble : MonoBehaviour
{
    [SerializeField] private Transform pfBubble;

    void Start()
    {
        GetComponent<Aim>().OnShootBubble += ShootProjectiles_OnShootBubble;
    }

    private void ShootProjectiles_OnShootBubble(object sender, Aim.OnShootBubbleEventArgs e)
    {
        Transform bubbleTransform = Instantiate(pfBubble,e.tracker,Quaternion.identity);

        Vector3 shootDir = (e.shootPosition - e.tracker).normalized;
        bubbleTransform .GetComponent<bubble>().Setup(shootDir,e.angle);
    }
}
