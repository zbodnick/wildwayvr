LowPoly Track - Lava (2020/8/25 - by Fatty War, id3644@gmail.com)


==This document explains how to use the pack.==

Introduction

    Track kit for low poly art.
	Easily assemble your favorite tracks with drag and drop.
	Modules are blocks that combine roads and terrain. (54 by 54)
	The track is 10 unit/unity wide (various widths will be updated in the future).
	
	Note).
	-All meshes used only one material & texture. Each mesh has its own UV for each color.
	-Track width and type can be added by feedback. Please leave feedback in the comments.
	-The track movement tool has been removed for package stability.(If you need a track movement tool, please let us know via e-mail / We will deliver it to the custom package via e-mail.)

1. Folder description

     1-1. Meshs(Assets\LowPolyTrack-Lava\Meshs)
          Contains the fbx just exported from 3dmax.

     1-2. Models(Assets\LowPolyTrack-Lava\Models)
          Contains a basic prefab with only material linked.(with Collider, Collider is sometimes absent. Ex - grass, decal.)

               \Bg. (Assets\LowPolyTrack-Lava\Models\Bg) - Contains environmental props used as a background.(with Material & Collider)
               \DownhillCourse. (Assets\LowPolyTrack-Lava\Models\DownhillCourse) - Contains a broken slope road. (with Material & Collider)
			   \Ground. (Assets\LowPolyTrack-Lava\Models\Ground) - There are trackless terrain and transition blocks.
               \Slope. (Assets\LowPolyTrack-Lava\Models\Slope) - There are slope modules that connect different height terrain.(with Material & Collider)
               \Track. (Assets\LowPolyTrack-Lava\Models\Track) - Contains an empty track ground. (with Material & Collider)

     1-3. Prefabs(Assets\LowPolyTrack-Lava\Prefabs)
          Contains a complex prefab assembled as a basic prefab in the Models folder.(Basic models may be combined, or scripts, special shaders may be combined.)

               \Downhill(M)odules. (Assets\LowPolyTrack-Lava\Prefabs\DownhillM) - Contains a prefab for the preview video "Downhill" displayed in the store product information. (If you do not want a broken road, please suspend use.)
               \StuntPrototype. (Assets\LowPolyTrack-Lava\Prefabs\StuntPrototype) - Contains a prefab for the preview video "stunt" displayed in the store product information.
               \Track(M)odules. (Assets\LowPolyTrack-Lava\Prefabs\TrackM) - There is a  decorated track module. Drag and drop to assemble tracks.
               \Slope(M)odules. (Assets\LowPolyTrack-Lava\Prefabs\SlopeM)- There is a decorated slope module. Assemble the slope by drag and drop.

