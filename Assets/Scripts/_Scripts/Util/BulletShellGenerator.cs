using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletShellGenerator : ObjectPool
{
    [SerializeField]
    private float flyDuration = 0.3f;

    [SerializeField]
    private float flyStength = 1;

    public void SpawnBulletShell()
    {
        var shell = SpawnObject();
        if (shell.activeSelf == false)
        {
            shell.SetActive(true);
        }
        MoveShellInRandomDirection(shell);
    }

    private void MoveShellInRandomDirection(GameObject shell)
    {
        shell.transform.DOComplete();
        Vector2 randomDirection = Random.insideUnitCircle;
        randomDirection = randomDirection.y > 0 ? new Vector2(randomDirection.x, -randomDirection.y) : randomDirection;
        shell.transform.DOMove((Vector2)transform.position + randomDirection * flyStength, flyDuration).OnComplete(()
            => shell.GetComponent<AudioSource>().Play());
        shell.transform.DORotate(new Vector3(0, 0, Random.Range(0, 360)), flyDuration);
    }
}
