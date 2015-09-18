using System;
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
				//return GetTexturePackerArguments_PNG_888(parameters);
				case TEXTURE_FORMAT.PNG_565:
					return GetTexturePackerArguments_PNG_565(parameters);
				default:
					return GetTexturePackerArguments_PNG_INDEXED(parameters);
			}
		}
	}
}
