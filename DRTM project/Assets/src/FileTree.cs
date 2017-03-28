using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileTree {

	public readonly string name;
	public readonly List<string> files;
	public readonly List<FileTree> directory;

	public FileTree(string name,string path){
		this.name = name;
		files = new List<string> ();
		directory = new List<FileTree>();
		this.lookForFiles(path);
	}

	public void lookForFiles(string path){
		files.AddRange(Directory.GetFiles(path));
	
		foreach (string dir in Directory.GetDirectories(path)) {
			this.directory.Add (new FileTree(dir,dir));
		}
	}

	public List<string> getPaths(){
		List<string> list = new List<string>();
		list.AddRange(files);
		foreach (FileTree ft in directory) {
			list.AddRange(ft.getPaths());
		}
		return list;
	}

	public string ToString(){
		string s = "\n"+this.name;
		foreach (string file in files)
			s += "\n file:" + file;
		foreach (FileTree ft in directory)
			s += ft.ToString();
		return s+"\n";
	}

}
