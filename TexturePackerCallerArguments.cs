﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureBatchPacker
{
	partial class TexturePackerCaller
	{
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
					"--format cocos2d --data \"{0}\" --texture-format png --png-opt-level 0 --dpi 72 --opt RGBA4444 --dither-fs-alpha --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {1} --scale-mode Smooth --algorithm Basic --pack-mode Fast --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{2}\"",
					plistFullPath,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format png --png-opt-level 0 --dpi 72 --opt RGBA4444 --dither-fs-alpha --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {1} --scale-mode Smooth --algorithm Basic --pack-mode Fast --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{2}\"",
					plistFullPath,
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}
	}
}
