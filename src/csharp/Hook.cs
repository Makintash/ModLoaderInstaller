﻿using System;
using System.Reflection;
using System.IO;
using UnityEngine;

// Remember to add a reference to UnityEngine.CoreModule.dll

namespace Rewired
{
	public class InputManager_Base
	{
		public static void Awake()
		{
			// COPY START
			try
			{
				string managedPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				Debug.Log("Loading Harmony...");
				Assembly harmonyAssembly = Assembly.LoadFrom(Path.Combine(managedPath, "Harmony.dll"));
				Debug.Log("Loading mod loader...");
				Assembly modLoaderAssembly = Assembly.LoadFrom(Path.Combine(managedPath, "ModLoader.dll"));
				Type modLoaderType = modLoaderAssembly.GetType("ModLoader.ModLoader", true);
				MethodInfo startMethod = modLoaderType.GetMethod("Start", new Type[0]);
				startMethod.Invoke(null, new object[0]);
			}
			catch (Exception e)
			{
				Debug.LogError("Could not start mod loader!");
				Debug.LogException(e);
			}
			// COPY END
			this.Initialize();
		}
	}
}
