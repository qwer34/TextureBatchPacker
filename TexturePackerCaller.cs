using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace TextureBatchPacker
{
	partial class TexturePackerCaller
	{
		public enum PACKING_MODE
		{
			EDITOR = 0,
			DESKTOP,
			IOS,
			ANDROID,
			END_OF_ENUM
		};

		private enum TEXTURE_FORMAT
		{
			PNG_8888 = 0,
			PNG_4444,
			PNG_888,
			PNG_565,
			PNG_INDEXED,
			PVR_CCZ_TC4_ALPHA,
			PVR_CCZ_TC4_NOALPHA,
			PVR_CCZ_TC2_ALPHA,
			PVR_CCZ_TC2_NOALPHA,
			PVR_CCZ_4444,
			PVR_CCZ_565,
			PVR_TC4_ALPHA,
			PVR_TC4_NOALPHA,
			PVR_TC2_ALPHA,
			PVR_TC2_NOALPHA,
			PVR_4444,
			PVR_565,
			JPG_888,
			JPG_565,
			WEBP_8888,
			WEBP_888,
			WEBP_4444,
			WEBP_565,
			PKM,
			END_OF_ENUM
		};

		private enum TEXTURE_QUALITY
		{
			LOW = 0,
			STANDARD,
			HIGH,
			END_OF_ENUM
		};

		class ConvertionParameters
		{
			public DirectoryInfo SrcDir;
			public DirectoryInfo DstDir;
			public TEXTURE_FORMAT TextureFormat;
			public float Scale;
			public TEXTURE_QUALITY TextureQuality;
			public bool NoTrim;

			public int LockNumber = -1;

			public string PlistFileName = null;

			public ConvertionParameters(
				DirectoryInfo srcDir,
				DirectoryInfo dstDir,
				TEXTURE_FORMAT textureFormat = TEXTURE_FORMAT.PNG_INDEXED,
				float scale = 1.0f,
				TEXTURE_QUALITY textureQuality = TEXTURE_QUALITY.STANDARD,
				bool noTrim = false
				)
			{
				this.SrcDir = srcDir;
				this.DstDir = dstDir;
				this.TextureFormat = textureFormat;
				this.Scale = scale;
				this.TextureQuality = textureQuality;
				this.NoTrim = noTrim;
			}
		};

		public PACKING_MODE PackingMode { get; set; }
		public float Scale { get; set; }
		public bool TrimSpriteNames { get; set; }
		public bool SingleLevelOutput { get; set; }

		private static readonly int ProcessorCount = Environment.ProcessorCount;
		private static string[] ConverterLocks;
		private TEXTURE_FORMAT TextureFormat_Alpha_HQ;
		private TEXTURE_FORMAT TextureFormat_Alpha_SQ;
		private TEXTURE_FORMAT TextureFormat_Alpha_LQ;
		private TEXTURE_FORMAT TextureFormat_NoAlpha_HQ;
		private TEXTURE_FORMAT TextureFormat_NoAlpha_SQ;
		private TEXTURE_FORMAT TextureFormat_NoAlpha_LQ;
		private HashSet<ConvertionParameters> TODOs = new HashSet<ConvertionParameters>();

		public TexturePackerCaller(PACKING_MODE packingMode = PACKING_MODE.EDITOR, float scale = 1, bool trimSpriteNames = false, bool singleLevelOutput = false)
		{
			PackingMode = packingMode;
			Scale = scale;
			TrimSpriteNames = trimSpriteNames;
			SingleLevelOutput = singleLevelOutput;

			switch (PackingMode)
			{
				case PACKING_MODE.DESKTOP:
					TextureFormat_Alpha_HQ = TEXTURE_FORMAT.PNG_INDEXED;
					TextureFormat_Alpha_SQ = TEXTURE_FORMAT.WEBP_4444;
					TextureFormat_Alpha_LQ = TEXTURE_FORMAT.WEBP_4444;
					TextureFormat_NoAlpha_HQ = TEXTURE_FORMAT.WEBP_565;
					TextureFormat_NoAlpha_SQ = TEXTURE_FORMAT.WEBP_565;
					TextureFormat_NoAlpha_LQ = TEXTURE_FORMAT.WEBP_565;
					break;
				case PACKING_MODE.IOS:
					TextureFormat_Alpha_HQ = TEXTURE_FORMAT.PNG_INDEXED;
					TextureFormat_Alpha_SQ = TEXTURE_FORMAT.PVR_TC4_ALPHA;
					TextureFormat_Alpha_LQ = TEXTURE_FORMAT.PVR_TC2_ALPHA;
					TextureFormat_NoAlpha_HQ = TEXTURE_FORMAT.WEBP_565;
					TextureFormat_NoAlpha_SQ = TEXTURE_FORMAT.PVR_TC4_NOALPHA;
					TextureFormat_NoAlpha_LQ = TEXTURE_FORMAT.PVR_TC2_NOALPHA;
					break;
				case PACKING_MODE.ANDROID:
					TextureFormat_Alpha_HQ = TEXTURE_FORMAT.PNG_INDEXED;
					TextureFormat_Alpha_SQ = TEXTURE_FORMAT.WEBP_4444;
					TextureFormat_Alpha_LQ = TEXTURE_FORMAT.WEBP_4444;
					TextureFormat_NoAlpha_HQ = TEXTURE_FORMAT.PKM;
					TextureFormat_NoAlpha_SQ = TEXTURE_FORMAT.PKM;
					TextureFormat_NoAlpha_LQ = TEXTURE_FORMAT.PKM;
					break;
				default:
					TextureFormat_Alpha_HQ = TEXTURE_FORMAT.PNG_INDEXED;
					TextureFormat_Alpha_SQ = TEXTURE_FORMAT.PNG_INDEXED;
					TextureFormat_Alpha_LQ = TEXTURE_FORMAT.PNG_INDEXED;
					TextureFormat_NoAlpha_HQ = TEXTURE_FORMAT.JPG_888;
					TextureFormat_NoAlpha_SQ = TEXTURE_FORMAT.JPG_888;
					TextureFormat_NoAlpha_LQ = TEXTURE_FORMAT.JPG_888;
					break;
			}

			if (null == ConverterLocks)
			{
				ConverterLocks = new string[ProcessorCount];

				for (int i = 0; i < ProcessorCount; i++)
				{
					ConverterLocks[i] = Guid.NewGuid().ToString();
				}
			}
		}

		public void ScanDir(DirectoryInfo srcDir, DirectoryInfo dstDir)
		{
			if (SingleLevelOutput)
			{
				ScanDirSingleLevelOutput(srcDir, dstDir);
				return;
			}

			string srcDirFullPath = srcDir.FullName;

			if (!srcDirFullPath.EndsWith("\\"))
			{
				srcDirFullPath += "\\";
			}

			string dstDirFullPath = dstDir.FullName;

			if (!dstDirFullPath.EndsWith("\\"))
			{
				dstDirFullPath += "\\";
			}

			if (srcDir.Name.StartsWith("."))
			{
				return;
			}
			else if (srcDir.Name.EndsWith(".plist"))
			{
				if (dstDir.Name.EndsWith(".plist"))
				{
					dstDir = dstDir.Parent;
				}

				ConvertionParameters parameters = new ConvertionParameters(
					srcDir,
					dstDir,
					TextureFormat_Alpha_SQ,
					Scale);

				bool noAlpha = false;

				foreach (FileInfo subFile in srcDir.GetFiles())
				{
					if ("noalpha.txt" == subFile.Name)
					{
						noAlpha = true;
					}
					else if ("lq.txt" == subFile.Name)
					{
						parameters.TextureQuality = TEXTURE_QUALITY.LOW;
					}
					else if ("hq.txt" == subFile.Name)
					{
						parameters.TextureQuality = TEXTURE_QUALITY.HIGH;
					}
					else if ("notrim.txt" == subFile.Name)
					{
						parameters.NoTrim = true;
					}
				}

				if (noAlpha)
				{
					switch (parameters.TextureQuality)
					{
						case TEXTURE_QUALITY.HIGH:
							parameters.TextureFormat = TextureFormat_NoAlpha_HQ;
							break;
						case TEXTURE_QUALITY.LOW:
							parameters.TextureFormat = TextureFormat_NoAlpha_LQ;
							break;
						default:
							parameters.TextureFormat = TextureFormat_NoAlpha_SQ;
							break;
					}
				}
				else
				{
					switch (parameters.TextureQuality)
					{
						case TEXTURE_QUALITY.HIGH:
							parameters.TextureFormat = TextureFormat_Alpha_HQ;
							break;
						case TEXTURE_QUALITY.LOW:
							parameters.TextureFormat = TextureFormat_Alpha_LQ;
							break;
						default:
							parameters.TextureFormat = TextureFormat_Alpha_SQ;
							break;
					}
				}

				TODOs.Add(parameters);
			}
			else
			{
				DirectoryInfo[] subDirs = srcDir.GetDirectories();

				if (subDirs.Length > 0)
				{
					if (!dstDir.Exists)
					{
						dstDir.Create();
					}

					foreach (DirectoryInfo subDir in srcDir.GetDirectories())
					{
						string dstSubDirFullPath = dstDirFullPath + subDir.Name;
						DirectoryInfo dstSubDir = new DirectoryInfo(dstSubDirFullPath);

						ScanDir(subDir, dstSubDir);
					}
				}
			}
		}

		public void ScanDirSingleLevelOutput(DirectoryInfo srcDir, DirectoryInfo dstDir, string relativePath = "")
		{
			string srcDirFullPath = srcDir.FullName;

			if (!srcDirFullPath.EndsWith("\\"))
			{
				srcDirFullPath += "\\";
			}

			if (!dstDir.Exists)
			{
				dstDir.Create();
			}

			if (srcDir.Name.StartsWith("."))
			{
				return;
			}
			else if (srcDir.Name.EndsWith(".plist"))
			{
				ConvertionParameters parameters = new ConvertionParameters(
					srcDir,
					dstDir,
					TextureFormat_Alpha_SQ,
					Scale);

				parameters.PlistFileName = (0 == relativePath.Length) ? srcDir.Name : relativePath;

				bool noAlpha = false;

				foreach (FileInfo subFile in srcDir.GetFiles())
				{
					if ("noalpha.txt" == subFile.Name)
					{
						noAlpha = true;
					}
					else if ("lq.txt" == subFile.Name)
					{
						parameters.TextureQuality = TEXTURE_QUALITY.LOW;
					}
					else if ("hq.txt" == subFile.Name)
					{
						parameters.TextureQuality = TEXTURE_QUALITY.HIGH;
					}
					else if ("notrim.txt" == subFile.Name)
					{
						parameters.NoTrim = true;
					}
				}

				if (noAlpha)
				{
					switch (parameters.TextureQuality)
					{
						case TEXTURE_QUALITY.HIGH:
							parameters.TextureFormat = TextureFormat_NoAlpha_HQ;
							break;
						case TEXTURE_QUALITY.LOW:
							parameters.TextureFormat = TextureFormat_NoAlpha_LQ;
							break;
						default:
							parameters.TextureFormat = TextureFormat_NoAlpha_SQ;
							break;
					}
				}
				else
				{
					switch (parameters.TextureQuality)
					{
						case TEXTURE_QUALITY.HIGH:
							parameters.TextureFormat = TextureFormat_Alpha_HQ;
							break;
						case TEXTURE_QUALITY.LOW:
							parameters.TextureFormat = TextureFormat_Alpha_LQ;
							break;
						default:
							parameters.TextureFormat = TextureFormat_Alpha_SQ;
							break;
					}
				}

				TODOs.Add(parameters);
			}
			else
			{
				DirectoryInfo[] subDirs = srcDir.GetDirectories();

				foreach (DirectoryInfo subDir in srcDir.GetDirectories())
				{
					ScanDirSingleLevelOutput(subDir, dstDir, (0 == relativePath.Length) ? subDir.Name : (relativePath + "__" + subDir.Name));
				}
			}
		}

		public void DumpTODOs()
		{
			Console.WriteLine("\r\n=== Dirs below will be converted into sprite sheets ===\r\n");

			foreach (ConvertionParameters parameters in TODOs)
			{
				Console.WriteLine(parameters.SrcDir.FullName);
			}

			Console.WriteLine("\r\n======\r\n");
		}

		public void Pack()
		{
			ConvertionParameters[] parametersArray = TODOs.ToArray();

			for (int i = 0; i < parametersArray.Length; i++)
			{
				parametersArray[i].LockNumber = i % ProcessorCount;

				new Thread(new ParameterizedThreadStart(Pack)).Start(parametersArray[i]);
			}
		}

		private void Pack(object convertionParameters)
		{
			ConvertionParameters parameters = (ConvertionParameters)convertionParameters;

			Thread.Sleep(20);

			lock (ConverterLocks[parameters.LockNumber])
			{
				Process processTP = new Process();

				processTP.StartInfo.FileName = "TexturePacker.exe";
				processTP.StartInfo.Arguments = "--quiet " + GetTexturePackerArguments(parameters);

				//将cmd的标准输入和输出全部重定向到.NET的程序里
				processTP.StartInfo.UseShellExecute = false; //此处必须为false否则引发异常

				//processTP.StartInfo.RedirectStandardInput = true; //标准输入
				processTP.StartInfo.RedirectStandardOutput = true; //标准输出

				//不显示命令行窗口界面
				processTP.StartInfo.CreateNoWindow = true;
				processTP.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

				processTP.Start(); //启动进程
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("------");
				sb.AppendLine(parameters.SrcDir.FullName);
				sb.AppendLine(processTP.StandardOutput.ReadToEnd());

				processTP.WaitForExit();
				processTP.Dispose();

				if (null != parameters.PlistFileName)
				{
					string PlistFullPath = getPlistFullPath(parameters);
					string prefix = parameters.PlistFileName.Substring(0, parameters.PlistFileName.Length - ".plist".Length);

					try
					{
						XmlDocument xmlDoc = new XmlDocument();

						xmlDoc.Load(PlistFullPath);

						if (4 >= xmlDoc.ChildNodes[2].ChildNodes[0].ChildNodes.Count)
						{
							XmlNode rootDicNode = xmlDoc.ChildNodes[2].ChildNodes[0];

							for (int i = 0; i < rootDicNode.ChildNodes.Count; i++)
							{
								if ("key" == rootDicNode.ChildNodes[i].Name && "frames" == rootDicNode.ChildNodes[i].InnerText)
								{
									XmlNode frameDicNode = rootDicNode.ChildNodes[++i];

									if (null != frameDicNode)
									{
										foreach (XmlNode frameSubNode in frameDicNode.ChildNodes)
										{
											if ("key" == frameSubNode.Name)
											{
												frameSubNode.InnerText = prefix + "__" + frameSubNode.InnerText;
											}
										}
									}
								}
							}

							XmlElement modifiedNode = xmlDoc.CreateElement("key", xmlDoc.NamespaceURI);
							modifiedNode.InnerText = "Modified";
							xmlDoc.ChildNodes[2].ChildNodes[0].AppendChild(modifiedNode);

							XmlElement trueNode = xmlDoc.CreateElement("true", xmlDoc.NamespaceURI);
							xmlDoc.ChildNodes[2].ChildNodes[0].AppendChild(trueNode);

							xmlDoc.Save(PlistFullPath);
							Thread.Sleep(100);

							byte[] plistContent = null;
							string plistContentString = null;

							using (FileStream fsPlist = File.OpenRead(PlistFullPath))
							{
								FileInfo fiPlist = new FileInfo(PlistFullPath);
								plistContent = new byte[fiPlist.Length];
								fsPlist.Read(plistContent, 0, (int)fiPlist.Length);
							}

							if (0xEF == plistContent[0] && 0xBB == plistContent[1] && 0xBF == plistContent[2])
							{
								plistContentString = Encoding.UTF8.GetString(plistContent, 3, plistContent.Length - 3).Replace("1.0.dtd\"[]>", "1.0.dtd\">");
							}
							else
							{
								plistContentString = Encoding.UTF8.GetString(plistContent).Replace("1.0.dtd\"[]>", "1.0.dtd\">");
							}

							plistContent = Encoding.UTF8.GetBytes(plistContentString);

							using (FileStream fsPlist = File.Create(PlistFullPath))
							{
								fsPlist.Write(plistContent, 0, plistContent.Length);
								fsPlist.Flush();
							}
						}
					}
					catch (Exception ex)
					{
						sb.AppendLine(ex.Message);
					}
				}

				sb.AppendLine("------");
				Console.WriteLine(sb.ToString());
			}
		}
	}
}
