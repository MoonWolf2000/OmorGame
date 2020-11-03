using UnityEngine;

public class Potion : MonoBehaviour
{
    public Element element;
    public string ID;
    public Recipe[] Recipe;
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
