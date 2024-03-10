# M1A1 Abrams AMP v2.4 WIP

## Branch release notes:
<p>
	<ul> 
		<li>New armor package: Situational Awareness (SA)</li>
		<li>New round: M908 HE-OR-T</li>
		<li>Round changes (refer to table)</li>
		<li>Configurable CITV upgrade</li>
		<li>Configurable enhanced optics for the GPS, FLIR and AGS</li>
		<li>Configurable loader proficiency</li>
		<li>M2 Coaxial upgrade (replaces M240 and has two ammo types)</li>
		<li>XM1147 AMP-T proximity fuze update</li>
		<li>Updated tank weight depending on the armor type used</li>
		<li>Configurable powertrain options and removable governor</li>
		<li>Toggleable Auxilliary Power Unit (APU)</li>
		<li>Configurable enhanced smoke launcher system</li>
		<li>Toggleable clean turret look (no attachments like ALICE packs or MREs)</li>
		<li></li>
	</ul>
</p>

### Round Changes
| Name  | Penetration (mm) | Fragment/Spalling Penetration (mm)| Muzzle Velocity (m/s) | Note |
| ------------- | ------------- | ------------- | ------------- |
| M908 HE-OR-T | 250* | 75** | 1410 | New! Has impact-delay fuze |
| XM1147 AMP-T | 250* | 100** | - | Changed behavior to HE instead of HEAT. Has proximity fuze now but still be able to retain the old time-delay fuze in config. |
| M829 | - | - | Toggleable +25% spalling chance |
| M829A1 | - | - | - | Toggleable +25% spalling chance |
| M829A2 | - | - | - | Toggleable +50% spalling chance |
| M829A3 | - | - | - | Toggleable +75% spalling chance |
| M2/M8 AP-T/I | 29 | 887 | M2 Coax |
| M962 SLAP-T | 36 | 1200 | M2 Coax. Has slightly less drag than M2/M8. |

<p>
	<ul> 
		<li>*These are HE rounds so actual penetration is not 250mm</li>
		<li>**These are <i>up to</i> values so not every fragment will reach perform the same</li>
		<li>M830A1, XM1147, M908 have slightly less drag now</li>
	</ul>
</p>

### Situational Awareness (SA) - roughly #% increase in protection
| Area  | Protection vs KE (mm) | Protection vs CE (mm) 
| ------------- | ------------- | ------------- | 
| Hull front |  |  |
| Turret cheek |  |  | 
| Turret side |  |  | 
| Composite side skirt |  |  | 
| Gun mantlet |  |  | 


### Weight
| Armor Type | Weight (KG) | Note |
| ------------- | ------------- | ------------- |
| Base | 59,057 | Base M1A1/E1 weight | 
| HA | 60,599 |  | 
| HC | 61,416 |  | 
| SA | 62,232 |  | 
| HU | 72,665 | Fully loaded SEPv3 used as reference. Has optional Unobtanium armor package that lets it weigh the same as the HA. | 

### Powertrain
| Engine type  | Peak power (HP) | Peak Torque (NM) | Max RPM | Braking Power | Note |
| ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | 
| AGT1500 | 1500 | 5741 | 3100 |  | Default engine. | 
| AGT2000 | 2000 | 7655 | 3100 | +7.5% | Fictional. | 
| AGT2500 | 2500 | 7415 | 4000 | +15% | Fictional. | 
| AGT3000 | 3000 | 8899 | 4000 | +22.5% | Fictional. | 
| T64 | 4430 | 12845 | 4000 | +30% | Fictional but it's the T64-GE-100. | 


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
