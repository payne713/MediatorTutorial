using System;
using System.Collections.Generic;

namespace Project.Infrastructure.MediatR.Extensions
{
    public class MediatorDescriptionOptions
    {
        /// <summary>
        /// Startup‘s class type
        /// </summary>
        public Type StartupClassType { get; set; }

        /// <summary>
        /// The assemblies which contains mediator classes
        /// </summary>
        public IEnumerable<string> Assembly { get; set; }
    }
}