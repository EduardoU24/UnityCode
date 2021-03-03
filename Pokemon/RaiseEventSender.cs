using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public sealed class RaiseEventSender : MonoBehaviour
{
    public static RaiseEventSender x;
    public byte SyncTeamEventCode { get; } = 1;

    private void Awake()
    {
        if (x == null) x = this;
        else Destroy(gameObject);
    }

    public void Start()
    {
        CallSyncTeamEvent();
    }

    private void CallSyncTeamEvent ()
    {
        RaiseEventOptions raiseOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        string[] strings = new string[PlayerProfile.x.ActiveTeam.Count];
        for (int i = 0; i < PlayerProfile.x.ActiveTeam.Count; i++)
        {
            strings[i] = PlayerProfile.x.ActiveTeam[i].pokemonName;
        }
        object content = strings;
        PhotonNetwork.RaiseEvent(SyncTeamEventCode, content, raiseOptions, SendOptions.SendReliable);
    }

}
