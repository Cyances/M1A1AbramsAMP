# M1A1 Abrams AMP v2.1
Big thanks to ATLAS/thebeninator for providing the Abrams and Bradley 50mm mod in the first place! All the required code was from his mods and I just figured out how to put the pieces together so that I could recreate the AMP round. I also would like to thank Swiss/SovGrenadier for the GLATGM implementation. Be sure to checkout their mods because they are great!

A mod for Gunner, HEAT, PC! Requires [MelonLoader](https://github.com/LavaGang/MelonLoader/)

If you get an error launching through Steam you will need to run the game executable directly.

![Screenshot_1](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20vs%20SPW-60B.png)
![Screenshot_2](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20vs%20SPW-60B%20XRay.png)
![Screenshot_3](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20vs%20T-55A.png)
![Screenshot_4](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20vs%20T-55A%20XRay.png)

## AMP 2.1 Update:
<p>
	<ul>
	<li>120mm M256 Gun</li>
	<li>M1IP automatically converted to M1A1</li>
	<li>Tank upgrades based on real life developments (but guesstimated values) and hypothetical thinking</li>
    	<li>Selectable Abrams armor variants: base armor, Heavy Armor (+12.5% protection), Heavy Common (+25% protection) and Heavy Ultra (custom)</li>
    	<li>Selectable rounds (up to four slots and 50 max total rounds).</li>
	<li>Default M1A1 loadout: 20x M829A4, 12x M830A2, 12x XM1147, 6x LAHAT</li>
	<li>Default M1E1 loadout: 20x M829, 15x M830, 15x M830A1 (press key 3/4 to select M830/A1)</li>
	<li>APFSDS: M829, M829A1, M829A2, M829A3, M829A4</li>
    	<li>HEAT: M830, M830A1, M830A2, XM1147</li>
    	<li>GLATGM: LAHAT</li>
    	<li>XM1147 AMP-T multifuze round (airburst or point-detonate)</li>
 	</ul>
</p>

## Armor variants list:
### Heavy Armor (HA) - roughly 12.5% increase in protection
| Area  | Protection vs KE (mm) | Protection vs CE (mm) 
| ------------- | ------------- | ------------- | 
| Hull front | 450  | 930  |
| Turret cheek | 540 | 1170 | 
| Turret side | 400 | 430 | 
| Composite side skirt | 80 | 112 | 
| Gun mantlet | 510 | 820 | 

### Heavy Common (HC) - roughly 25% increase in protection
| Area  | Protection vs KE (mm) | Protection vs CE (mm) 
| ------------- | ------------- | ------------- | 
| Hull front | 510  | 1030  |
| Turret cheek | 600 | 1300 | 
| Turret side | 430 | 480 | 
| Composite side skirt | 90 | 125 | 
| Gun mantlet | 565 | 910 | 

### Heavy Ultra (HU) - Custom protection values
| Area  | Protection vs KE (mm) | Protection vs CE (mm) 
| ------------- | ------------- | ------------- | 
| Hull front | 810  | 1280  |
| Turret cheek | 910 | 1580 | 
| Turret side | 510 | 1020 | 
| Composite side skirt | 310 | 600 |
| Gun mantlet | 660 | 1020 | 
| Gun mantlet face | 180 | 210 | 
| Upper glacis | 180 | 210 | 
| Turret ring | 180 | 210 | 
| Turret roof | 140 | 175 | 
| Commander's hatch | 140 | 175 | 
| Loader's hatch | 140 | 175 | 
| Driver's hatch | 140 | 175 | 

<p>
	<ul> 
		<li>Armor testing done in game which can result in inconsistency between the area shot at, and the angle and distance from it. However, I did my best to shoot at less than 100 meters and as close to 0 degrees for the perpendicular shot to the armor face.</li>
		<li>The only exception is the turret cheek and hull front where I emulated a headon engagement.</li>
		<li>HA and HC armor figures are just a flat 12.5% and 25% increase in protection becaue finding proper documentation is difficult (please don't violate ITAR). However, the values can be changed in the future if required. Although if you believe you found a seemingly decent (and unclass) source for the values, please let me know.</li>
		<li>If the protection increase appears to be low, I'm basing the values relative to the available (REDFOR) vanilla and modded penetrators. Example would be HA's cheek array would barely hold against a vanilla 3BM32 (560mm which is highest REDFOR pen value) while the HC would completely protect against it.</li>
		<li>HU armor figures are based on Steal Beasts Abrams and my own inputs.</li>
	</ul>
</p>

## Round types list:
| Name  | Penetration (mm) | Muzzle Velocity (m/s) | Note |
| ------------- | ------------- | ------------- | ------------- |
| M829 APFSDS-T | 600 | 1670  | - |
| M829A1 APFSDS-T  | 700 | 1575 | - |
| M829A2 APFSDS-T | 800 | 1680 | - |
| M829A3 APFSDS-T | 900 | 1555 | - |
| M829A4 APFSDS-T | 1000 | 1700 | +50% spalling chance |
| M830 HEAT-FS-T | 600 | 1140 | - |
| M830A1 HEAT-MP-T | 480 | 1400 | Point-detonate fuze only. 600 fragments (configurable count). |
| M830A2 IHEAT-FS-T | 1200 | 1240 | +100% spalling chance |
| XM1147 AMP-T | 480 | 1410 | Point-detonate and airburst fuze. 600 fragments (configurable count). |
| LAHAT | 800 | 300 | Gun-launched ATGM with SALH guidance.|

## How to use the XM1147 AMP-T:
<p>
	<ul> 
		<li>To use airburst mode, lase the target and aim slightly above it so that the shell will not impact the target. The airburst fuzing is not perfect since it might explode in front or behind the target instead of somewhere in the middle, so multiple shots might be required. Or to help compensate for the deviation, increase the fragment count but this can impact game performance.</li>
		<li>To use point-detonate mode, make sure the range setting is at least 10 meters more than the target to ensure it would not be in airburst mode. As long as the shell directly hits the target, it will use the point-detonate fuze.</li>
	</ul>
</p>

## Extra Features/Settings (in UserData/MelonPreferences.cfg):
<p>
	<ul> 
		<li>Selectable round types for four slots for M1A1 and M1E1. You can even go with a pure APFSDS or HEAT loadout. <b>Be careful typing the round you want</b> because the mod will default to vanilla rounds (M833/M456A2) if there is a typo or if a field is left blank.</li>
		<li>Customize how many rounds per type are carried by the M1A1 and M1E1 (total max of 50).</li>
		<li>Customize the number of fragments generated by the M830A1 (600 by default). <b>Be careful when setting a higher number</b> because it can negatively affect game performance.</li>
		<li>Customize the number of fragments generated by the XM1147 (600 by default). <b>Be careful when setting a higher number</b> because it can negatively affect game performance.</li>
 		<li>Horizontal sight stabilization for M1A1/E1s when applying lead (disabled by default but enable it to make it easier to aim the LAHAT)</li>
		<li>Convert non-IP M1s to M1E1s (enabled by default)</li>
		<li>Randomize M1A1/E1 conversions (enabled by default) </li>
		<li>Customize the armor variant used by M1A1 and M1E1 (HU for both by default). M1 must be converted to M1E1 to allow armor conversions. The mod will default to vanilla base armor when there is a typo or if a field is left blank.</li>
	</ul>
</p>
![Screenshot_5](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20MelonPreferences.PNG)

## NOTE!
<p>
	<ul> 
		<li>Only include ATLAS' Abrams mod .dll file in the mods folder or this one. Do not place both .dll files at the same time.</li>
		<li>If you already have ATLAS' Abrams mod or have an older version of the Abrams AMP mod installed, either delete MelonPreferences.cfg in UserData folder or remove the lines pertaining to the [M1A1Config]/[M1A1AMPConfig] to make it easier to understand the custom config. Launch the game first then close it to update the contents of MelonPreferences.cfg</li>
		<li>XM1111 is in the config file but it is not implemented yet. Listing that in your loadout will make the mod use vanilla loadout (M833/M456A2). I only included it so there is no need to manually cleanup the config file if I could make it work.</li>
	</ul>
</p>
