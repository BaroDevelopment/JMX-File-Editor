﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace JMXFileEditor.ViewModels
{
    /// <summary>
    /// ViewModel representing a strict variable in the structure
    /// </summary>
    public class JMXOption : JMXProperty
    {
        #region Private Members
        private object m_Value;
        #endregion

        #region Public Properties
        /// <summary>
        /// Value handled by this node
        /// </summary>
        public object Value
        {
            get => m_Value;
            set
            {
                // Check if value can be edited and is one of the options
                if (IsEditable && Options.Contains(Value))
                {
                    // Make sure the new value can be converted to the original value
                    var valueType = Value.GetType();
                    if (valueType.IsEnum)
                    {
                        m_Value = Enum.Parse(valueType, value.ToString(), true);
                    }
                    else
                    {
                        m_Value = Convert.ChangeType(value, valueType);
                    }
                    OnPropertyChanged(nameof(Value));
                }
            }
        }
        /// <summary>
        /// All possibilities the value can have
        /// </summary>
        public List<object> Options { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a child node view model
        /// </summary>
        public JMXOption(string Name, object Value, List<object> Options, bool IsEditable = true) : base(Name, IsEditable)
        {
            m_Value = Value;
            this.Options = Options;
            this.Options.Sort((a,b) => a.ToString().CompareTo(b.ToString()));
        }
        #endregion

        #region Public Static Helpers
        /// <summary>
        /// Get all the values from the enum type specified as array list
        /// </summary>
        public static List<T> GetValues<T>(Type EnumType)
        {
            return Enum.GetValues(EnumType).Cast<T>().ToList();
        }
        #endregion
    }
}
