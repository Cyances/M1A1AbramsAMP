# M1A1 Abrams AMP v2.3.2
Big thanks to ATLAS/thebeninator for providing the Abrams and Bradley 50mm mod in the first place! All the required code was from his mods and I just figured out how to put the pieces together so that I could recreate the AMP round. I also would like to thank Swiss/SovGrenadier for the GLATGM implementation. Be sure to checkout their mods because they are great!

A mod for Gunner, HEAT, PC! Requires [MelonLoader](https://github.com/LavaGang/MelonLoader/)

If you get an error launching through Steam you will need to run the game executable directly.

![Screenshot_1](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20vs%20SPW-60B.png)
![Screenshot_2](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20vs%20SPW-60B%20XRay.png)
![Screenshot_3](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20vs%20T-55A.png)
![Screenshot_4](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20vs%20T-55A%20XRay.png)

## AMP 2.3 Update:
<p>
	<ul>
	<li>120mm M256 Gun</li>
	<li>M1IP automatically converted to M1A1</li>
	<li>Tank upgrades based on real life developments (but guesstimated values) and hypothetical thinking</li>
    	<li>Selectable Abrams armor variants: base armor, Heavy Armor (+30% protection), Heavy Common (+45% protection) and Heavy Ultra (custom)</li>
    	<li>Selectable rounds (up to four slots and 50 max total rounds)</li>
	<li>Default M1A1 loadout: 20x M829A4, 12x M830A2, 12x XM1147, 6x LAHAT</li>
	<li>Default M1E1 loadout: 20x M829, 15x M830, 15x M830A1 (press key 3/4 to select M830/A1)</li>
	<li>APFSDS: M829, M829A1, M829A2, M829A3, M829A4</li>
    	<li>HEAT: M830, M830A1, M830A2, M830A3, XM1147</li>
    	<li>GLATGM: LAHAT</li>
    	<li>XM1147 AMP-T multifuze round (airburst or point-detonate)</li>
	<li>Anti-ERA/tandem warhead properties for AP and HEAT (modelled for (Super) Kontakt-1, ARAT and BRAT), requires NATO ERA v1.1.1b and/or Pact Increased Lethality v1.2.5)</li>
	<li>"TUSK" postfix when ERA is detected (NATO ERA mod)</li>
 	</ul>
</p>

## Installation:
1.) Install [MelonLoader v0.6.1](https://github.com/LavaGang/MelonLoader/).

2.) Download the latest version from the [release page](https://github.com/Cyances/M1A1AbramsAMP/releases).

3.) Place zzM1A1AbramsAMP.dll file in the mods folder:

4.) Launch the game directly (not from Steam).
   
5.) On first time running this mod, the entries in MelonPreferences.cfg will only appear after launching the game then closing it.


## NOTE!
<p>
	<ul> 
		<li>Only include ATLAS' Abrams mod .dll file in the mods folder or this one. Do not place both .dll files at the same time.</li>
		<li>If you already have ATLAS' Abrams mod or have an older version of the Abrams AMP mod installed, either delete MelonPreferences.cfg in UserData folder or remove the lines pertaining to the [M1A1Config]/[M1A1AMPConfig] to make it easier to understand the custom config. Launch the game first then close it to update the contents of MelonPreferences.cfg</li>
		<li>XM1111 is in the config file but it is not implemented yet. Listing that in your loadout will make the mod use vanilla loadout (M833/M456A2). I only included it so there is no need to manually cleanup the config file if I could make it work.</li>
		<li>Mission loading might be longer if you are using the HU variant, potentially due to the extra armor configuration.</li>
		<li>For compatibility with other mods for the TUSK upgrade and anti-ERA effects, ensure that the AMP mod is loaded after NATO ERA and Pact Increased Lethatlity mod.</li>
	</ul>
</p>


## Armor variants list:
### Heavy Armor (HA) - roughly 30% increase in protection
| Area  | Protection vs KE (mm) | Protection vs CE (mm) 
| ------------- | ------------- | ------------- | 
| Hull front | 530  | 1070  |
| Turret cheek | 620 | 1350 | 
| Turret side | 500 | 460 | 
| Composite side skirt | 95 | 130 | 
| Gun mantlet | 500 | 800 | 

### Heavy Common (HC) - roughly 45% increase in protection
| Area  | Protection vs KE (mm) | Protection vs CE (mm) 
| ------------- | ------------- | ------------- | 
| Hull front | 590  | 1200  |
| Turret cheek | 690 | 1510 | 
| Turret side | 510 | 560 | 
| Composite side skirt | 105 | 145 | 
| Gun mantlet | 540 | 820 | 

