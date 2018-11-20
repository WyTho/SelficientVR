using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using Task;
using Business.Domain;

namespace Business
{

    public class AreaService : MonoBehaviour
    {
        private const string data = "{ \"area\": [{ \"_id\": \"5bab9d4b61b8c72220acd57d\", \"id\": \"4\", \"areaname\": \"keuken\", \"hardware\": [{ \"id\": \"3\", \"name\": \"Staande_lamp_1\", \"interactions\": [{ \"name\": \"lamp\", \"actions\": [{ \"description\": \"Turn off\", \"code\": \"0\"}, { \"description\": \"Turn on\",	\"code\": \"1\" }],	\"type\": \"component\"}], \"state\": { \"name\": \"lamp\",	\"code\": \"1\"}, \"type\": {\"name\": \"Light\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"test\"}, {\"dataset\": \"\",\"type\": \"\",\"base64\": \"\"}]}, {\"id\": \"4\",	\"name\": \"slide-door\",\"interactions\": [{\"name\": \"deur\",\"actions\": [{	\"description\": \"Open door\",\"code\": \"0\"}, {\"description\": \"Close door\",\"code\": \"1\"}],\"type\": \"animator\"}],\"state\": {\"name\": \"deur\",\"code\": \"0\"},\"type\": {\"name\": \"Door\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"\",\"type\": \"line\",\"base64\": \"\"}]}, {\"id\": \"5\", \"name\": \"VE_Air_Terminal_Wall_Grille_MEPcontent_Trox_SL-DG\", \"interactions\": [{ \"name\": \"dashboard\", \"actions\": [{ \"description\": \"Hide\", \"code\": \"0\"}, {\"description\": \"Show\",\"code\": \"1\"}]}],\"state\": {\"name\": \"dashboard\",\"code\": \"1\"},\"type\": {\"name\": \"Sensor\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"test\"}, {\"dataset\": \"\",\"type\": \"\",\"base64\": \"\"}]}, {\"id\": \"6\",\"name\": \"VK102\",\"interactions\": [{\"name\": \"dashboard\",\"actions\": [{\"description\": \"Hide\",\"code\": \"0\"}, {\"description\": \"Show\",\"code\": \"1\"}]}],\"state\": {\"name\": \"dashboard\",\"code\": \"1\"},\"type\": {\"name\": \"Sensor\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"test\"}, {\"dataset\": \"\",\"type\": \"\",\"base64\": \"\"}]}, {\"id\": \"7\",\"name\": \"Paneli1_vin\",\"interactions\": [{\"name\": \"deur\",\"actions\": [{\"description\": \"Open door\",\"code\": \"0\"}, {\"description\": \"Close door\",\"code\": \"1\"}],\"type\": \"animator\"}],\"state\": {\"name\": \"deur\",\"code\": \"0\"},\"type\": {\"name\": \"Door\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"test\"}, {\"dataset\": \"\",\"type\": \"\",\"base64\": \"\"}]}, {\"id\": \"8\",\"name\": \"Fire_Alarm-Intelligent_Detector-UTC-Multisensor_Detectors\",\"interactions\": [{\"name\": \"dashboard\",\"actions\": [{\"description\": \"Hide\",\"code\": \"0\"}, {\"description\": \"Show\",\"code\": \"1\"}]}],\"state\": {\"name\": \"dashboard\",\"code\": \"1\"},\"type\": {\"name\": \"Sensor\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"test\"}, {\"dataset\": \"\",\"type\": \"\",\"base64\": \"\"}]}, {\"id\": \"9\",\"name\": \"32_binnendeur[7206040]\",\"interactions\": [{\"name\": \"deur\",\"actions\": [{\"description\": \"Open door\",\"code\": \"0\"}, {\"description\": \"Close door\",\"code\": \"1\"}],\"type\": \"animator\"}],\"state\": {\"name\": \"deur\",\"code\": \"0\"},\"type\": {\"name\": \"Door\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"test\"}, {\"dataset\": \"\",\"type\": \"\",\"base64\": \"\"}]}, {\"id\": \"10\",\"name\": \"Lamp_eettafel[4643785]\",\"interactions\": [{\"name\": \"lamp\",\"actions\": [{\"description\": \"Turn off\",\"code\": \"0\"}, {\"description\": \"Turn on\",\"code\": \"1\"}],\"type\": \"component\"}],\"state\": {\"name\": \"lamp\",\"code\": \"1\"},\"type\": {\"name\": \"Light\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"kdjdfksjfkdjkfd\"}]}, {\"id\": \"11\",\"name\": \"Lamp_eettafel[4688990]\",\"interactions\": [{\"name\": \"lamp\",\"actions\": [{\"description\": \"Turn off\",\"code\": \"0\"}, {\"description\": \"Turn on\",\"code\": \"1\"}],\"type\": \"component\"}],\"state\": {\"name\": \"lamp\",\"code\": \"1\"},\"type\": {\"name\": \"Light\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"kdjdfksjfkdjkfd\"}]}, {\"id\": \"12\",\"name\": \"Lamp_eettafel[4689006]\",\"interactions\": [{\"name\": \"lamp\",\"actions\": [{\"description\": \"Turn off\",\"code\": \"0\"}, {\"description\": \"Turn on\",\"code\": \"1\"}],\"type\": \"component\"}],\"state\": {\"name\": \"lamp\",\"code\": \"1\"},\"type\": {\"name\": \"Light\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"kdjdfksjfkdjkfd\"}]}, {\"id\": \"13\",\"name\": \"arwa_cityplus_basin_faucet[4794141]\",\"interactions\": [{\"name\": \"dashboard\",\"actions\": [{\"description\": \"Hide\",\"code\": \"0\"}, {\"description\": \"Show\",\"code\": \"1\"}]}],\"state\": {\"name\": \"dashboard\",\"code\": \"1\"},\"type\": {\"name\": \"Sensor\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"test\"}, {\"dataset\": \"\",\"type\": \"\",\"base64\": \"\"}]}, {\"id\": \"14\",\"name\": \"Fire_Alarm-Intelligent_Detector-UTC-Multisensor_Detectors [4689\",\"interactions\": [{\"name\": \"dashboard\",\"actions\": [{\"description\": \"Hide\",\"code\": \"0\"}, {\"description\": \"Show\",\"code\": \"1\"}]}],\"state\": {\"name\": \"dashboard\",\"code\": \"1\"},\"type\": {\"name\": \"Sensor\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"test\"}, {\"dataset\": \"\",\"type\": \"\",\"base64\": \"\"}]}, {\"id\": \"15\",\"name\": \"Inperla[4679315]\",\"interactions\": [{\"name\": \"lamp\",\"actions\": [{\"description\": \"Turn off\",\"code\": \"0\"}, {\"description\": \"Turn on\",\"code\": \"1\"}]}],\"state\": {\"name\": \"lamp\",\"code\": \"1\"},\"type\": {\"name\": \"Light\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"test\"}, {\"dataset\": \"\",\"type\": \"\",\"base64\": \"\"}]}, {\"id\": \"16\",\"name\": \"32_binnendeur[7202788]\",\"interactions\": [{\"name\": \"deur\",\"actions\": [{\"description\": \"Open door\",\"code\": \"0\"}, {\"description\": \"Close door\",\"code\": \"1\"}],\"type\": \"animator\"}],\"state\": {\"name\": \"deur\",\"code\": \"0\"},\"type\": {\"name\": \"Door\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"\",\"type\": \"line\",\"base64\": \"\"}]}, {\"id\": \"17\",\"name\": \"Wasmachine\",\"interactions\": [{\"name\": \"dashboard\",\"actions\": [{\"description\": \"Hide\",\"code\": \"0\"}, {\"description\": \"Show\",\"code\": \"1\"}]}],\"state\": {\"name\": \"dashboard\",\"code\": \"1\"},\"type\": {\"name\": \"Sensor\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"test\"}, {\"dataset\": \"\",\"type\": \"\",\"base64\": \"\"}]}, {\"id\": \"18\",\"name\": \"Inperla[4679340]\",\"interactions\": [{\"name\": \"lamp\",\"actions\": [{\"description\": \"Turn off\",\"code\": \"0\"}, {\"description\": \"Turn on\",\"code\": \"1\"}],\"type\": \"component\"}],\"state\": {\"name\": \"lamp\",\"code\": \"0\"},\"type\": {\"name\": \"Light\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"kdjdfksjfkdjkfd\"}]}, {\"id\": \"19\",\"name\": \"Inperla[4679360]\",\"interactions\": [{\"name\": \"lamp\",\"actions\": [{\"description\": \"Turn off\",\"code\": \"0\"}, {\"description\": \"Turn on\",\"code\": \"1\"}],\"type\": \"component\"}],\"state\": {\"name\": \"lamp\",\"code\": \"0\"},\"type\": {\"name\": \"Light\"},\"flasi_id\": \"0\",\"log\": [{\"dataset\": \"kdkdkdkdkdkd\",\"type\": \"line\",\"base64\": \"test\"}, {\"dataset\": \"\",\"type\": \"\",\"base64\": \"\"}]}]}]}";

