using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureBatchPacker
{
	partial class TexturePackerCaller
	{
		private static string GetPkmQuality(ConvertionParameters parameters)
		{
			switch (parameters.TextureQuality)
			{
				case TEXTURE_QUALITY.HIGH:
					return "high-perceptual";
				case TEXTURE_QUALITY.LOW:
					return "low-perceptual";
				default:
					return "low-perceptual";
			}
		}

		private string GetTexturePackerArguments_PKM(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" {1}--texture-format pkm --etc1-quality {2} --premultiply-alpha --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetPkmQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" {1}--texture-format pkm --etc1-quality {2} --premultiply-alpha --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters),
					GetTrimSpriteNamesArgument(),
					GetPkmQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}
	}
}
