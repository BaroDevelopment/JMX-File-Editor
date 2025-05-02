using JMXFileEditor.Silkroad.Data.JMXVRES;
using JMXFileEditor.Silkroad.Data.JMXVRES.ModData;

namespace JMXFileEditor.ViewModels.Silkroad.JMXVRES
{
    public class ModDataSetVM : JMXStructure
    {
        #region Constructor
        public ModDataSetVM(string Name, ModDataSet DataSet) : base(Name, true)
        {
            // Add new format
            m_SupportedFormats.Add(typeof(IModData), (s, e) => {
                e.Childs.Add(new ModDataVM("[" + e.Childs.Count + "]",
                    JMXAbstract.GetTypes(
                        typeof(ModDataMtrl),
                        typeof(ModDataTexAni),
                        typeof(ModDataMultiTex),
                        typeof(ModDataMultiTexRev),
                        typeof(ModDataParticle),
                        typeof(ModDataEnvMap),
                        typeof(ModDataBumpEnv),
                        typeof(ModDataSound),
                        typeof(ModDataDyVertex),
                        typeof(ModDataDyJoint),
                        typeof(ModDataDyLattice),
                        typeof(ModDataProgEquipPow)),
                    e.Obj?.GetType(), e.Obj));
            });
            // Create nodes
            Childs.Add(new JMXOption("Type", DataSet.Type, JMXOption.GetValues<object>(typeof(ModDataSetType))));
            Childs.Add(new JMXOption("AnimationType", DataSet.AnimationType, JMXOption.GetValues<object>(typeof(PrimAnimationType))));
            Childs.Add(new JMXAttribute("Name", DataSet.Name));
            AddChildArray("ModsData", DataSet.ModData.ToArray(), true, true);
        }
        #endregion

        #region Public Methods
        public override object GetClassFrom(JMXStructure Structure)
        {
            ModDataSet obj = new ModDataSet()
            {
                Type = (ModDataSetType)((JMXOption)Structure.Childs[0]).Value,
                AnimationType = (PrimAnimationType)((JMXOption)Childs[1]).Value,
                Name = (string)((JMXAttribute)Structure.Childs[2]).Value,
                ModData = ((JMXStructure)Structure.Childs[3]).GetChildList<IModData>()
            };
            return obj;
        }
        #endregion
    }
}