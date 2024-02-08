# M1A1 Abrams AMP v2.3

## Branch release notes:
<p>
	<ul> 
		<li>Code optimization</li>
		<li>Renamed .dll to zzM1A1AbramsAMP.dll </li>
		<li>HA variant is now +30% and HC variant is +45% armor compared to vanilla (refer to table)</li>
		<li>New round: M830A3 IHEAT-FS-T</li>
		<li>Ammo changes (refer to table)</li>
		<li>Anti-ERA/tandem warhead properties for AP and HEAT (modelled for (Super) Kontakt-1, ARAT and BRAT). Requires NATO ERA v1.1.1b and/or Pact Increased Lethality v 1.2.5</li>
		<li>"TUSK" postfix when ERA is detected (NATO ERA mod)</li>
	</ul>
</p>

### Round Changes
| Name  | Penetration (mm) | Muzzle Velocity (m/s) | Note |
| ------------- | ------------- | ------------- | ------------- |
| M829A2 APFSDS-T | 750 | 1680 | - |
| M829A3 APFSDS-T | 840 | 1555 | ERA is only 25% effective. |
| M829A4 APFSDS-T | 1000 | 1700 | ERA is only 15% effective. +100% spalling performance. |
| M830A2 IHEAT-FS-T | 700 | 1400 | ERA is only 15% effective. |
| M830A3 IHEAT-FS-T | 1000 | 1300 | ERA is only 15% effective. +100% spalling chance. |
| LAHAT | 800 | 300 | ERA is only 20% effective. |

<p>
	<ul> 
		<li>Steel Beasts used as reference for M829 penetration values</li>
		<li>M829A4 still at 1000 mm and buffed for the ultimate penetration</li>
		<li>Values for Anti-ERA effects are a total guess</li>
	</ul>
</p>

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

<p>
	<ul> 
		<li>Gun mantlet only have a slight armor increase compared to vanilla since it seems to be overperforming</li>
	</ul>
</p>
