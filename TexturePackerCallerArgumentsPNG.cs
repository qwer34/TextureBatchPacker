﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureBatchPacker
{
	partial class TexturePackerCaller
	{
		private string GetTexturePackerArguments_PNG_8888(ConvertionParameters parameters)
		{
			string plistFullPath;
			string argument;

			plistFullPath = parameters.DstDir.FullName;

			if (!plistFullPath.EndsWith("\\"))
			{
				plistFullPath += "\\";
			}

			plistFullPath += parameters.SrcDir.Name;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format png --png-opt-level 1 --dpi 72 --opt RGBA8888 --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {1} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{2}\"",
					plistFullPath,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format png --png-opt-level 1 --dpi 72 --opt RGBA8888 --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {1} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{2}\"",
					plistFullPath,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_PNG_4444(ConvertionParameters parameters)
		{
			string plistFullPath;
			string argument;

			plistFullPath = parameters.DstDir.FullName;

			if (!plistFullPath.EndsWith("\\"))
			{
				plistFullPath += "\\";
			}

			plistFullPath += parameters.SrcDir.Name;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format png --png-opt-level 1 --dpi 72 --opt RGBA4444 --dither-type FloydSteinbergAlpha --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {1} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{2}\"",
					plistFullPath,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format png --png-opt-level 1 --dpi 72 --opt RGBA4444 --dither-type FloydSteinbergAlpha --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {1} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{2}\"",
					plistFullPath,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_PNG_565(ConvertionParameters parameters)
		{
			string plistFullPath;
			string argument;

			plistFullPath = parameters.DstDir.FullName;

			if (!plistFullPath.EndsWith("\\"))
			{
				plistFullPath += "\\";
			}

			plistFullPath += parameters.SrcDir.Name;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format png --png-opt-level 1 --dpi 72 --opt RGB565 --dither-type FloydSteinberg --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {1} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{2}\"",
					plistFullPath,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format png --png-opt-level 1 --dpi 72 --opt RGB565 --dither-type FloydSteinberg --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {1} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{2}\"",
					plistFullPath,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}

		private string GetTexturePackerArguments_PNG_INDEXED(ConvertionParameters parameters)
		{
			string plistFullPath;
			string argument;

			plistFullPath = parameters.DstDir.FullName;

			if (!plistFullPath.EndsWith("\\"))
			{
				plistFullPath += "\\";
			}

			plistFullPath += parameters.SrcDir.Name;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format png --png-opt-level 1 --dpi 72 --opt INDEXED --dither-type PngQuantHigh --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {1} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{2}\"",
					plistFullPath,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format png --png-opt-level 1 --dpi 72 --opt INDEXED --dither-type PngQuantHigh --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {1} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{2}\"",
					plistFullPath,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}
	}
}
