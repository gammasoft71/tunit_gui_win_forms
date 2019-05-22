using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunit {
  public class TUnitProjectEventArgs : EventArgs {
    public TUnitProjectEventArgs(TUnitProject tunitProject) { this.tunitProject = tunitProject; }

    public TUnitProject TUnitProject {
      get { return this.tunitProject; }
    }

    private TUnitProject tunitProject;
  }

  public delegate void TUnitProjectEventHandler(object sender, TUnitProjectEventArgs e);
}
