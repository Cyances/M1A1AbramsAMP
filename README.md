# M1A1 Abrams AMP v2.6

## Branch release notes:
<p>
	<ul> 
		<li>Compatibility fix for GHPC Update 20250507</li>
		<li>New round: M908 HE-OR-T</li>
		<li>Round changes (refer to table)</li>
		<li>Configurable CITV upgrade</li>
		<li>Configurable enhanced optics for the GPS, Thermals and AGS</li>
		<li>Configurable loader proficiency</li>
		<li>M2 Coaxial upgrade (replaces M240 and has two ammo types)</li>
		<li>XM1147 AMP-T proximity fuze update</li>
		<li>Updated tank weight depending on the armor type used</li>
		<li>Configurable powertrain options and removable governor</li>
		<li>Toggleable Auxilliary Power Unit (APU)</li>
		<li>Configurable enhanced smoke launcher system</li>
		<li>Toggleable clean turret look (no attachments like ALICE packs or MREs)</li>
		<li>Fixed horizontal stabilizer not working in campaign</li>
		<li>Fixed issue with enhanced optics not working in campaign (from AMP 2.4 Preview 1)</li>
	</ul>
</p>

## Abrams Renaming 
<p>
	<ul> 
		<li>Dependent on CITV installation</li>
	</ul>
</p>

| Standard | w/ CITV | Note |
| ------------- | ------------- | ------------- |
| M1A1HA | M1A1 AIM |  | 
| M1A1HC | M1A2 |  | 
| M1A1SA | M1A2 SEP |  | 
| M1A1HU | M1A2U |  | 
| M1A1L | M1A2L |  | 

## Round Changes
| Name  | Penetration (mm) | Fragment/Spalling Penetration (mm)| Muzzle Velocity (m/s) | Note |
| ------------- | ------------- | ------------- | ------------- | ------------- |
| M829 APFSDS-T | 550 |  | -  | +15% spalling chance and +25% spalling performance |
| M829A1 APFSDS-T | 630 |  | - | +20% spalling chance and +50% spalling performance  |
| M829A2 APFSDS-T | 380 |  | - | +25% spalling chance and +100% spalling performance. ERA is only 90% effective.  |
| M829A3 APFSDS-T | 750 |  | - | +30% spalling chance and +150% spalling performance  |
| M829A4 APFSDS-T | 750 |  | - | +200% spalling performance. |
| XM1147 AMP-T | - | - | - | Added impact-delay fuze. |

<p>
	<ul> 
		<li>After discussions with other players and researching, the  penetration values for the M829 series have been revamped except for M829A4</li>
		<li>The M829 series are weaker but have increased spalling performance</li>
		<li>There is still a config option to reuse old SB values if desired and  extra spalling chance</li>
	</ul>
</p>

## Armor variants list:
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

## Vehicle Dynamics
### Weight
| Armor Type | Weight (KG) | Note |
| ------------- | ------------- | ------------- |
| L | 44,838 | Base M1A1/E1 weight | 

### Engines
| Engine type  | Peak power (HP) | Peak Torque (NM) | Max RPM | Braking Power | Note |
| ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | 
| T55 | 6000 | 14833 | 4800 | +50% | Fictional but it's the Honeywell T55-L-714C. | 

### Governor
<p>
	<ul> 
		<li>Adjusted governor delete option which now raises potential top speed to 129 km/h forwards and 72 km/h backwards</li>
	</ul>
</p>

## Other Features
### Enhanced optics
<p>
	<ul> 
		<li>Improved zoom levels for the GAS</li>
	</ul>
</p>

### Auxilliary Power Unit (APU)
<p>
	<ul> 
		<li>Bonus turret traversal speed increase is made toggleable but still requires T64 engine or better and if it's still running</li>
	</ul>
</p>
