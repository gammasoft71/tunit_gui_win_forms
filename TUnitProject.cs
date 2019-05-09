using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunit_gui {
  class TUnitProject {
    public TUnitProject() {
      Name = "Project 1";
      Files = new string[0];
      Description = "";
      Saved = false;
    }

    public string Name {
      get { return this.name; }
      set {
        if (this.name != value) {
          this.name = value;
          this.Saved = false;
        }
      }
    }

    public string[] Files {
      get { return this.files; }
      set {
        if (this.files != value)
        {
          this.files = value;
          this.Saved = false;
        }
      }
    }

    public string Description {
      get { return this.description; }
      set {
        if (this.description != value) {
          this.description = value;
          this.Saved = false;
        }
      }
    }
    public bool Saved { get; set; }

    public static TUnitProject Read(System.IO.Stream stream) {
      System.IO.StreamReader sr = new System.IO.StreamReader(stream);
      TUnitProject tunitProject = new TUnitProject();
      while (!sr.EndOfStream) {
        string[] keyValue = sr.ReadLine().Split(new char[] { '=' });
        switch (keyValue[0]) {
          case "Description": tunitProject.Description = keyValue[1]; break;
          case "Name": tunitProject.Name = keyValue[1]; break;
          case "Files": tunitProject.Files = keyValue[1].Split(new char[] { System.IO.Path.PathSeparator }, StringSplitOptions.RemoveEmptyEntries); break;
          default: throw new System.ArgumentException();
        }
      }

      tunitProject.Saved = true;
      return tunitProject;
    }

    public static TUnitProject Read(string fileName) {return Read(System.IO.File.OpenRead(fileName));}

    public static void Write(System.IO.Stream stream, TUnitProject tunitProject) {
      System.IO.StreamWriter sw = new System.IO.StreamWriter(stream);
      sw.WriteLine($"Description={tunitProject.Description}");
      sw.WriteLine($"Name={tunitProject.Name}");
      sw.WriteLine($"Files={String.Join(System.IO.Path.PathSeparator.ToString(), tunitProject.Files)}");
      tunitProject.Saved = true;
      sw.Close();
    }

    public static void Write(string fileName, TUnitProject tunitProject) {Write(System.IO.File.Create(fileName), tunitProject);}

    private string name;
    private string description;
    private string[] files;
  }
}
