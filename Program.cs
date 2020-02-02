using PowerArgs;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TextureBatchPacker
{
	internal class TextureBatchPackerArgs
	{
		[HelpHook, ArgShortcut("?"), ArgDescription("Shows this help.")]
		public bool Help { get; set; }

		[HelpHook, ArgShortcut("--help"), ArgDescription("Shows this help.")]
		public bool ShowHelp { get; set; }

		[HelpHook, ArgShortcut("--version"), ArgDescription("(--version) Print the version info.")]
		public bool ShowVersion { get; set; }

		[ArgDefaultValue("Editor"), ArgDescription("Packing mode - Editor, Desktop, iOS, Android.")]
		public string Mode { get; set; }

		[ArgDefaultValue(1.0), ArgDescription("Scale factor.")]
		public float Scale { get; set; }

		[ArgDefaultValue(false), ArgDescription("Removes image file extensions from the sprite names - e.g. .png, .tga.")]
		public bool TrimSpriteNames { get; set; }

		[ArgDefaultValue(false), ArgShortcut("SLO"), ArgDescription("All PLISTs and sprite sheets will be exported to single direcory.")]
		public bool SingleLevelOutput { get; set; }

		[ArgRequired(PromptIfMissing = false), ArgExistingDirectory, ArgDescription("The input directory.")]
		public string InputDirectory { get; set; }

		[ArgRequired(PromptIfMissing = false), ArgExistingDirectory, ArgDescription("The output directory.")]
		public string OutputDirectory { get; set; }

		public void Main()
		{
			Console.WriteLine("Mode: {0}", Mode);
			Console.WriteLine("Scale: {0}", Scale);
			Console.WriteLine("TrimSpriteNames: {0}", TrimSpriteNames);
			Console.WriteLine("SingleLevelOutput: {0}", SingleLevelOutput);
			Console.WriteLine("InputDirectory: {0}", InputDirectory);
			Console.WriteLine("OutputDirectory: {0}", OutputDirectory);

			TexturePackerCaller texturePackerCaller;
			string strModeLower = Mode.Trim().ToLower();

			switch (strModeLower)
			{
				case "desktop":
					texturePackerCaller = new TexturePackerCaller(TexturePackerCaller.PACKING_MODE.DESKTOP, Scale, TrimSpriteNames, SingleLevelOutput);
					break;
				case "ios":
					texturePackerCaller = new TexturePackerCaller(TexturePackerCaller.PACKING_MODE.IOS, Scale, TrimSpriteNames, SingleLevelOutput);
					break;
				case "android":
					texturePackerCaller = new TexturePackerCaller(TexturePackerCaller.PACKING_MODE.ANDROID, Scale, TrimSpriteNames, SingleLevelOutput);
					break;
				case "raw":
					texturePackerCaller = new TexturePackerCaller(TexturePackerCaller.PACKING_MODE.RAW, Scale, TrimSpriteNames, SingleLevelOutput);
					break;
				default:
					texturePackerCaller = new TexturePackerCaller(TexturePackerCaller.PACKING_MODE.EDITOR, Scale, TrimSpriteNames, SingleLevelOutput);
					break;
			}

			texturePackerCaller.ScanDir(new DirectoryInfo(InputDirectory), new DirectoryInfo(OutputDirectory));
			texturePackerCaller.DumpTODOs();
			texturePackerCaller.Pack();
		}
	}

	internal class Program
	{
		private static int Main(string[] args)
		{
			Console.WriteLine("{0} Ver. {1}", Application.ProductName, Application.ProductVersion);
			Console.WriteLine("Powered by Xin Zhang");
			Console.WriteLine("{0}\r\n", System.IO.File.GetLastWriteTime(Application.ExecutablePath));

			try
			{
				Process processTP = new Process();

				processTP.StartInfo.FileName = "TexturePacker.exe";
				processTP.StartInfo.Arguments = "--version";

				//将cmd的标准输入和输出全部重定向到.NET的程序里
				processTP.StartInfo.UseShellExecute = false; //此处必须为false否则引发异常

				//processTP.StartInfo.RedirectStandardInput = true; //标准输入
				processTP.StartInfo.RedirectStandardOutput = true; //标准输出

				//不显示命令行窗口界面
				processTP.StartInfo.CreateNoWindow = true;
				processTP.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

				processTP.Start(); //启动进程
				Console.WriteLine(processTP.StandardOutput.ReadToEnd());
				processTP.WaitForExit();
				processTP.Dispose();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("TexturePacker not installed.");
#if DEBUG
				Console.ReadKey();
#endif
				return -1;
			}

			try
			{
#if DEBUG
				string[] newArgs =
				{
					"-SLO",
					"True",
					"-I",
					@"E:\Proj\wwii_resource\Res_Input\Packed\images\animations\effect\pvp_effect",
					"-O",
					@"C:\TEMP\out",
					"-S",
					"0.5"
				};

				Args.InvokeMain<TextureBatchPackerArgs>(newArgs);
#else
				Args.InvokeMain<TextureBatchPackerArgs>(args);
#endif
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
#if DEBUG
				Console.ReadKey();
#endif
				return -1;
			}

#if DEBUG
			Console.ReadKey();
#endif

			return 0;
		}
	}
}
