namespace TextureBatchPacker
{
	partial class TexturePackerCaller
	{
		private static string GetPvrQuality(ConvertionParameters parameters)
		{
			switch (parameters.TextureQuality)
			{
				case TEXTURE_QUALITY.SFX:
					return "normal";
				case TEXTURE_QUALITY.HIGH:
					return "best";
				case TEXTURE_QUALITY.LOW:
					return "normal";
				default:
					return "high";
			}
		}

		private string GetTexturePackerArguments_PVR_TC4_ALPHA(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt PVRTCI_4BPP_RGBA --premultiply-alpha --max-size 4096 --size-constraints POT --force-squared --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt PVRTCI_4BPP_RGBA --premultiply-alpha --max-size 4096 --size-constraints POT --force-squared --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_PVR_TC4_NOALPHA(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt PVRTCI_4BPP_RGB --premultiply-alpha --max-size 4096 --size-constraints POT --force-squared --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt PVRTCI_4BPP_RGB --premultiply-alpha --max-size 4096 --size-constraints POT --force-squared --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_PVR_TC2_ALPHA(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt PVRTCI_2BPP_RGBA --premultiply-alpha --max-size 4096 --size-constraints POT --force-squared --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt PVRTCI_2BPP_RGBA --premultiply-alpha --max-size 4096 --size-constraints POT --force-squared --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_PVR_TC2_NOALPHA(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt PVRTCI_2BPP_RGB --premultiply-alpha --max-size 4096 --size-constraints POT --force-squared --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt PVRTCI_2BPP_RGB --premultiply-alpha --max-size 4096 --size-constraints POT --force-squared --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_PVR_4444(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt RGBA4444 --premultiply-alpha --dither-type FloydSteinbergAlpha --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt RGBA4444 --premultiply-alpha --dither-type FloydSteinbergAlpha --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_PVR_565(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt RGB565 --dither-type FloydSteinberg --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format pvr3 --pvr-quality {2} --opt RGB565 --dither-type FloydSteinberg --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetPvrQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}

			return argument;
		}
	}
}