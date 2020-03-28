namespace TextureBatchPacker
{
	internal partial class TexturePackerCaller
	{
		private static int GetWebpQuality(ConvertionParameters parameters)
		{
			switch (parameters.TextureQuality)
			{
				case TEXTURE_QUALITY.SFX:
					return 60;
				case TEXTURE_QUALITY.HIGH:
					return 86; // 高质量定义为无损
				case TEXTURE_QUALITY.LOW:
					return 60;
				default:
					return 72;
			}
		}

		private string GetTexturePackerArguments_WEBP_8888(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format webp --webp-quality {2} --opt RGBA8888 --premultiply-alpha --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetWebpQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format webp --webp-quality {2} --opt RGBA8888 --premultiply-alpha --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetWebpQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_WEBP_888(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format webp --webp-quality {2} --opt RGB888 --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetWebpQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format webp --webp-quality {2} --opt RGB888 --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetWebpQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_WEBP_4444(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format webp --webp-quality {2} --opt RGBA4444 --premultiply-alpha --dither-type FloydSteinbergAlpha --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetWebpQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format webp --webp-quality {2} --opt RGBA4444 --premultiply-alpha --dither-type FloydSteinbergAlpha --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetWebpQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_WEBP_565(ConvertionParameters parameters)
		{
			string argument;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format webp --webp-quality {2} --opt RGB565 --dither-type FloydSteinberg --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetWebpQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d-v2 --data \"{0}\" {1}--texture-format webp --webp-quality {2} --opt RGB565 --dither-type FloydSteinberg --max-size 4096 --size-constraints WordAligned --scale {3} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{4}\"",
					getPlistFullPath(parameters), GetTrimSpriteNamesArgument(), GetWebpQuality(parameters),
					parameters.Scale, parameters.SrcDir.FullName);
			}

			return argument;
		}
	}
}