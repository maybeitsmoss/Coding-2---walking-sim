using UnityEngine;
using System.Collections;

public class squashStretch : MonoBehaviour
{
    //amount of squash! (fraction of original Y scale)
    public float squishAmount;

    IEnumerator SquishCoroutine()
    {
        //wait 0.36 seconds (music is ~163 bpm -> 0.36 seconds per beat)
        yield return new WaitForSeconds(0.365f);

        //Debugging (no bugs only fish)
        //Debug.Log("SquishCoroutine started");

        //store original scale and create squished scale
        Vector3 originalScale = transform.localScale;
        Vector3 squishedScale = transform.localScale;
        squishedScale.y = originalScale.y * squishAmount;

        //squish!
        transform.localScale = squishedScale;
        

        yield return new WaitForSeconds(0.365f);

        //return to original size after another beat
        transform.localScale = originalScale;

        //start over
        StartCoroutine("SquishCoroutine");
    }

    
}
    