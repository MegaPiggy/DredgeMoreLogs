using HarmonyLib;
using System;
using UnityEngine;
using Winch.Core;

namespace DredgeMoreLogs;

[HarmonyPatch]
public static class DredgeMoreLogs
{
	[HarmonyPostfix]
	[HarmonyPatch(typeof(Debug), nameof(Debug.Log), new Type[] { typeof(object) })]
	public static void Debug_Log(object message) => WinchCore.Log.Info($"[UnityEngine.Debug.Log] {message}");

	[HarmonyPostfix]
	[HarmonyPatch(typeof(Debug), nameof(Debug.LogWarning), new Type[] { typeof(object) })]
	public static void Debug_LogWarning(object message) => WinchCore.Log.Warn($"[UnityEngine.Debug.Log] {message}");

	[HarmonyPostfix]
	[HarmonyPatch(typeof(Debug), nameof(Debug.LogError), new Type[] { typeof(object) })]
	public static void Debug_LogError(object message) => WinchCore.Log.Error($"[UnityEngine.Debug.Log] {message}");

	[HarmonyPostfix]
	[HarmonyPatch(typeof(Debug), nameof(Debug.LogException), new Type[] { typeof(Exception) })]
	public static void Debug_LogException(Exception exception) => WinchCore.Log.Error($"[UnityEngine.Debug.Log] {exception}");

	[HarmonyPrefix]
	[HarmonyPatch(typeof(ItemManager), nameof(ItemManager.CreateFishItem))]
	public static void ItemManager_CreateFishItem(ItemManager __instance, string itemId, FishAberrationGenerationMode aberrationGenerationMode, 
		bool isSpecialSpot, FishSizeGenerationMode sizeGenerationMode, float aberrationBonusMultiplier)
	{
		WinchCore.Log.Info($"[ItemManager] Created fish item {itemId} with aberrationGenerationMode: {aberrationGenerationMode}, isSpecialSpot: {isSpecialSpot}, sizeGenerationMode: {sizeGenerationMode}, aberrationBonusMultiplier: {aberrationBonusMultiplier}");
	}
}
