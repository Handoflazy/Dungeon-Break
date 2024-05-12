using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropable : MonoBehaviour
{
    public void DropItem()
    {
        NguyenSingleton.Instance.FloatingTextManager.Show("Chua biet viet gi nhung cu khen nguyen dep trai cai da!!", 20, Color.green, transform.position, Vector3.up, 3);
    }
}
