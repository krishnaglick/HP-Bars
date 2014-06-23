using UnityEngine;
using System.Collections;

public class HPBars : MonoBehaviour {

	//The Gameobject to appear above
	private GameObject target;

	//Foreground color, aka the health color
	private Texture2D Foreground;
	//Background color, aka what you see when you've lost hp
	private Texture2D Background;

	//The mob's max hp
	private float MaxHP;
	//The mob's current hp
	private float CurrentHP;

	//This creates a new instance of my color class
	private Textures Colors = new Textures();

	public void updateHP(float HP, bool addHP)
	{
		//This is called in the attachee's control script
		//HP is amount to add/subtract, addHP being true adds, otherwise subtracts
		if(addHP)
			CurrentHP += HP;
		else
			CurrentHP -= HP;

		//Destroy the enemy if their hp drops below 0
		if(CurrentHP <= 0)
			Destroy(target);

		//This controls hp bar colors
		if(CurrentHP / MaxHP > .5)
			Foreground = Colors.GetColor("green");
		if (CurrentHP / MaxHP <= .5)
			Foreground = Colors.GetColor("yellow");
		if (CurrentHP / MaxHP <= .25)
			Foreground = Colors.GetColor("orange");
		if (CurrentHP / MaxHP <= .15)
			Foreground = Colors.GetColor("red");
	}

	public void Init(GameObject go, float HP)
	{
		//Set max hp to passed in value
		MaxHP = HP;
		//Setting target to go to keep track of the attachee
		target = go;
		//Sets the current hp to max hp, at spawn the mob should be max hp
		CurrentHP = MaxHP;
		//Sets the default foreground and background colors
		Foreground = Colors.GetColor("green");
		Background = Colors.GetColor("black");
	}

	void OnGUI()
	{
		//This keeps track of the mob relative to the screen
		Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
		//Gets the x position of the mob and centers the hp bar
		float xPosition = screenPos.x - (MaxHP / 2);
		//Gets the mob's y position relative to the screen with an offset that won't screw up on multiple screen sizes
		float yPosition = Camera.main.pixelHeight - screenPos.y - (Camera.main.pixelHeight / 8);
		//Scales the bar's height based on the size of the enemy
		float barHeight = target.renderer.bounds.size.y * 6;
		//Draws the hp and background bars
		GUI.DrawTexture(new Rect(xPosition, yPosition, MaxHP, barHeight), Background);
		GUI.DrawTexture(new Rect(xPosition, yPosition, CurrentHP, barHeight), Foreground);
	}
}