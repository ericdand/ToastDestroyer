using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastBehaviour : MonoBehaviour
{
	private Vector2? knifeStartPos;

    // Update is called once per frame
    void Update()
    {

    }

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log("trigger enter");
		if (coll.gameObject.tag != "knife") return;
		knifeStartPos = coll.transform.position;
		Debug.Log("knife entered");
	}

	void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.tag != "knife") return;
		if (!knifeStartPos.HasValue) return; // We've already finished a stroke.
		var contactPoint = coll.transform.position;
		var stroke = new Vector2(
				contactPoint.x - knifeStartPos.Value.x,
				contactPoint.y - knifeStartPos.Value.y);
		
		// Did stroke cross most of the toast in a down-right direction?
		if (stroke.magnitude > 4f && 
				stroke.normalized.x > 0 && stroke.normalized.y < 0) {
			// TODO redefine magnitude threshold in terms of the size of the toast hitbox.
			Debug.Log("stroke");
			knifeStartPos = null; // This stroke is complete.
			// TODO: play scrape noise, apply damage to toast.
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		Debug.Log("trigger exit");
	}
}
