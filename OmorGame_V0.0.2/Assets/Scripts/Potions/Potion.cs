using UnityEngine;

public class Potion : MonoBehaviour
{
    public Element element;
    public virtual void Drink()
    {

    }

    public enum Element
    {
       elementA = 0,
       elementB = 1,
       elementC = 2,
       elementD = 3
    }
}
