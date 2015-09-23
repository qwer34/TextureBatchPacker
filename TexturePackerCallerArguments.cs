﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureBatchPacker
{
	partial class TexturePackerCaller
	{
		private string GetTexturePackerArguments(ConvertionParameters parameters)
		{
			switch (parameters.TextureFormat)
			{
				case TEXTURE_FORMAT.PNG_8888:
					return GetTexturePackerArguments_PNG_8888(parameters);
				case TEXTURE_FORMAT.PNG_4444:
					return GetTexturePackerArguments_PNG_4444(parameters);
				case TEXTURE_FORMAT.PNG_888:
					return GetTexturePackerArguments_PNG_888(parameters);
				case TEXTURE_FORMAT.PNG_565:
					return GetTexturePackerArguments_PNG_565(parameters);
				case TEXTURE_FORMAT.PNG_INDEXED:
					return GetTexturePackerArguments_PNG_INDEXED(parameters);
				case TEXTURE_FORMAT.JPG_888:
					return GetTexturePackerArguments_JPG_888(parameters);
				case TEXTURE_FORMAT.JPG_565:
					return GetTexturePackerArguments_JPG_565(parameters);
				case TEXTURE_FORMAT.WEBP_8888:
					return GetTexturePackerArguments_WEBP_8888(parameters);
				case TEXTURE_FORMAT.WEBP_888:
					return GetTexturePackerArguments_WEBP_888(parameters);
				case TEXTURE_FORMAT.PKM:
					return GetTexturePackerArguments_PKM(parameters);
				default:
					return GetTexturePackerArguments_PNG_INDEXED(parameters);
			}
		}

		private string GetTrimSpriteNamesArgument()
		{
			if (TrimSpriteNames)
			{
				return "--trim-sprite-names ";
			}
			else
			{
				return "";
			}
		}
	}
}