using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class falling_floor_controller: MonoBehaviour
{
    public List<BlockSnapshot> BlockSnapshots;
    public new Rigidbody2D rigidbody;
    private bool isRewinding = false;

    void Update()
    {
        if (isRewinding)
        {
            return;
        }
        
        BlockSnapshots.Add(new BlockSnapshot()
        {
            position = transform.position,
            velocity = rigidbody.linearVelocity
        });
    }
    
    public void Do()
    {
        if (isRewinding)
        {
            return;
        }
        StartCoroutine(RewindCoroutine());
    }

    public IEnumerator RewindCoroutine()
    {
        rigidbody.simulated = false;
        isRewinding = true;

        for (int i = BlockSnapshots.Count - 1; i >= 0; i--)
        {
            rigidbody.linearVelocity = BlockSnapshots[i].velocity;
            transform.position = BlockSnapshots[i].position;
            yield return null;
        }
        
        rigidbody.simulated = true;
        isRewinding = false;
        BlockSnapshots.Clear();
    }
    
}

[System.Serializable]
public class BlockSnapshot
{
    public Vector2 position;
    public Vector2 velocity;
}