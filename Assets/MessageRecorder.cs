﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageRecorder : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField _inputField;

	public static MessageRecorder Instance;

	public MessageData CurrentMessage;

	private void Awake()
	{
		Instance = this;
	}

	public void Show()
	{
		CurrentMessage = new MessageData();
		CurrentMessage.location = new Location
		{
			coordinates = new float[] { GeoLocation.Latitude, GeoLocation.Longitude }
		};
		CurrentMessage.altitude = GeoLocation.Altitude;
	}

	public void SubmitText()
	{
		CurrentMessage.text = _inputField.text;
	}

	public void Send()
	{
		SubmitText();

		print("Sending message");
		MessageService.SaveMessage(CurrentMessage);
		print("Message sent");
	}
}