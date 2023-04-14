using UnityEngine;

public class GenericsShowcase : MonoBehaviour
{
    
    private int[] intArr = { 1, 2, 3 };
    private float[] floatArr = { 1.1f, 2.2f, 3.3f };
    private string[] strArr = { "Aa", "Bb", "Cc" };

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            DisplayElementsMeh(intArr);
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            DisplayElementsAight(intArr);
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            DisplayElementsAight(floatArr);
        }
        if (Input.GetKeyDown(KeyCode.V)) {
            DisplayElementsAight(strArr);
        }
    }

    public void DisplayElementsMeh(int[] arr) {
        foreach (int item in arr) {
            print(item);
        }
    }

    public void DisplayElementsAight<Thingomabob>(Thingomabob[] arr) {
        foreach (Thingomabob thing in arr) {
            print(thing);
        }
    }
}
