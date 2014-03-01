using System.Runtime.Serialization;

namespace Ns.Utility.Framework.DomainModel.Counter
{
    [DataContract]
    public enum ResetOption
    {
        /// <summary>
        /// Reset occours on maximum limit and is default option
        /// </summary>
        [EnumMember]
        OnMax = 0,

        /// <summary>
        /// Reset occours daily basis.
        /// </summary>
        [EnumMember]
        Daily = 1,

        /// <summary>
        /// Reset occours on weekly basis.
        /// </summary>
        [EnumMember]
        Weekly = 7,

        /// <summary>
        /// Reset occours on monthly basis.
        /// </summary>
        [EnumMember]
        Monthly = 30,

        /// <summary>
        /// Reset occours on yearly basis.
        /// </summary>
        [EnumMember]
        Yearly = 365
    }
}
