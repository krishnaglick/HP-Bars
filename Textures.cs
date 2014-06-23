using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Textures
{
	private Dictionary<string, Texture2D> Colors = new Dictionary<string, Texture2D>();

	public Textures()
	{
		//Need a 1px by 1px png or bmp w/ the matching name, located in Assets/Resources
		Colors.Add("black", (Texture2D) Resources.Load("Texture_Black", typeof(Texture2D)));
		Colors.Add("green", (Texture2D) Resources.Load("Texture_Green", typeof(Texture2D)));
		Colors.Add("red", (Texture2D) Resources.Load("Texture_Red", typeof(Texture2D)));
		Colors.Add("orange", (Texture2D) Resources.Load("Texture_Orange", typeof(Texture2D)));
		Colors.Add("yellow", (Texture2D) Resources.Load("Texture_Yellow", typeof(Texture2D)));
	}

	public Texture2D GetColor(string color)
	{
		//Returns the color you're looking for
		return Colors[color.ToLower()];
	}
}
