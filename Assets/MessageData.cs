﻿using System;
using UnityEngine;

[System.Serializable]
public class MessageData
{
	public string _id;
	public Location location;
	public float altitude;
	public string text;
	public BoneTransform[][] animation;
	public int points;

	public override string ToString()
	{
		//Debug.Log(animation.Length);
		return $"{location.coordinates[0]},{location.coordinates[1]},{altitude}: {text} ({points} points).";
	}
}

[System.Serializable]
public class BoneTransform
{
	public float[] rotation;
	public float[] position;

	private Vector3? _vectorPosition = null;
	private Quaternion? _quaternionRotation = null;

	public Quaternion Rotation
	{
		get
		{
			if (_quaternionRotation == null)
			{
				_quaternionRotation = new Quaternion(rotation[0], rotation[1], rotation[2], rotation[3]);
			}
			return _quaternionRotation.Value;
		}
	}

	public string ToJson()
	{
		string json = "{";
		json += $"\"rotation\": [{rotation[0]},{rotation[1]},{rotation[2]},{rotation[3]}]";
		json += ",";
		json += $"\"position\": [{position[0]},{position[1]},{position[2]}]";
		json += "}";
		return json;
	}

	public Vector3 Position
	{
		get
		{
			if (_vectorPosition == null)
			{
				_vectorPosition = new Vector3(position[0], position[1], position[2]);
			}
			return _vectorPosition.Value;
		}
	}
}

[System.Serializable]
public class Location
{
	public float[] coordinates;
}