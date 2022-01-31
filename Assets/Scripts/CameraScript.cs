using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    public static CameraScript Instance { get; private set; }
    CinemachineImpulseSource impulsCam;

    void Awake()
    {
        Instance = this;
        impulsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineImpulseSource>();
    }

    public void ShakeCam(float SustainTime, float DecayTime, float AmplitudGain)
    {
        impulsCam.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = SustainTime;
        impulsCam.m_ImpulseDefinition.m_TimeEnvelope.m_DecayTime = DecayTime;
        impulsCam.m_ImpulseDefinition.m_AmplitudeGain = AmplitudGain;
        impulsCam.GenerateImpulse();
    }
}
