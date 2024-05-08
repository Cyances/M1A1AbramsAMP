# M1A1 Abrams AMP v2.6

## Branch release notes:
<p>
	<ul> 
		<li>Compatibility fix for GHPC Update 20250507</li>
		<li>Code refactoring</li>
		<li>New "armor" package: Lightweight (L)</li>
		<li>Round changes (refer to table)</li>
		<li>Updated M256 gun barrel model (thank Atlas!)</li>
		<li>Disabled barrel camo net</li>
		<li>Updated M1E1 cheek armor so it uses the IP cheek armor as the base</li>
		<li>Fixed M1E1 IP model not considering the armor package upgrades</li>
		<li>Updated M2 coaxial sound</li>
		<li>Updated TUSK detection code (requires NATO ERA v1.2.2)</li>
		<li>Updated GAS+ and APU behavior</li>
		<li>Updated Abrams designation if CITV is installed</li>
		<li>Vehicle dynamics changes and additions</li>
	</ul>
</p>

## Abrams Renaming 
<p>
	<ul> 
		<li>Dependent on CITV installation</li>
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
| T55 | 6000 | 14833 | 4800 | +50% | New! Fictional but it's the Honeywell T55-L-714C. | 

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

### Stability Control (SC)
<p>
	<ul> 
		<li>Added stability control option which makes the tank more controllable at higher speeds</li>
	</ul>
</p>
