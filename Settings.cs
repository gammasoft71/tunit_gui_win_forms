using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunit {
  class Settings {
    public static Settings Default { 
      get { return defaultSettings; }
    }

    public bool AlsoRunIgnoredTests { get; set; }

    public bool ShuffleTests { get; set; }

    public int RandomSeed { get; set; }

    public bool RepeatForEver { get; set; }

    public int RepeatTests { 
      get { return repeatTests; }
      set { repeatTests = value; } 
    }

    private Settings() { 

    }

    private static Settings defaultSettings = new Settings();
    private int repeatTests = 1;
  }
}
