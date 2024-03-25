# Water_Features
In-Game Water Tool - Place, remove, and edit water sources. Lakes, Streams, Rivers, and Seas.
Optional Opt-out: Seasonal Streams - Flow rates vary with season, precipitation, and snow melt.
Optional Opt-in: Waves and Tides - Sea level rises and falls.

Sully has made an outstanding demo video covering the new features related to water. Available on [Youtube](https://www.youtube.com/watch?v=Q9QZ0n60i9c).

## Dependencies
Unified Icon Library

## Donations
If you want to say thank you with a donation you can do so on [Paypal](https://www.paypal.com/paypalme/YenyangsMods).

## Translations
I am looking for volunteers to help translate the mod into the official languages. For those interested please find the project in the discord link. CSL2:CODEMODS -> mods-wip -> Water Features: Translations.

# Detailed Descrption
## Water Tool
Water Sources:
Stream - Constant or Variable Rate Water Source: Emits water depending on the settings for this mod. With Seasonal Streams disabled, the flow rate will be constant. With Seasonal Streams enabled the flow rate will vary with season, precipitation, and snowmelt depending on your settings. Left click to place within playable area. Hover over and right click to remove.
River - Border River Water Source: Has a constant level and controls water flowing into or out of the border. While near the border, the source will snap to the border. Right click to designate the target elevation. Left click to place. Hover over and right click to remove.
Lake - Constant Level Water Source: Fills quickly until it gets to the desired level and then maintains that level. If it has a target elevation below the ground level, it can drain water faster than evaporation. Right click to designate the target elevation. Left click to place within playable area. Hover over and right click to remove.
Sea - Border Sea Water Source: Controls water flowing into or out of the border and the lowest sea controls sea level. With Waves and Tides disabled, it will maintain constant level. With Waves and Tides enabled the sea level rises and falls below the original sea level. Right click to designate the elevation. Left click to place if the radius touches a border. Hover over and right click to remove.

Optional Opt-In Custom Water Sources: (Enabling/Disabling these in the settings requires restarting the game)
Detention Basin: Custom modded water source that rises with precipitation and snowmelt and slowly drains when the weather is dry. They have a maximum water surface elevation but no minimum water surface elevation. Right click to designate the maximum elevation. Left click to place within playable area. Hover over and right click to remove.
Retention Basin: Custom modded water source that rises with precipitation and snowmelt and slowly drains when the weather is dry. They have a maximum water surface elevation and a minimum water surface elevation. Right click to designate the maximum elevation. Left click to place within playable area. Hover over and right click to remove.

The tool is accessed in the landscaping menu with a tab with a water drop and icons for the different water sources.
Small radius water sources will have some extra clickable space for interacting with them.
Large radius water sources will have a small filled circle for interacting with them.
If you are placing a source with an assigned depth you should place them at the intended bottom of the water feature.
For now you cannot remove water sources from utility structures.

The tool has 4 tool modes:
Place Water Source will place water sources with left click, and remove water sources with right click.
Elevation Change will change target elevations of existing water sources by hovering over existing water source, left clicking, holding, dragging and releasing at new elevation. Usually dragging out raises, and dragging in lowers, but it's really just releasing at the desired elevation. Keep the cursor within playable area for reliability. Right click to cancel.
Move Water Source will move existing water sources. Target elevations of existing water sources will not change. Right click to cancel.
Radius Change will change radius of water sources. Right click to cancel.

## Seasonal Streams - Optional Opt-out
Seasonal Streams takes Streams (Modified Constant Rate Water Source): and ties them to the climate and weather for the map. 
For example, if your map features a dry summer, then these water sources will decrease during the summer. 
Seasonal streams by it-self should not cause flooding since it treats the map's default water source amount as a maximum unless you change it. 
All aspects are optional and adjustable in the mod's settings.

## Waves and Tides - Optional Opt-in
This feature is dependent on map design. Maps with a sea water source and a single shoreline work best. 
The point of the waves feature is to make the shore move in and out and make sand along the shoreline. A better way to make beaches is to just paint them with surface painter instead. 
Waves are generated at the map boundary where there is a Sea water source. Once generated they head towards shore. Maps were not necessarily designed for these waves, but the waves will always be lower than the sea level from the original map.
Tides are the biggest waves and they cause the sea to rise and fall along the shore. Tides can add sandy graphics along shorelines but the sand may not persist the entire time between low tide and high tide. 
Option to change the global damping value. The setting is inverted though so higher numbers mean less damping and stronger waves.
Maps such as San Francisco with shallow seas will need waves and tides with smaller heights to avoid large swathes of non-playable area becoming dry sand.

## Saving
Before saving, the mod always resets all water sources including the custom ones in a manner that can be loaded safely without the mod, so that the mod can be removed at any time.

## Additional Features in the Settings
Adjust the global evaporation rate which can be helpful with Detention and Retention basins.
Water Clean Up Cycle is an emergency solution for removing water in developed areas by increasing the global evaporation rate for a short time. Better option: Lakes with an elevation below the ground surface drain water faster than evaporation.
Experimental: Adjust fluidness.

## In the Editor
All features of this mod within the editor are considered experimental.
Yenyang's custom water tool is available in the editor, and can be used alongside the vanilla water tool. 
Keep in mind that while filling up Constant Level water sources placed with the custom water tool are differnet than vanilla. They revert to vanilla when they have reached the target elevation.
Seasonal Streams, evaporation, water cleanup cycle, fluidness, and waves and tides settings will not affect the editor simulation unless you opt-in with the settings.
You may need to untoggle and retoggle seasonal streams and waves and tides to get them to start in the editor.

## Planned Features
Option to add polluted water sources...?
Rainfall 2 including storm drains might be included as opt-in option eventually.
Tying snow melt simulation to snow system graphics.

## Support
I will respond on the code modding channels on **Cities: Skylines Modding Discord**

## Credits 
* yenyang - Mod Author
* Sully - Testing, Feedback, and Promotional Material
* Chameleon TBN - Testing, Feedback, Icons, and Logo
* Klyte45, Algernon, Alpha Gaming - Help with UI, Cooperative Development and Code Sharing
* T.D.W., krzychu124, and Quboid - Cooperative Development and Code Sharing
* Localization: Hendrix (German), Nyoko and Citadino (Spanish), Luiz Fernando de Paula (Portuguese), Karmel68 (Polish)
* ST-Apps - Help with UI and Code Sharing
* Tigon Ologdring, Dante - Testing, Feedback