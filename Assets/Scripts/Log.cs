using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public static class Log {
	public static bool gravar(Exception ex)
	{
		string logName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
		using (StreamWriter escritor = new StreamWriter(logName, true))
		{
			StringBuilder log = new StringBuilder();
			log.Append("Data: ");
			log.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"));
			log.Append(Environment.NewLine);
			log.Append("Mensagem: ");
			log.Append(ex.Message);
			log.Append(Environment.NewLine);
			log.Append("StackTrace: ");
			log.Append(ex.StackTrace);
			log.Append(Environment.NewLine);
			log.Append("InnerException: ");
			log.Append(ex.InnerException);
			log.Append(Environment.NewLine);
			log.Append("Source: ");
			log.Append(ex.Source);
			log.Append(Environment.NewLine);
			log.Append("TargetSite: ");
			log.Append(ex.TargetSite);
			escritor.WriteLine(log.ToString());
		}
		return true;
	}
}
