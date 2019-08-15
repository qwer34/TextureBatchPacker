using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureBatchPacker
{
	partial class TexturePackerCaller
	{
		private static int GetJpgQuality(ConvertionParameters parameters)
		{
			switch (parameters.TextureQuality)
			{
				case TEXTURE_QUALITY.SFX:
					return 65;
				case TEXTURE_QUALITY.HIGH:
					return 85;
				case TEXTURE_QUALITY.LOW:
					return 65;
				default:
					return 75;
			}
		}

		private string GetTexturePackerArguments_JPG_ULTRA_HIGH(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format jpg --jpg-quality {2} --dpi 72 --opt RGB888 --max-size 4096 --size-constraints POT --force-squared --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 0 --inner-padding 0 --extrude 1 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					100,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format jpg --jpg-quality {2} --dpi 72 --opt RGB888 --max-size 4096 --size-constraints POT --force-squared --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 0 --inner-padding 0 --extrude 1 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					100,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_JPG_888(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format jpg --jpg-quality {2} --dpi 72 --opt RGB888 --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetJpgQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format jpg --jpg-quality {2} --dpi 72 --opt RGB888 --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetJpgQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_JPG_565(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format jpg --jpg-quality {2} --dpi 72 --opt RGB565 --dither-type FloydSteinberg --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetJpgQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format jpg --jpg-quality {2} --dpi 72 --opt RGB565 --dither-type FloydSteinberg --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetJpgQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}
	}
}
