# M1A1 Abrams AMP v2.4

## Branch release notes:
<p>
	<ul> 
		<li>New armor package: Situational Awareness (SA)</li>
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

## Round Changes
| Name  | Penetration (mm) | Fragment/Spalling Penetration (mm)| Muzzle Velocity (m/s) | Note |
| ------------- | ------------- | ------------- | ------------- | ------------- |
| M908 HE-OR-T | 250* | 75** | 1410 | New! Has impact-delay fuze |
| M830A1 HEAT-MP-T | - | 50** | 1410 | Has toggleable proximity fuze option in-game now |
| M830A2 IHEAT-FS-T | - | 35** | 1410 |  |
| M830A3 IHEAT-FS-T | - | 25** | 1310 |  |
| XM1147 AMP-T | 250* | 120** | - | Changed behavior to HE instead of HEAT. Has toggleable proximity fuze now but disabled in config. The time-delay fuze is still enabled by default. |
| M829 APFSDS-T | - | - | - | Toggleable +25% spalling chance |
| M829A1 APFSDS-T | - | - | - | Toggleable +25% spalling chance |
| M829A2 APFSDS-T | - | - | - | Toggleable +50% spalling chance |
| M829A3 APFSDS-T | - | - | - | Toggleable +75% spalling chance |
| M2/M8 AP-T/I | 29 | - | 887 | M2 Coax |
| M962 SLAP-T | 36 | - | 1200 | M2 Coax. Has slightly less drag than M2/M8. |

<p>
	<ul> 
		<li>*These are HE rounds so actual penetration is not 250mm</li>
		<li>**These are <i>up to</i> values so not every fragment will perform the same</li>
		<li>M830A1, XM1147, M908 have slightly less drag now</li>
	</ul>
</p>

## Armor variants list:
#### Situational Awareness (SA) - roughly 85% increase in KE protection
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


#### Heavy Ultra (HU) - Custom protection values
| Area  | Protection vs KE (mm) | Protection vs CE (mm) | Note
| ------------- | ------------- | ------------- | ------------- | 
| Hull front* | 1030  | 1500  |  |
| Turret cheek* | 1130 | 1800 |  |
| Turret side* | 730 | 1240 |  |
<p>
	<ul> 
		<li>*These areas have thicker face and backing plates that were added in AMPv2.3 but not listed before</li>
	</ul>
</p>

## Vehicle Dynamics
### Weight
| Armor Type | Weight (KG) | Note |
| ------------- | ------------- | ------------- |
| Base | 59,057 | Base M1A1/E1 weight | 
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
| T64 | 4430 | 12845 | 4000 | +40% | Fictional but it's the T64-GE-100. | 


### Transmission
<p>
	<ul> 
		<li>Upgradeable transmission with 6 forward gears and 3 reverse gears (compared to 4/2 of default)</li>
	</ul>
</p>


### Governor
<p>
	<ul> 
		<li>Governor delete option which raises potential top speed to 115 km/h forwards and 57 km/h backwards (compared to 72 km/h and 40 km/h with governor)</li>
	</ul>
</p>

## Other Features
### Enhanced optics
<p>
	<ul> 
		<li>GPS has 5 zoom levels (vs 2 for vanilla)</li>
		<li>Thermals have 5 zoom levels (vs 2 for vanilla), clearer image and removed scanlines</li>
		<li>AGS has 3 zoom levels (vs 1 for vanilla) and its less blurry when moving</li>
	</ul>
</p>

### Auxilliary Power Unit (APU)
<p>
	<ul> 
		<li>Retain vanilla turret traversal speed and lazing functionality even with destroyed engine</li>
		<li>Has slightly faster turret traversal speed if the engine is AGT2500 or better and if it's still running</li>
		<li>The APU itself has no model at the moment so it's indestructible</li>
	</ul>
</p>

### Smoke Launcher Upgrade
<p>
	<ul> 
		<li>Smoke+ upgrade, doubling the amount of salvos that could be fired and the throw distace of smoke grenades</li>
		<li>ROSY upgrade, featuring 4 salvos and 12 smoke grenades fired per salvo covering a +/- 82° sector in front of the turret</li>
	</ul>
</p>

### Loading Proficiency
<p>
	<ul> 
		<li>4 skill levels, with slowest loading time of 7 seconds (min qualification) and 1 second reduction as you go up</li>
		<li>Out of action loader and ready rack loading times are also affected</li>
	</ul>
</p>
