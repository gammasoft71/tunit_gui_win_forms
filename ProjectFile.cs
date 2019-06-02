using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunit {
  public class ProjectFile {
    public ProjectFile() {
      Name = "Project 1";
      UnitTests = new string[0];
      Description = "";
      Saved = false;
    }

    public ProjectFile(string name) {
      Name = name;
      UnitTests = new string[0];
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

    public string[] UnitTests {
      get { return this.unitTests; }
      set {
        if (this.unitTests != value)
        {
          this.unitTests = value;
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

    public static ProjectFile Read(System.IO.Stream stream) {
      System.IO.StreamReader sr = new System.IO.StreamReader(stream);
      ProjectFile file = new ProjectFile();
      while (!sr.EndOfStream) {
        string[] keyValue = sr.ReadLine().Split(new char[] { '=' });
        switch (keyValue[0]) {
          case "Description": file.Description = keyValue[1]; break;
          case "Name": file.Name = keyValue[1]; break;
          case "UnitTests": file.UnitTests = keyValue[1].Split(new char[] { System.IO.Path.PathSeparator }, StringSplitOptions.RemoveEmptyEntries); break;
          default: throw new System.ArgumentException();
        }
      }
      sr.Close();

      file.Saved = true;
      return file;
    }

    public static ProjectFile Read(string fileName) {return Read(System.IO.File.OpenRead(fileName));}

    public static void Write(System.IO.Stream stream, ProjectFile file) {
      System.IO.StreamWriter sw = new System.IO.StreamWriter(stream);
      sw.WriteLine($"Description={file.Description}");
      sw.WriteLine($"Name={file.Name}");
      sw.WriteLine($"UnitTests={String.Join(System.IO.Path.PathSeparator.ToString(), file.UnitTests)}");
      file.Saved = true;
      sw.Close();
    }

    public static void Write(string fileName, ProjectFile file) {Write(System.IO.File.Create(fileName), file);}

    private string name;
    private string description;
    private string[] unitTests;
  }
}
