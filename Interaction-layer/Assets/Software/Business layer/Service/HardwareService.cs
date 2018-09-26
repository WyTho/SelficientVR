﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Task;
using Business.Domain;
using System.Text.RegularExpressions;
using UnityEngine.Events;
using System.IO;
using System;

namespace Business {
	public class HardwareService : IDataService {



		public IEnumerator AreaLoader(string uri)
		{
            string pattern = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
            string newUri = Regex.Replace(uri, pattern, "172.20.10.13");
            newUri = newUri.Replace("3001", "6002");
			UnityWebRequest www = UnityWebRequest.Get (newUri);

            yield return www.SendWebRequest();
            Debug.LogError(newUri);


            if (www.isNetworkError || www.isHttpError) {
				EventManager.TriggerEvent ("loading", false);
				Debug.Log ("Error loading objects");
			}
			else {
                Area[] areas = JsonHelper.FromJson<Area>(www.downloadHandler.text);
              //  Hardware[] hardware = areas[0].hardwareList;
				Debug.Log (www.downloadHandler.text);
               /* foreach (Area area in areas)
                {
                    foreach(Hardware hardware in area.hardware)
                    {
                        Debug.Log(hardware);
                    }
                }*/
			//	Area area = new Area () { name = "LivingRoom", x = 25, y = 25, z = 10, hardware = hardware };
			
				EventManager.TriggerEvent ("triggerHardwareBuild", areas[0] as System.Object);
				EventManager.TriggerEvent ("loading", true);
			}
		}

		public IEnumerator SaveHardwareState (System.Object hardwareObject, string uri)
		{
			KeyValuePair<Interaction, Hardware> keyvalue = (KeyValuePair<Interaction, Hardware>) hardwareObject;
			WWWForm form = new WWWForm ();
			form.AddField ("name", keyvalue.Value.name);
			form.AddField ("interaction", keyvalue.Key.name);
			form.AddField ("state", keyvalue.Value.state.code);
			UnityWebRequest www = UnityWebRequest.Post (uri, form);
			yield return www.SendWebRequest();
			if (www.isNetworkError || www.isHttpError) {
				EventManager.TriggerEvent ("showInteractiveLoader", false);
				Debug.Log(www.downloadHandler.text);
			} else {
				EventManager.TriggerEvent ("showInteractiveLoader", false);
				Debug.Log (www.downloadHandler.text);
			}
		}

		public IEnumerator LoadHardwareDataset (string datasetId, string uri)
		{
			UnityWebRequest www = UnityWebRequest.Get (uri+"/"+datasetId);
			//yield return www.SendWebRequest ();
			//if (www.isNetworkError || www.isHttpError) {
			//	EventManager.TriggerEvent ("showInteractiveLoader", false);
			//} else {
			yield return new WaitForSeconds(2); // simuleer 2 seconden wachttijd
			Debug.Log ("Load dataset in voor dashboard");
            Debug.Log(datasetId);
			EventManager.TriggerEvent ("showInteractiveLoader", false);
			EventManager.TriggerEvent ("datasetLoaded-"+datasetId, null);


		}
	}

}
