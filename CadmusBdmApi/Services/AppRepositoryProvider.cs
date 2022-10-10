﻿using System;
using System.Reflection;
using Cadmus.Core;
using Cadmus.Core.Config;
using Cadmus.Core.Storage;
using Cadmus.Mongo;
using Cadmus.General.Parts;
using Cadmus.Philology.Parts;

namespace CadmusBdmApi.Services
{
    /// <summary>
    /// Application's repository provider.
    /// </summary>
    public sealed class AppRepositoryProvider : IRepositoryProvider
    {
        private readonly IPartTypeProvider _partTypeProvider;

        /// <summary>
        /// The connection string.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppRepositoryProvider"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">configuration</exception>
        public AppRepositoryProvider()
        {
            TagAttributeToTypeMap map = new();
            map.Add(new[]
            {
                // Cadmus.Seed.General.Parts
                typeof(NotePart).GetTypeInfo().Assembly,
                // Cadmus.Philology.Parts
                typeof(ApparatusLayerFragment).GetTypeInfo().Assembly
            });

            _partTypeProvider = new StandardPartTypeProvider(map);
        }

        /// <summary>
        /// Gets the part type provider.
        /// </summary>
        /// <returns>part type provider</returns>
        public IPartTypeProvider GetPartTypeProvider()
        {
            return _partTypeProvider;
        }

        /// <summary>
        /// Creates a Cadmus repository.
        /// </summary>
        /// <returns>repository</returns>
        public ICadmusRepository CreateRepository()
        {
            // create the repository (no need to use container here)
            MongoCadmusRepository repository =
                new(
                    _partTypeProvider,
                    new StandardItemSortKeyBuilder());

            repository.Configure(new MongoCadmusRepositoryOptions
            {
                ConnectionString = ConnectionString ??
                throw new InvalidOperationException(
                    "No connection string set for IRepositoryProvider implementation")
            });

            return repository;
        }
    }
}
