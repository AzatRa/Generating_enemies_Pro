using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void Change(Enemy enemy, Color color)
    {
        enemy.Renderer.material.color = color;
    }
}
