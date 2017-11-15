using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class go : MonoBehaviour {
	
	public GameObject goal;
	public AudioSource don;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 goalpos = goal.transform.position;

		Vector3 m_pos = transform.localPosition;
		float dis = Vector3.Distance(goalpos,m_pos);
		Debug.Log (dis);
		if (dis < 11) {
			SceneManager.LoadScene("goal");
		}

		m_pos.x += 2.6f*Time.deltaTime;
		transform.localPosition = m_pos; 
		float mouse_x = Input.mousePosition.x-(Screen.width/2);
//		if (mouse_x>0 && m_pos.z>1) {
//			//iTween.MoveTo(gameObject, iTween.Hash ("z", gameObject.transform.position.z-1, "time", 1));
//			m_pos.z -= 1.2f*Time.deltaTime;
//			transform.localPosition = m_pos; 
//		}
//		if (mouse_x<0&& m_pos.z<5.0) {
//			//iTween.MoveTo(gameObject, iTween.Hash ("z", gameObject.transform.position.z+1, "time", 1));
//			m_pos.z += 1.2f*Time.deltaTime;
//			transform.localPosition = m_pos;
//		}

		if (m_pos.z > -2 && m_pos.z < 2) {
			//iTween.MoveTo(gameObject, iTween.Hash ("z", gameObject.transform.position.z+1, "time", 1));
			m_pos.z = -(mouse_x / 180);
			transform.localPosition = m_pos;
		} else if(m_pos.z<=-2){
			m_pos.z = -1.8f;
			transform.localPosition = m_pos;
			}
	     else if(m_pos.z>=2){
		    m_pos.z = 1.8f;
		transform.localPosition = m_pos;
	}

		Debug.Log (mouse_x/200);
	}

	void OnCollisionEnter(Collision collision){
		
		if (collision.gameObject.tag == "Finish") {
			don.Play ();
			iTween.MoveTo(gameObject, iTween.Hash ("x", -26, "time", 1));
		}
	}
}
