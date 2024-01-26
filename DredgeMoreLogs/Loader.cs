using UnityEngine;

namespace DredgeMoreLogs
{
	public class Loader
	{
		/// <summary>
		/// This method is run by Winch to initialize your mod
		/// </summary>
		public static void Initialize()
		{
			var gameObject = new GameObject(nameof(DredgeMoreLogs));
			gameObject.AddComponent<DredgeMoreLogs>();
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}