using UnityEngine;
using System.Collections;

public class CharacterChanger : MonoBehaviour {

	public int selectedCharacter = 1;
	public string characterName;
	private GameObject[] characters;
	private int activeChar;
	private int characterNum;

	private void Start()
	{
		characterNum = 0;
		activeChar = 0;

		// Create and store all of the animal character objects in an array
		characters = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
		{
			characters[i] = transform.GetChild(i).gameObject;
			characterNum++;
		}

	}
		
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.X)) {

			// Cycle through the character index, or reset if reached the max.
			if (activeChar < (characterNum - 1)) {
				activeChar++;
			} else {
				activeChar = 0;
			}

			// If the character is active, deactivate and activate the next 
			// object in the array and set it's position. 
			for (int j = 0; j < (characterNum); j++) 
			{
				if (characters[j].activeSelf) {
					characters[activeChar].SetActive (true);
					characters[activeChar].transform.position = characters[j].transform.position;
					characters[j].SetActive (false);
					j++;
				}
			}
		}
	}
}