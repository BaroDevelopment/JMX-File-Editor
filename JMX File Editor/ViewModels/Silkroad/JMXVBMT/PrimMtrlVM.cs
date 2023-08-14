﻿using JMXFileEditor.Silkroad.Data.JMXVBMT;
using JMXFileEditor.Silkroad.Mathematics;
using JMXFileEditor.ViewModels.Silkroad.Mathematics;

namespace JMXFileEditor.ViewModels.Silkroad.JMXVBMT
{
    public class PrimMtrlVM : JMXStructure
    {
        #region Constructor
        public PrimMtrlVM(string Name, PrimMtrl Mtrl) : base(Name, true)
        {
            Childs.Add(new JMXAttribute("Name", Mtrl.Name));
            Childs.Add(new ColorVM("Diffuse", ColorVM.GetColor(Mtrl.Diffuse)));
            Childs.Add(new ColorVM("Ambient", ColorVM.GetColor(Mtrl.Ambient)));
            Childs.Add(new ColorVM("Specular", ColorVM.GetColor(Mtrl.Specular)));
            Childs.Add(new ColorVM("Emissive", ColorVM.GetColor(Mtrl.Emissive)));
            Childs.Add(new JMXAttribute("UnkFloat01", Mtrl.UnkFloat01));
            Childs.Add(new JMXAttribute("Flags", Mtrl.Flags));
            Childs.Add(new JMXAttribute("DiffuseMapPath", Mtrl.DiffuseMapPath));
            Childs.Add(new JMXAttribute("UnkFloat02", Mtrl.UnkFloat02));
            Childs.Add(new JMXAttribute("UnkByte01", Mtrl.UnkByte01));
            Childs.Add(new JMXAttribute("UnkByte02", Mtrl.UnkByte02));
            Childs.Add(new JMXAttribute("IsAbsolutePath", Mtrl.IsAbsolutePath));
            Childs.Add(new JMXAttribute("NormalMapPath", Mtrl.NormalMapPath));
            Childs.Add(new JMXAttribute("UnkUInt01", Mtrl.UnkUInt01));
        }
        #endregion

        #region Public Methods
        public override object GetClassFrom(JMXStructure s, int i)
        {
            return new PrimMtrl()
            {
                Name = (string)((JMXAttribute)s.Childs[i++]).Value,
                Diffuse = ((ColorVM)s.Childs[i++]).GetColor4(),
                Ambient = ((ColorVM)s.Childs[i++]).GetColor4(),
                Specular = ((ColorVM)s.Childs[i++]).GetColor4(),
                Emissive = ((ColorVM)s.Childs[i++]).GetColor4(),
                UnkFloat01 = (float)((JMXAttribute)s.Childs[i++]).Value,
                Flags = (uint)((JMXAttribute)s.Childs[i++]).Value,
                DiffuseMapPath = (string)((JMXAttribute)s.Childs[i++]).Value,
                UnkFloat02 = (float)((JMXAttribute)s.Childs[i++]).Value,
                UnkByte01 = (byte)((JMXAttribute)s.Childs[i++]).Value,
                UnkByte02 = (byte)((JMXAttribute)s.Childs[i++]).Value,
                IsAbsolutePath = (bool)((JMXAttribute)s.Childs[i++]).Value,
                NormalMapPath = (string)((JMXAttribute)s.Childs[i++]).Value,
                UnkUInt01 = (uint)((JMXAttribute)s.Childs[i++]).Value
            };
        }
        #endregion
    }
}
