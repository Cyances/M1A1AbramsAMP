# M1A1 Abrams AMP v2.2

## Branch release notes:
<p>
	<ul> 
		<li>Code refactoring (same setup as Atlas' M1A1 Abrams v1.0.9)</li>
		<li>Revised round attributes (refer to table)</li>
		<li>Revised HU armor protection (refer to table)</li>
		<li>Added correct gunner auxilliary sight reticles per round type (however, this only applies to the first two rounds per tank)</li>
		<li>Added demigod armor in configuration if you really want an almost deathproof Abrooms (false by default and only applies to HU variant)</li>
		<li>NOTE: Mission loading might be longer if you are using the HU variant, potentially due to the extra armor configuration.</li>
		<li>NOTE: XM1111 is in the config file but it is not implemented yet. Listing that in your loadout will make the mod use vanilla loadout (M833/M456). I only included it so there is no need to manually cleanup the config file if I could make it work.</li>
	</ul>
</p>


### Round changes
| Name  | Note |
| ------------- | ------------- |
| M829A4 APFSDS-T | +100% spalling chance |
| M830 HEAT-FS-T | Redisgnated from MP to FS and +50% spalling chance |


### Heavy Ultra (HU) - armor changes
| Area  | Protection vs KE (mm) | Protection vs CE (mm) | Note
| ------------- | ------------- | ------------- | ------------- | 
| Hull front | 810  | 1280 ||
| Turret cheek | 910 | 1580 ||
| Turret side | 510 | 1020 ||
| Composite side skirt | 300 | 550 ||
| Gun mantlet face | 180 | 210 ||
| Upper glacis | 180 | 210 ||
| Turret ring | 180 | 210 ||
| Turret roof | 140 | 175 ||