        private UnityAction<System.Object> saveHardwareState;
        private UnityAction<System.Object> loadHardwareDataset;

        [SerializeField] private string uri = data;
        [SerializeField] string stateUri = "";
        [SerializeField] string datasetUri = "https://server.ecliptic.nl/hu/nosi/newdashboard/api/graph";
        [SerializeField] private string areaId; // TODO: De NoSi zo aanpassen dat er per area in geladen kan worden.
        private IDataService serviceImplementation;
        // Use this for initialization


        void Awake()
        {
            saveHardwareState = new UnityAction<System.Object>(SaveHardwareState);
            loadHardwareDataset = new UnityAction<System.Object>(LoadHardwareDataset);
            Debug.LogError("Awake");
        }
        void OnEnable()
        {
            EventManager.StartListening("loadHardwareDataset", LoadHardwareDataset);
            EventManager.StartListening("updateHardwareState", SaveHardwareState);
            Debug.LogError("onEnable");

        }
        void OnDisable()
        {
            EventManager.StopListening("loadHardwareDataset", LoadHardwareDataset);
            EventManager.StopListening("updateHardwareState", SaveHardwareState);
            Debug.LogError("onDisable");

        }
        void Start()
        {
            serviceImplementation = new HardwareService();
            //Debug.LogError(datasetUri);
            StartCoroutine(AreaLoader(uri));
            Debug.LogError("Start");
        }

        #region Hier worden alle data requests afgehandeld.
        private IEnumerator AreaLoader(string uri) // TODO : Hier dus een areaId aan mee geven.
        {
            return this.serviceImplementation.AreaLoader(uri);
        }

        private void SaveHardwareState(System.Object hardwareObject)
        {
            EventManager.TriggerEvent("showInteractiveLoader", true);
            StartCoroutine(this.serviceImplementation.SaveHardwareState(hardwareObject, stateUri));
        }
        #endregion

        private void LoadHardwareDataset(System.Object dataSetId)
        {
            string stringDatasetId = dataSetId as string;
            EventManager.TriggerEvent("showInteractiveLoader", true);
            StartCoroutine(this.serviceImplementation.LoadHardwareDataset(stringDatasetId, datasetUri));
            Debug.LogError("LoadHardwareDataset...");
        }


    }

}
