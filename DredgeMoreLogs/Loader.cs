using HarmonyLib;
using UnityEngine;
using Winch.Core;

namespace DredgeMoreLogs
{
	public class Loader
	{
		/// <summary>
		/// This method is run by Winch to initialize your mod
		/// </summary>
		public static void Initialize()
		{
			WinchCore.Log.Debug($"{nameof(DredgeMoreLogs)} has loaded!");
			new Harmony(nameof(DredgeMoreLogs)).PatchAll();
		}
	}
}