### Heavy Ultra (HU) - Custom protection values
| Area  | Protection vs KE (mm) | Protection vs CE (mm) | Note
| ------------- | ------------- | ------------- | ------------- | 
| Hull front | 810  | 1280  | |
| Hull side/roof/bottom/rear | 200 | 300 | |
| Hull firewall | 30 | 30 | Acts as spall liner |
| Engine deck | 250 | 350 | |
| Turret cheek | 910 | 1580 | |
| Turret side | 510 | 1020 | |
| Turret rear | 500 | 1000 | |
| Turret firewall | 30 | 30 | Acts as spall liner |
| Composite side skirt | 300 | 550 | |
| Side skirt | 300 | 550 | The non-composite ones |
| Gun mantlet | 660 | 1020 | |
| Gun mantlet face | 240 | 300 | |
| Upper glacis | 180 | 210 | |
| Turret ring | 180 | 210 | |
| Turret roof | 150 | 180 | |
| Commander's hatch | 140 | 175 | |
| Loader's hatch | 140 | 175 | |
| Driver's hatch | 140 | 175 | |
| Hull ammo rack door | 45 | 45 | |

<p>
	<ul> 
		<li>Armor testing done in game which can result in inconsistency between the area shot at, and the angle and distance from it. However, I did my best to shoot at less than 100 meters and as close to 0 degrees for the perpendicular shot to the armor face.</li>
		<li>The only exception is the turret cheek and hull front where I emulated a headon engagement.</li>
		<li>HA and HC armor figures are roughly a 30% and 45% increase in protection becaue finding proper documentation is difficult (please don't violate ITAR). However, the values can be changed in the future if required. Although if you believe you found a seemingly decent (and unclass) source for the values, please let me know.</li>
		<li>If the protection increase seem to be arbitrary, I'm basing the values relative to the available (REDFOR) vanilla and modded penetrators. Example would be HA's cheek array <i>might</i> be able to hold against the T-64B mod 3BM42 (660mm which is highest REDFOR AP pen value) while the HC would completely protect against it.</li>
		<li>HU armor figures are based on Steal Beasts Abrams and my own inputs. It's basically the Abrams that received armor improvements everywhere (BEGONE SWaP-C).</li>
	</ul>
</p>

## Round types list:
| Name  | Penetration (mm) | Muzzle Velocity (m/s) | Note |
| ------------- | ------------- | ------------- | ------------- |
| M829 APFSDS-T | 600 | 1670  | - |
| M829A1 APFSDS-T  | 700 | 1575 | - |
| M829A2 APFSDS-T | 750 | 1680 | - |
| M829A3 APFSDS-T | 840 | 1555 | ERA is only 25% effective. |
| M829A4 APFSDS-T | 1000 | 1700 | Hypothethical round. +100% spalling chance and performance. ERA is only 15% effective.  |
| M830 HEAT-FS-T | 600 | 1140 | +50% spalling chance |
| M830A1 HEAT-MP-T | 480 | 1400 | Point-detonate fuze only. 600 fragments (configurable count). |
| M830A2 IHEAT-FS-T | 700 | 1400 | Hypothethical round. +100% spalling chance. ERA is only 15% effective. |
| M830A3 IHEAT-FS-T | 1000 | 1300 | Hypothethical round. +100% spalling chance. ERA is only 15% effective. |
| XM1147 AMP-T | 480 | 1410 | Point-detonate and airburst fuze. 600 fragments (configurable count). |
| LAHAT | 800 | 300 | Gun-launched ATGM with SALH guidance. ERA is only 20% effective.|

<p>
	<ul> 
		<li>The penetration values chosen are relative to the existing penetrators in the game and on assumptions/guesstimations based on open source information.</li>
		<li>Steel Beasts used as reference for M829 penetration values, except for the M829A4 which has completely made up stats</li>
		<li>Values for Anti-ERA effects are a total guess</li>
	</ul>
</p>

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
		<li>Selectable round types for four slots for M1A1 and M1E1. You can even go with a pure APFSDS or HEAT loadout. <b>Be careful when typing the round you want </b> because the mod will default to vanilla rounds (M833/M456A2) if there is a typo or if a field is left blank. The listed rounds are case-sensitive (just make sure it is all caps when entering the designated round).</li>
		<li>Customize how many rounds per type are carried by the M1A1 and M1E1 (total max of 50).</li>
		<li>Customize the number of fragments generated by the M830A1 (600 by default). <b>Be careful when setting a higher number</b> because it can negatively affect game performance.</li>
		<li>Customize the number of fragments generated by the XM1147 (600 by default). <b>Be careful when setting a higher number</b> because it can negatively affect game performance.</li>
 		<li>Horizontal sight stabilization for M1A1/E1s when applying lead (disabled by default but enable it to make it easier to aim the LAHAT)</li>
		<li>Convert non-IP M1s to M1E1s (enabled by default)</li>
		<li>Randomize M1A1/E1 conversions (enabled by default) </li>
		<li>Customize the armor variant used by M1A1 and M1E1 (HU for both by default). M1 must be converted to M1E1 to allow armor conversions. The mod will default to vanilla base armor when there is a typo or if a field is left blank.</li>
		<li>Demigod armor for the HU variant if you want an almost unkillable Abrooms (disabled by default)</li>
	</ul>
</p>

![Screenshot_5](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20MelonPreferences%20v2.PNG)
