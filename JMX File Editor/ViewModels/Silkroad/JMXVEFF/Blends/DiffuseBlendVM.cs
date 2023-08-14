﻿using JMXFileEditor.Silkroad.Data.JMXVEFF.Blends;
using JMXFileEditor.ViewModels.Silkroad.Mathematics;

namespace JMXFileEditor.ViewModels.Silkroad.JMXVEFF.Blends
{
    public class DiffuseBlendVM : JMXStructure
    {
        #region Constructor
        public DiffuseBlendVM(string Name, DiffuseBlend data) : base(Name, true)
        {
            Childs.Add(new JMXAttribute("Time", data.Time));
            Childs.Add(new ColorVM("Value", ColorVM.GetColor(data.Value)));
        }
        #endregion

        #region Public Methods
        public override object GetClassFrom(JMXStructure s, int i)
        {
            return new DiffuseBlend()
            {
                Time = (float)((JMXAttribute)s.Childs[i++]).Value,
                Value = ((ColorVM)s.Childs[i++]).GetColor32(),
            };
        }
        #endregion
    }
}
