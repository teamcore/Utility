using System;
using Aprimo.Utility.Framework.Constant;
using Aprimo.Utility.Framework.Extension;

namespace Aprimo.Utility.Framework.DomainModel.Counter
{
    public class Identity : Entity
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [DomainSignature]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [DomainSignature]
        public virtual int Value { get; set; }

        /// <summary>
        /// Gets or sets the seed.
        /// </summary>
        /// <value>
        /// The seed.
        /// </value>
        [DomainSignature]
        public virtual int Seed { get; set; }

        /// <summary>
        /// Gets or sets the increment.
        /// </summary>
        /// <value>
        /// The increment.
        /// </value>
        [DomainSignature]
        public virtual int Increment { get; set; }

        /// <summary>
        /// Gets or sets the max.
        /// </summary>
        /// <value>
        /// The max.
        /// </value>
        [DomainSignature]
        public virtual int Max { get; set; }

        /// <summary>
        /// Gets or sets the reset frequency.
        /// </summary>
        /// <value>
        /// The reset frequency.
        /// </value>
        [DomainSignature]
        public virtual ResetOption ResetFrequency { get; set; }

        /// <summary>
        /// Gets or sets the last reset date.
        /// </summary>
        /// <value>
        /// The last reset date.
        /// </value>
        [DomainSignature]
        public virtual DateTime LastResetDate { get; set; }


        /// <summary>
        /// Nexts the number.
        /// </summary>
        /// <returns></returns>
        public virtual int NextNumber()
        {
            Reset(ResetFrequency);
            Value += Increment; 
            return Value;
        }

        /// <summary>
        /// Resets the specified option.
        /// </summary>
        /// <param name="option">The option.</param>
        public virtual void Reset(ResetOption option)
        {
            DateTime currentDate = DateTime.UtcNow.Date;
            DateTime lastResetDate = LastResetDate.Date;
            switch (option)
            {
                case ResetOption.OnMax:
                    if (Value >= Max)
                    {
                        Value = Seed;
                        LastResetDate = currentDate;
                    }
                    break;
                case ResetOption.Daily:
                    if (currentDate.Subtract(lastResetDate) > TimeSpan.Zero)
                    {
                        Value = Seed;
                        LastResetDate = currentDate;
                    }
                    break;
                case ResetOption.Weekly:
                    var firstDateOfWeek = currentDate.GetFirstDateOfWeek();
                    if (currentDate.Subtract(firstDateOfWeek) == TimeSpan.Zero)
                    {
                        Value = Seed;
                        LastResetDate = currentDate;
                    }
                    break;
                
                case ResetOption.Monthly:
                    var firstDateOfMonth = currentDate.GetFirstDateOfMonth();
                    if (currentDate.Subtract(firstDateOfMonth) == TimeSpan.Zero)
                    {
                        Value = Seed;
                        LastResetDate = currentDate;
                    }
                    break;
                
                case ResetOption.Yearly:
                    var firstDateOfYear = new DateTime(currentDate.Year, 1, 1);
                    if (currentDate.Subtract(firstDateOfYear) == TimeSpan.Zero)
                    {
                        Value = Seed;
                        LastResetDate = currentDate;
                    }
                    break;
                
                default:
                    if (Value >= Max)
                    {
                        Value = Seed;
                        LastResetDate = currentDate;
                    }
                    break;
            }
        }
    }
}
