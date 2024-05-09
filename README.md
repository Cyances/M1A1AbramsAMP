# M1A1 Abrams AMP
Big thanks to ATLAS/thebeninator for providing the Abrams and Bradley 50mm mod in the first place! All the required code was from his mods and I just figured out how to put the pieces together so that I could recreate the AMP round. I also would like to thank Swiss/SovGrenadier for the GLATGM implementation. Be sure to checkout their mods because they are great!

A mod for Gunner, HEAT, PC! Requires [MelonLoader](https://github.com/LavaGang/MelonLoader/)

If you get an error launching through Steam you will need to run the game executable directly.

![Screenshot_1](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20vs%20SPW-60B.png)
![Screenshot_3](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20vs%20T-55A.png)
![Screenshot_4](https://raw.githubusercontent.com/Cyances/M1A1AbramsAMP/master/Images/AMP%20vs%20T-55A%20XRay.png)
![AMP vs Mi-24](https://github.com/Cyances/M1A1AbramsAMP/assets/154455050/2727aa85-097b-41c6-8a31-6a6c8dd7af12)
![AMP Enhanced Optics v2](https://github.com/Cyances/M1A1AbramsAMP/assets/154455050/c538fba0-c967-429f-b91a-e6d338ec7a4e)


## AMP 2.6 Update:
<p>
	<ul>
	<li>120mm M256 Gun (with new model!)</li>
	<li>M1IP automatically converted to M1A1</li>
	<li>Tank upgrades based on real life developments (but guesstimated values) and hypothetical thinking</li>
    	<li>Configurable Abrams armor variants: base armor, Heavy Armor (+30% protection), Heavy Common (+45% protection), Situational Awareness (+85%) and Heavy Ultra (custom)</li>
    	<li>Configurable rounds (up to four slots and 50 max total rounds)</li>
	<li>Default M1A1 loadout: 20x M829A4, 12x M830A2, 12x XM1147, 6x LAHAT</li>
	<li>Default M1E1 loadout: 20x M829, 15x M830, 15x M830A1 (press key 2/3 to select M830/A1 [key 4 is just an empty rack of M830A1])</li>
	<li>APFSDS: M829, M829A1, M829A2, M829A3, M829A4</li>
    	<li>HEAT: M830, M830A1, M830A2, M830A3, XM1147</li>
    	<li>HE: XM1147, M908</li>
    	<li>GLATGM: LAHAT</li>
    	<li>XM1147 AMP-T multifuze round (point-detonate + time-delay or proximity)</li>
	<li>Anti-ERA/tandem warhead properties for AP and HEAT (modelled for (Super) Kontakt-1, Kontakt-5, ARAT and BRAT), requires at least NATO ERA v1.1.1b and/or Pact Increased Lethality v1.2.5)</li>
	<li>New Abrams designation if CITV is installed</li>
	<li>"TUSK" postfix when ERA is detected (NATO ERA v1.2.2 required)</li>
	<li>Configurable CITV upgrade</li>
	<li>Configurable enhanced optics for the GPS, FLIR and GAS</li>
	<li>Configurable tank crew proficiency</li>
	<li>M2 Coaxial upgrade (replaces M240 and has two ammo types)</li>
	<li>Updated tank weight depending on the armor type used</li>
	<li>Configurable vehicle dynamics</li>
	<li>Toggleable Auxilliary Power Unit (APU)</li>
	<li>Configurable enhanced smoke launcher system</li>
	<li>Toggleable clean turret look (no attachments like ALICE packs or MREs)</li>
	<li>Toggleable IP model conversion for M1E1</li>
 	</ul>
</p>

## Installation:
1.) Install [MelonLoader v0.6.1](https://github.com/LavaGang/MelonLoader/).

2.) Download the latest version from the [release page](https://github.com/Cyances/M1A1AbramsAMP/releases).

3.) Place zzM1A1AbramsAMP.dll and the m1a1CITV folder in the mods folder:
![AMP Installation](https://github.com/Cyances/M1A1AbramsAMP/assets/154455050/e3fe58f6-8968-4e89-8b98-37d94d6effe4)

4.) Launch the game directly (not from Steam).
   
5.) On first time running this mod, the entries in MelonPreferences.cfg will only appear after launching the game then normally closing it.


## NOTE!
<p>
	<ul> 
		<li>Only include ATLAS' Abrams mod .dll file in the mods folder or this one. <b>Do not place both .dll files at the same time.</b></li>
		<li>If you already have ATLAS' Abrams mod or have an older version of the Abrams AMP mod installed, either delete MelonPreferences.cfg in UserData folder or remove the lines pertaining to the [M1A1Config]/[M1A1AMPConfig] to make it easier to understand the custom config. Launch the game first then close it to update the contents of MelonPreferences.cfg</li>
		<li>Mission loading might be longer if you are using the HU variant, potentially due to the extra armor configuration.</li>
		<li>For compatibility with other mods for the TUSK upgrade and anti-ERA effects, ensure that the AMP mod is loaded after NATO ERA and Pact Increased Lethality mod.</li>
		<li>On the Gunner Auxiliary Sight (GAS) behavior: Only the first two rounds are considered and only one type of APFSDS (M829 series) and HEAT (other rounds) are considered. This means if you carry an all APFSDS/HEAT loadout but with different types, only the first round is considered by the GAS.</li>
	</ul>
</p>

## Round types list:
| Name  | Penetration (mm) | Fragment/Spalling Penetration (mm)| Muzzle Velocity (m/s) | Note |
| ------------- | ------------- | ------------- | ------------- | ------------- |
| M829 APFSDS-T | 550 |  | 1670  | +15% spalling chance and +25% spalling performance. Optional +25% spalling chance instead. |
| M829A1 APFSDS-T  | 630 |  | 1575 | +20% spalling chance and +50% spalling performance. Optional +25% spalling chance instead. |
| M829A2 APFSDS-T | 680 |  | 1680 | +25% spalling chance and +100% spalling performance. ERA is only 90% effective. Optional +50% spalling chance instead. |
| M829A3 APFSDS-T | 750 |  | 1555 | +30% spalling chance and +150% spalling performance. ERA is only 20% effective. Optional +75% spalling chance instead. |
| M829A4 APFSDS-T | 1000 |  | 1700 | Hypothethical round. +100% spalling chance and ++200% spalling performance. ERA is only 15% effective.  |
| M830 HEAT-FS-T | 600 |  | 1140 | +50% spalling chance |
| M830A1 HEAT-MP-T | 480 | 50** | 1410 | Point-detonate fuze only. 600 fragments (configurable count). |
| M830A2 IHEAT-FS-T | 700 | 35** | 1410 | Fictional round. +100% spalling chance. ERA is only 15% effective. |
| M830A3 IHEAT-FS-T | 1000  | 25** | 1310 | Fictional round. +100% spalling chance. ERA is only 15% effective. |
| M908 HE-OR-T | 250* | 75** | 1410 | Has impact-delay fuze. 300 fragments (configurable count). |
| XM1147 AMP-T | 250* | 120** | 1410 | Point-detonate + airburst fuze or proximity fuze. 600 fragments (configurable count). Has impact-delay fuze.|
| LAHAT | 800 | 300 |  | Gun-launched ATGM with SALH guidance. +100% spalling chance. ERA is only 20% effective. |
| M2/M8 AP-T/I | 29 | - | 887 | M2 Coax |
| M962 SLAP-T | 36 | - | 1200 | M2 Coax. Has slightly less drag than M2/M8. |

<p>
	<ul> 
		<li>After discussions with other players and researching, the penetration values for the M829 series have been revamped except for M829A4</li>
		<li>M829A4 simply has made up stats</li>
		<li>There is still a config option to reuse [Steel Beasts values](https://www.steelbeasts.com/sbwiki/index.php/Ammunition_Data#Main_Gun) if desired and extra spalling chance</li>
		<li>Values for Anti-ERA effects are a total guess</li>
		<li>*These are HE rounds so actual penetration is not 250mm</li>
		<li>**These are <i>up to</i> values so not every fragment will perform the same</li>
		<li>M830A1, XM1147, M908 have slightly less drag</li>
	</ul>
</p>

## How to use the XM1147 AMP-T or M830A1 HEAT-MP-T:
### Point-detonate + Time-delay Fuze (AMP only)

- Default fuzing type for AMP
- To use airburst mode, lase the target and aim slightly above it so that the shell will not impact the target. The airburst fuzing is not perfect since it might explode in front or behind the target instead of somewhere in the middle, so multiple shots might be required. Or to help compensate for the deviation, increase the fragment count but this can impact game performance.
- To use point-detonate mode, make sure the range setting is at least 10 meters more than the target to ensure it would not be in airburst mode. As long as the shell directly hits the target, it will use the point-detonate fuze.


### Point-detonate + Proxmity Fuze
- Proximity fuze option automatically enabled for the MPAT, but needs to be enabled in the config for the AMP 
- To use proximity mode, press middle mouse button and the round should have [Proximity] postfix to its name in the lower left part of the UI
- To use point-detonate mode, make sure the [Proximity] postfix is not present

![AMP Proximity Mode](https://github.com/Cyances/M1A1AbramsAMP/assets/154455050/e665ec03-62bd-44fe-9276-4f1d7ab12035)		

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

### Situational Awareness (SA) - roughly 85% increase in KE protection
| Area  | Protection vs KE (mm) | Protection vs CE (mm) | Note
| ------------- | ------------- | ------------- | ------------- |
| Hull front | 750  | 1200  |  |
| Turret cheek | 910 | 1510 |   |
| Turret side | 510 | 560 |   |
| Composite side skirt | 105 | 145 |   |
| Gun mantlet | 540 | 820 |   |
<p>
	<ul> 
		<li>Only the turret cheeks and hull front had a KE protection upgrade for the SA variant</li>
		<li>The other areas have the same values as the HC variant</li>
	</ul>
</p>

#### Lightweight (L)
| Area  | Protection vs KE (mm) | Protection vs CE (mm) | Note
| ------------- | ------------- | ------------- | ------------- |
| Turret cheek | 480 | 1040 |   |
| Composite side skirt | 47 | 75 |   |
| Gun mantlet | 455 | 735 |   |

<p>
	<ul> 
		<li>Base M1A1 protection but no hull or turret side special armor array</li>
	</ul>
</p>

### Heavy Ultra (HU) - Custom protection values
| Area  | Protection vs KE (mm) | Protection vs CE (mm) | Note
| ------------- | ------------- | ------------- | ------------- | 
| Hull front | 1030  | 1500  |  |
| Hull side/roof/bottom/rear | 200 | 300 | |
| Hull firewall | 30 | 30 | Acts as spall liner |
| Engine deck | 250 | 350 | |
| Turret cheek | 1130 | 1800 |  |
| Turret side | 730 | 1240 |  |
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

## Abrams Renaming 
<p>
	<ul> 
		<li>Dependent on CITV installation only</li>
		<li>M1E1 also gets same renaming scheme as the M1A1</li>
	</ul>
</p>

| Standard | w/ CITV | Note |
| ------------- | ------------- | ------------- |
| M1A1HA | M1A1 AIM |  | 
| M1A1HC | M1A2 |  | 
| M1A1SA | M1A2 SEP |  | 
| M1A1HU | M1A2U |  | 
| M1A1L | M1A2L |  | 

## Vehicle Dynamics
### Weight
| Armor Type | Weight (KG) | Note |
| ------------- | ------------- | ------------- |
| Base | 59,057 | Base M1A1/E1 weight | 
| L | 44,838 |  | 
| HA | 60,599 |  | 
| HC | 61,416 |  | 
| SA | 62,232 |  | 
| HU* | 72,665 | Fully loaded SEPv3 used as reference | 
<p>
	<ul> 
		<li>*HU variant has optional Unobtanium armor package (UAP) that lets it weigh the same as the HA</li>
	</ul>
</p>

### Engines
| Engine type  | Peak power (HP) | Peak Torque (NM) | Max RPM | Braking Power | Note |
| ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | 
| AGT1500 | 1500 | 5741 | 3100 |  | Default engine. | 
| AGT2000 | 2000 | 7655 | 3100 | +10% | Fictional. | 
| AGT2500 | 2500 | 7415 | 4000 | +20% | Fictional. | 
| AGT3000 | 3000 | 8899 | 4000 | +30% | Fictional. | 
| T64 | 4430 | 12225 | 4300 | +40% | Fictional but it's the General Electric T64-GE-100. | 
| T55 | 6000 | 14833 | 4800 | +50% | Fictional but it's the Honeywell T55-L-714C. | 


### Transmission
<p>
	<ul> 
		<li>Upgradeable transmission with 6 forward gears and 3 reverse gears (compared to 4/2 of default)</li>
	</ul>
</p>

### Suspension
<p>
	<ul> 
		<li>Added upgradeable suspension which slightly increases ride height, and increases suspension travel that has better performance on rough terrain </li>
	</ul>
</p>


### Tracks
<p>
	<ul> 
		<li>Added upgradeable tracks which increases grip to aid acceleration, braking and movement on steep terrain</li>
	</ul>
</p>


### Governor
<p>
	<ul> 
		<li>Governor delete option which raises potential top speed to 129 km/h forwards and 72 km/h backwards (compared to 72 km/h and 40 km/h with governor)</li>
	</ul>
</p>

### Stability Control (SC)
<p>
	<ul> 
		<li>Added stability control option which makes the tank more controllable at higher speeds</li>
	</ul>
</p>

## Other Features
### Enhanced optics
<p>
	<ul> 
		<li>GPS has 5 zoom levels (vs 2 for vanilla)</li>
		<li>Thermals have 5 zoom levels (vs 2 for vanilla), clearer image and removed scanlines</li>
		<li>GAS has 4 zoom levels (vs 1 for vanilla) and its less blurry when moving</li>
	</ul>
</p>

### Auxilliary Power Unit (APU)
<p>
	<ul> 
		<li>Retain nomral turret traversal speed (40°/s) and lazing functionality when engine is destroyed</li>
		<li>Toggle for faster turret traversal speed (60°/s) if the engine is T64 and if it's still running</li>
		<li>The APU itself has no model at the moment so it's indestructible</li>
	</ul>
</p>

### Smoke Launcher Upgrade
<p>
	<ul> 
		<li>Smoke+ upgrade, doubling the amount of salvos that could be fired and slightly increasing the throw distace of smoke grenades</li>
		<li>Smoke+ upgrade also lets any crew activate the smoke grenades/generator instead of being tied to a specific member</li>
		<li>ROSY upgrade, featuring 4 salvos and 12 smoke grenades fired per salvo covering a +/- 82° sector in front of the turret</li>
		<li>Option for improved ROSY* that has a faster deployment time and greater smoke generation, and even multispectral capability</li>
		<li>*Due to challenges in modding smoke grenades, the <b>vanilla smoke grenade is directly modified</b> which means the option above will also affect the smoke grenade behavior of the M60A1/3, M2, M113 and unupgraded M1 smoke system.</li>
		<li>*FPS drops might occur from the enhanced smoke effects</li>
	</ul>
</p>

### Crew Proficiency
<p>
	<ul> 
		<li>Commander and Gunner can have better (or worse) target spotting and gunnery skill</li>
		<li>Loader skill can have a loading time of 7 seconds (min qualification) and there is 1 second reduction as you go up in skill</li>
		<li>Out of action loader and ready rack loading times are also affected</li>
		<li>Has 4 skill levels, with Regular being default and the same as vanilla behavior (or slightly better)</li>
	</ul>
</p>

## Mod Configuration (in UserData/MelonPreferences.cfg):

<p>
	<ul> 
		<li>I suggest getting Notepad++ so it would be easier to identify each category</li>
		<li>Selectable round types for four slots for M1A1 and M1E1. You can even go with a pure APFSDS or HEAT loadout. <b>Be careful when typing the round you want </b> because the mod will default to vanilla rounds (M833/M456A2) if there is a typo or if a field is left blank. The listed rounds are case-sensitive (just make sure it is all caps when entering the designated round).</li>
		<li>Customize how many rounds per type are carried by the M1A1 and M1E1 (total max of 50).</li>
		<li>Customize the tank gunner, commander and loader skill per tank (Regular by default)</li>
		<li>Upgrade the M240 coax to M2 coax with two ammo options (false by default)</li>
		<li>Enhanced M829 spalling (false by default)</li>
		<li>Customize the number of fragments generated by the M830A1 (600 by default). <b>Be careful when setting a higher number</b> because it can negatively affect game performance.</li>
		<li>Customize the number of fragments generated by the XM1147 (600 by default). <b>Be careful when setting a higher number</b> because it can negatively affect game performance.</li>
		<li>Customize the number of fragments generated by the M908 (300 by default). <b>Be careful when setting a higher number</b> because it can negatively affect game performance.</li>
		<li>XM1147 fuze type betweeen point-detonate + time-delay (default) or point-detonate + proximity</li>
		<li>Trigger distance for proximity-enabled rounds (3 by default)</li>
		<li>Enhanced gunner optics for Daysight, Thermals and GAS (false by default)</li>
		<li>Enable the CITV and customize its behavior (false by default)</li>
 		<li>Horizontal sight stabilization for M1A1/E1s when applying lead (false by default)</li>
		<li>Convert non-IP M1s to M1E1s (true by default)</li>
		<li>Randomize M1A1/E1 conversions (true by default) </li>
		<li>Customize the armor variant used by M1A1 and M1E1 (SA for M1A1 and HC for M1E1 by default). M1 must be converted to M1E1 to allow armor conversions. The mod will default to vanilla base armor when there is a typo or if a field is left blank.</li>
		<li>UAP option to make the HU armor weigh the same as the HA (false by default)</li>
		<li>Demigod armor for the HU variant if you want an almost unkillable Abrooms (false by default)</li>
		<li>Enhanced smoke launching system (false by default)</li>
		<li>ROSY upgrade (false by default)</li>
		<li>Improved ROSY (false by default)</li>
		<li>Cuztomize the engine per tank (AGT1500 by default)</li>
		<li>Enhanced transmission (false by default)</li>
		<li>Enhanced suspension (false by default)</li>
		<li>Enhanced tracks (false by default)</li>
		<li>Engine governor removal (false by default)</li>
		<li>Stability Control (false by default)</li>
		<li>Enable APU per tank (false by default)</li>
		<li>Enable bonus turret traversal with APU installed (false by default)</li>
		<li>Remove turret decors like ALICE packs or MRE boxes (false by default)</li>
		<li>M1E1 uses M1IP model (false by default)</li>
	</ul>
</p>

![AMP MelonPreferences v3-1](https://github.com/Cyances/M1A1AbramsAMP/assets/154455050/13417ec3-b701-4c5e-aba9-3915770960ff)
![AMP MelonPreferences v3-2](https://github.com/Cyances/M1A1AbramsAMP/assets/154455050/a4f0a666-3852-419f-8bfe-778b61fa4d1b)


