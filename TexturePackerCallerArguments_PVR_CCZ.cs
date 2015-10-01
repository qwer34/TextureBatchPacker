using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureBatchPacker
{
	partial class TexturePackerCaller
	{
		private static string GetPvrCczQuality(ConvertionParameters parameters)
		{
			switch (parameters.TextureQuality)
			{
				case TEXTURE_QUALITY.HIGH:
					return "best";
				case TEXTURE_QUALITY.LOW:
					return "high";
				default:
					return "high";
			}
		}

		private string GetTexturePackerArguments_PVR_CCZ_TC4_ALPHA(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" {1}--texture-format pvr3ccz --pvr-quality {2} --opt PVRTC4 --premultiply-alpha --max-size 16384 --size-constraints POT --force-squared --force-word-aligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetPvrCczQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" {1}--texture-format pvr3ccz --pvr-quality {2} --opt PVRTC4 --premultiply-alpha --max-size 16384 --size-constraints POT --force-squared --force-word-aligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetPvrCczQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_PVR_CCZ_TC4_NOALPHA(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" {1}--texture-format pvr3ccz --pvr-quality {2} --opt PVRTC4_NOALPHA --premultiply-alpha --max-size 16384 --size-constraints POT --force-squared --force-word-aligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetPvrCczQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" {1}--texture-format pvr3ccz --pvr-quality {2} --opt PVRTC4_NOALPHA --premultiply-alpha --max-size 16384 --size-constraints POT --force-squared --force-word-aligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetPvrCczQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_PVR_CCZ_TC2_ALPHA(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" {1}--texture-format pvr3ccz --pvr-quality {2} --opt PVRTC2 --premultiply-alpha --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetPvrCczQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" {1}--texture-format pvr3ccz --pvr-quality {2} --opt PVRTC2 --premultiply-alpha --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetPvrCczQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_PVR_CCZ_TC2_NOALPHA(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" {1}--texture-format pvr3ccz --pvr-quality {2} --opt PVRTC2_NOALPHA --premultiply-alpha --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetPvrCczQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" {1}--texture-format pvr3ccz --pvr-quality {2} --opt PVRTC2_NOALPHA --premultiply-alpha --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetPvrCczQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}
	}
}
