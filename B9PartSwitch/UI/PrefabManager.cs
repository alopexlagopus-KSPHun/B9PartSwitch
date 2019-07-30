﻿using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace B9PartSwitch.UI
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class PrefabManagerInstant : MonoBehaviour
    {
        [SuppressMessage("Code Quality", "IDE0051", Justification = "Called by Unity")]
        private void Awake()
        {
            Debug.Log("[B9PartSwitch.UI.PrefabManagerInstant] awake");

            try
            {
                TooltipHelper.EnsurePrefabs();
            }
            catch (Exception ex)
            {
                FatalErrorHandler.HandleFatalError(ex);
                Debug.LogException(ex);
            }

            Destroy(gameObject);
        }

    }

    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class PrefabManagerEditor : MonoBehaviour
    {
        [SuppressMessage("Code Quality", "IDE0051", Justification = "Called by Unity")]
        private void Start()
        {
            Debug.Log("[B9PartSwitch.UI.PrefabManagerEditor] start");

            if (HighLogic.LoadedSceneIsEditor || HighLogic.LoadedSceneIsFlight)
            {
                try
                {
                    UIPartActionSubtypeSelector.EnsurePrefab();
                }
                catch (Exception ex)
                {
                    FatalErrorHandler.HandleFatalError(ex);
                    Debug.LogException(ex);
                }
            }

            Destroy(gameObject);
        }
    }
}