2.File Naming
     2-1 Track. (Assets\LowPolyTrack-Lava\Models\Track)
	V1.05 Note) As of 1.04, the "Track" string has been removed from the track mesh name.

	ex) Bg_54x54W10TrackA00 + extension (A + B)

	-A
	 1. 54x54 Modular, Road Wide 10, A Thema Track(Forest).
	 2. 54x54 Modular, Road Wide 10, B Thema Track(Road track without terrain.).
	 3. 54x54 Modular, Road Wide 10, C Thema Track(Asphalt track without terrain.).
	 4. 54x54 Modular, Road Wide 10, D Thema Track(Tropical beach).
	 5. 54x54 Modular, Road Wide 10, L Thema Track(Lava Field).

	-B
	 1. Empty = Straight.
	 2. C = Corner.
	 3. D = Diagonal.
	 4. E = End.
	 5. DL = Diagonal Left.
	 6. DLS = Diagonal Left Part Start.
	 7. DR = Diagonal Right.
	 8. DRS = Diagonal Right Part Start.
	 9. DL45 = Diagonal Turn Left.
	 10. DR45 = Diagonal Turn Right.
	 11. DCL = Diagonal Corner Left.
	 12. DCR = Diagonal Corner Right.
	 13. X = Cross
	 14. XOver = Cross(Overpass)
	 15. BandL = Band Left. (Straight Module Piaces)
	 16. BandR = Band Right. (Straight Module Piaces)
	 17. BandSide = One Side Track (Straight Module Piaces)
	 
	 
     2-2 DownhillCourse. (Assets\LowPolyTrack-Lava\Models\DownhillCourse)
             *Some roads are cut off for stunts.

             ex) Bg_DHCourseA + extension (A + B)
             
             -A
             1. 54x54 Modular, Road Wide 10, (L)ava Thema Course.
             2. 54x54 Modular, Road Wide 10, (L)ava Thema Jump.
             
             -B
             1. I = Straight.
             2. JB = (J) letter shape, (B)roken.
             3. LB = (L) letter shape, (B)roken.
             4. ZB = (Z) letter shape, (B)roken.
             
     2-3 Slope, (Assets\LowPolyTrack-Lava\Models\Slope)
             You can assemble terrain with different heights.
             There are no roads on the slopes, only ramps.

             ex) Bg_DHSlopeA00 + extension (A + B)
             
             -A
             1. 54x54 Modular, Road Wide 10, (L)ava Thema Slope(Forest).
             2. 54x54 Modular, Road Wide 10, (L)ava Thema Bridge(Forest).
             
             -B
             1. I = Side Slope.
			 2. C = (C)orner Slope.
			 3. CN = (C)orner (N)egative Resist.
			 4. D = (D)iagonal Side Slope.
			 5. R = (R)amp road Slope.
			 6. RE = (R)amp (E)nd road Slope.

     *2-4 Ground. (Assets\LowPolyTrack-Lava\Models\Ground)
             Build trackless terrain.
             
             ex) Bg_54x54GroundL00
             
             1. GroundL00 = Lava Thema Ground
             2. LtoA00 = Lava and forest transition blocks.
             3. Extra = Although not common, it is used for special conditions.
             
     2-5 Downhill(M)odule. (Assets\LowPolyTrack-Lava\Prefabs\DownhillM)
             You can assemble terrain with different heights.
             There are no roads on the slopes, only ramps.

             ex) Bg_DHCliff01 + extension (A + B)
             -A
              Downhill Cliff
              Downhill Slope

             -B
             1. Empty = Basic terrain without roads.
             2. I = Straight course downhill..
			 3. J = (J) course downhill.
			 4. L = (L) course downhill.
			 5. Z = (Z) course downhill.
			 6. Jump = Jump course downhill.
			 7. Three = Triple jump downhill

     2-6 Slope(M)odule. (Assets\LowPolyTrack-Lava\Prefabs\SlopeM)
             Create tracks for infinite runner-like games.
             Straight and curved roads are included.

             ex) Bg_DHS00 + extension (A + B)
             -A
              54x54 Modular Slpoe Set

             -B
             1. I = Side Slope.
			 2. C = (C)orner Slope.
			 3. CN = (C)orner (N)egative Resist.
			 4. D = (D)iagonal Side Slope.
			 5. R = (R)amp road Slope.
			 6. RE = (R)amp (E)nd road Slope.

     2-7 Runner(M)odule. (Assets\LowPolyTerrain-Track\Prefabs\RunnerM)
             Create tracks for infinite runner-like games.
             Straight and curved roads are included.

             ex) Run_54L + extension (A + B)
             -A
              Run_54L = Infinite runner 54M track.
              Run_162L = Infinite runner 62M track.
              Run_x~ = Infinite runner Obstacle.

             -B
             1. Flat = Flat Module.
             2. FlattoHill = Flat to Hill Blend Module.
			 3. FlattoCliff = Flat to Cliff Blend Module.
			 4. Cliff = Cliff Module.
			 5. ClifftoFlat = Cliff to Flat Blend Module.
			 6. ClifftoHill = Cliff to Hill Blend Module.
			 7. Hill = Hill Module.
			 8. HilltoCliff = HilltoCliff Blend Module.
			 9. HilltoFlat = HilltoFlat Blend Module.
			 10. BandLeft = Left biased road set (case 162M)
			 11. BandRight = Right biased road set (case 162M)
	 
3. Scripts
	-Contains script for bloom effect.
		The bloom effect used in the package is open source.
		See the link for more information on the bloom effect script.(https://github.com/keijiro/KinoBloom)

4. Shader
	-Contains shaders necessary for the bloom effect.


5. Example Scene(Assets\ModularTrackKit\Scenes)

	-TrackDemo-54Lava
       -Here is an example terrain where packages are used.

	-TrackDemo-54LavaTrackExample
       -Includes 12 template tracks.

	-Display-54LavaTrack
	   -Prefabs used in the package are on display.

	-TrackDemo-54LavaCourseExample
		-Contains 15 course examples.

	-SlopeDemo-54LavaDownhill
		-It is the track that connected the slope.
		-The stunt track allows you to slide down the slope or jump down the slope.

	-TrackDemo-54LavaRunnerTileBlend
		-Contains examples of mixing between tracks.

*If you have any questions or suggestions about the assets, please contact me.(id3644@gmail.com)
Thank you for your purchase.
