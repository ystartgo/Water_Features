﻿// <copyright file="WaterFeaturesMod.cs" company="Yenyang's Mods. MIT License">
// Copyright (c) Yenyang's Mods. MIT License. All rights reserved.
// </copyright>

namespace Water_Features
{
    using System;
    using System.IO;
    using Better_Bulldozer.Localization;
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Water_Features.Settings;
    using Water_Features.Systems;
    using Water_Features.Tools;

    /// <summary>
    ///  A mod that adds Water Tool, Seasonal Streams, and Experimetnal Waves and Tides.
    /// </summary>
    public class WaterFeaturesMod : IMod
    {
        /// <summary>
        /// Gets the install folder for the mod.
        /// </summary>
        private static string m_modInstallFolder;

        /// <summary>
        /// Gets the static reference to the mod instance.
        /// </summary>
        public static WaterFeaturesMod Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the Install Folder for the mod as a string.
        /// </summary>
        public static string ModInstallFolder
        {
            get
            {
                if (m_modInstallFolder is null)
                {
                    var thisFullName = Instance.GetType().Assembly.FullName;
                    ExecutableAsset thisInfo = AssetDatabase.global.GetAsset(SearchFilter<ExecutableAsset>.ByCondition(x => x.definition?.FullName == thisFullName)) ?? throw new Exception("This mod info was not found!!!!");
                    m_modInstallFolder = Path.GetDirectoryName(thisInfo.GetMeta().path);
                }

                return m_modInstallFolder;
            }
        }

        /// <summary>
        /// Gets the log for the mod.
        /// </summary>
        internal ILog Log { get; private set; }

        /// <summary>
        /// Gets or sets the Settings for the mod.
        /// </summary>
        internal WaterFeaturesSettings Settings { get; set; }

        /// <inheritdoc/>
        public void OnLoad(UpdateSystem updateSystem)
        {
            Instance = this;
            Log = LogManager.GetLogger("Mods_Yenyang_Water_Features").SetShowsErrorsInUI(false);
            Log.Info($"[{nameof(WaterFeaturesMod)}] {nameof(OnLoad)}");
#if DEBUG
            Log.effectivenessLevel = Level.Debug;
#elif VERBOSE
            Log.effectivenessLevel = Level.Verbose;
#else
            Log.effectivenessLevel = Level.Info;
#endif
            Log.Info($"{nameof(WaterFeaturesMod)}.{nameof(OnLoad)} Initializing settings");
            Settings = new (this);
            Log.Info($"{nameof(WaterFeaturesMod)}.{nameof(OnLoad)} Loading localization");
            Localization.LoadTranslations(Settings, Log);
            Log.Info($"{nameof(WaterFeaturesMod)}.{nameof(OnLoad)} Registering settings");
            Settings.RegisterInOptionsUI();
            Log.Info($"{nameof(WaterFeaturesMod)}.{nameof(OnLoad)} Loading settings");
            AssetDatabase.global.LoadSettings("Mods_Yenyang_Water_Features", Settings, new WaterFeaturesSettings(this));
            Settings.Contra = false;
            Log.Info("Handling create world");
            Log.Info("ModInstallFolder = " + ModInstallFolder);
            Log.Info($"{nameof(WaterFeaturesMod)}.{nameof(OnLoad)} Injecting systems.");
            updateSystem.UpdateAt<CustomWaterToolSystem>(SystemUpdatePhase.ToolUpdate);
            updateSystem.UpdateAfter<WaterTooltipSystem>(SystemUpdatePhase.UITooltip);
            updateSystem.UpdateBefore<FindWaterSourcesSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAt<AutofillingLakesSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAt<DetentionBasinSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAt<RetentionBasinSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateBefore<ChangeWaterSystemValues>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAt<TidesAndWavesSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateBefore<BeforeSerializeSystem>(SystemUpdatePhase.Serialize);
            updateSystem.UpdateAfter<TidesAndWavesSystem>(SystemUpdatePhase.Serialize);
            updateSystem.UpdateAt<SeasonalStreamsSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAt<DisableSeasonalStreamSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAt<DisableWavesAndTidesSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAfter<SeasonalStreamsSystem>(SystemUpdatePhase.Serialize);
            updateSystem.UpdateAfter<AutofillingLakesSystem>(SystemUpdatePhase.Serialize);
            updateSystem.UpdateAfter<DetentionBasinSystem>(SystemUpdatePhase.Serialize);
            updateSystem.UpdateAfter<RetentionBasinSystem>(SystemUpdatePhase.Serialize);
            updateSystem.UpdateAt<AddPrefabsSystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateAt<WaterToolUISystem>(SystemUpdatePhase.UIUpdate);
            Log.Info($"{nameof(WaterFeaturesMod)}.{nameof(OnLoad)} Completed.");
        }

        /// <inheritdoc/>
        public void OnDispose()
        {
            Log.Info($"[{nameof(WaterFeaturesMod)}] {nameof(OnDispose)}");
            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }
        }
    }
}