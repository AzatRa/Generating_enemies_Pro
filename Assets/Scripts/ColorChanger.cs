using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void Change(Enemy enemy)
    {
        enemy.Renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
