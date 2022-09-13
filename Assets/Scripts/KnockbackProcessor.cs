using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;

public class KnockbackProcessor : MonoBehaviour
{
    public float power;
    Vector3 knockback = Vector3.zero;
    private CharacterController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockback.magnitude > 0.2F) 
            player.Move(knockback * Time.deltaTime);
        knockback = Vector3.Lerp(knockback, Vector3.zero, 5 * Time.deltaTime);
    }

    public void addKnockback(Vector3 direction)
    {
        direction.Normalize();
        if (direction.y < 0) direction.y = -direction.y;
        knockback += direction * -power;
        Debug.Log(knockback);
    }
}
