using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace AcadOracle.Common
{
    public class AcadInjector
    {
        private AcadInjector()
        {
        }

        private static Container container;

        public static Container AcadContainer
        {
            get
            {
                if (container == null)
                    container = new Container();

                return container;
            }
        }
    }
}
