﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenMake.Core;

namespace ZenMake.Modules.ProjectModule
{
	public class ProjectAddArg : RequestArg
	{
		public IList<string> Files { get; private set; }
		
		public ProjectAddArg(string projectFilename, IList<string> files) : base(projectFilename)
		{
			if (files == null)
				throw new ArgumentNullException("files");

			this.Files = new List<string>(files);
		}
	}
}