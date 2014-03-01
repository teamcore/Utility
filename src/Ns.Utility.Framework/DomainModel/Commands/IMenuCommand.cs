using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ns.Utility.Framework.DomainModel.Commands
{
    public interface IMenuCommand : IDomainRightCommand
    {
        /// <summary>
        /// Gets the name of the menu.
        /// </summary>
        /// <value>
        /// The name of the menu.
        /// </value>
        string MenuName { get; }
    }
}
