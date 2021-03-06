﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NLog.Common;

namespace ZenMake.Core
{
	public class ZMFile
	{
		public static readonly string DefaultFilename = "project.zm";

		public static readonly string DefaultBuildDir = "zmbin";

		public string FilePath { get; private set; }

		public string FileName { get; private set; }

		public string FileDir { get; private set; }

		public string BuildDir { get; private set; }

		public IList<string> SourceFiles { get; private set; }

		public IList<string> ReferenceFiles { get; private set; }

		public ZMFile(string filepath, string buildDir) : 
			this(filepath, buildDir, Enumerable.Empty<string>(), Enumerable.Empty<string>())
		{
			
		}

		public ZMFile(string filepath, string buildDir, IEnumerable<string> sourceFiles, IEnumerable<string> referenceFiles)
		{
			if (string.IsNullOrWhiteSpace(filepath))
				throw new ArgumentException("filepath is empty. filepath is expected to have a non-empty string value");

			if (string.IsNullOrWhiteSpace(buildDir))
				throw new ArgumentException("buildDir is empty. buildDir is expected to have a non-empty string value");

			if (sourceFiles == null)
				throw new ArgumentNullException("sourceFiles");

			if (referenceFiles == null)
				throw new ArgumentNullException("referenceFiles");

			this.FilePath = filepath;
			this.FileName = Path.GetFileName(this.FilePath);
			this.FileDir = Path.GetDirectoryName(this.FilePath);
			this.BuildDir = buildDir;
			this.SourceFiles = new List<string>(sourceFiles);
			this.ReferenceFiles = new List<string>(referenceFiles);
		}
	}
}