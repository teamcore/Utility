using System;
using Aprimo.Utility.Framework.Data.Contract;
using Aprimo.Utility.Framework.Exceptions;

namespace Aprimo.Utility.Framework.DomainModel.Counter
{
    public class CounterUtility
    {
        private static readonly IRepository<Identity> repository;

        /// <summary>
        /// Initializes the <see cref="CounterUtility"/> class.
        /// </summary>
        static CounterUtility()
        {
            repository = EngineContext.Current.Resolve<IRepository<Identity>>();
        }

        /// <summary>
        /// Nexts the number.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static int NextNumber(string key)
        {
            int number;
            lock (repository)
            {
                Identity identity = repository.FindOne(x => x.Name == key);

                if (identity == null) throw new CounterNotFoundException();
                
                number = identity.NextNumber();
                repository.Update(identity);
            }
            return number;
        }

        protected static void DefaultSetup(string key)
        {
            var identity = repository.FindOne(x => x.Name == key);
            if (identity == null)
            {
                identity = new Identity();
                identity.Name = key;
                identity.Value = 0;
                identity.Seed = 1;
                identity.Increment = 1;
                identity.Max = 999;
                identity.ResetFrequency = ResetOption.OnMax;
                identity.LastResetDate = DateTime.UtcNow.Date;
                repository.Update(identity);
            }
        }
    }
}
