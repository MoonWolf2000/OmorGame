using System.Linq;
using UnityEngine;

public static class OriantalionHelper
{
    public static Vector2[] directions = new Vector2[]
   {

       Vector2.up,
       Vector2.down,
       Vector2.right,
       Vector2.left,

   };
    public static Quaternion GiveOriantation(Vector2 input)
    {
        switch (directions.OrderBy(d => (input - d).magnitude).First())
        {
            case Vector2 d when d.Equals(directions[0]):
                return Quaternion.Euler(0f, 0f, 0f);
            case Vector2 d when d.Equals(directions[1]):

                return Quaternion.Euler(0f, 0f, 180f);

            case Vector2 d when d.Equals(directions[2]):

                return Quaternion.Euler(0f, 0f, 270f);

            case Vector2 d when d.Equals(directions[3]):
                return Quaternion.Euler(0f, 0f, 90f);
            default:
                return Quaternion.Euler(0f, 0f, 0f);

        }

    }


    public static void RotationToNWES(this Rigidbody2D rb,Vector2 input)
    {
        rb.transform.rotation = GiveOriantation(input);
    }
    public static void RotationToNWES(this Transform t,Vector2 input)
    {
        t.rotation = GiveOriantation(input);
    }


    public static void AssignOrientation(this Transform t,Vector2 v)
    {
        if (v == Vector2.zero) return; 
        t.rotation = GiveOriantation(v);
    }


    public static void LimitDirectionToNWES(this ref Vector2 direction)
    {
        var    temp = direction;
        direction = directions.OrderBy(d => (temp - d).magnitude).First();
    }
}
