using UnityEngine;
using System.Collections;

public class CharacterChanger : MonoBehaviour {

	public int selectedCharacter = 1;
	public string characterName;
	private GameObject[] characters;

	private void Start()
	{
		characters = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
		{
			characters[i] = transform.GetChild(i).gameObject;
		}
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X)) {
			if (characters[0].activeSelf) {
				characters[1].SetActive (true);
				characters[1].transform.position = characters[0].transform.position;
				characters[0].SetActive (false);
			} 
			if (characters [1].activeSelf) {
				characters [2].SetActive (true);
				characters [2].transform.position = characters [1].transform.position;
				characters [1].SetActive (false);
			} else {
				characters [0].SetActive (true);
				characters [0].transform.position = characters [2].transform.position;
				characters [2].SetActive (false);
			}
		}
	}
}