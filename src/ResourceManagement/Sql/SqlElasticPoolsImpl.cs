// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.CollectionActions;
    using Models;
    using ResourceManager.Fluent.Core.ResourceActions;
    using SqlElasticPool.Definition;
    using SqlElasticPools.SqlElasticPoolsCreatable;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SQLElasticPools and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxFbGFzdGljUG9vbHNJbXBs
    internal partial class SqlElasticPoolsImpl :
        IndependentChildResourcesImpl<ISqlElasticPool, SqlElasticPoolImpl, ElasticPoolInner, IElasticPoolsOperations, ISqlManager, ISqlServer>,
        ISqlElasticPoolsCreatable,
        ISupportsGettingByParent<ISqlElasticPool, ISqlServer, ISqlManager>,
        ISupportsListingByParent<ISqlElasticPool, ISqlServer, ISqlManager>
    {
        private DatabasesImpl databasesImpl;

        ///GENMHASH:6158E90616ED656250810DD9EA3AF43D:FC3289EBFE181908C7E255B60F92AE02
        internal SqlElasticPoolsImpl(ISqlManager manager, DatabasesImpl databasesImpl)
            : base(manager.Inner.ElasticPools, manager)
        {
            this.databasesImpl = databasesImpl;
        }

        ///GENMHASH:16CEA22B57032A6757D8EFC1BF423794:F46E4D0A3CDB6C5AE412BF5B7FB52B09
        public IReadOnlyList<ISqlElasticPool> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return new List<ISqlElasticPool>(this.ListByParent(resourceGroupName, sqlServerName));
        }

        ///GENMHASH:CD989F8A79EC70D56C4F5154E2B8BE11:57462F0C7FF757AFBBFD3B3561C9F9ED
        public IReadOnlyList<ISqlElasticPool> ListBySqlServer(ISqlServer sqlServer)
        {
            return new List<ISqlElasticPool>(this.ListByParent(sqlServer));
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:7F70CB1AA5FE23578E360B95D229A1C6
        public async override Task<IPagedCollection<ISqlElasticPool>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ISqlElasticPool, ElasticPoolInner>.LoadPage(
                async (cancellation) => await Inner.ListByServerAsync(resourceGroupName, parentName, cancellation),
                WrapModel, cancellationToken);
        }

        ///GENMHASH:03C6F391A16F96A5127D98827B5423FA:877F7B73190881879934925547D57EAF
        public ISqlElasticPool GetBySqlServer(string resourceGroup, string sqlServerName, string name)
        {
            return this.GetByParent(resourceGroup, sqlServerName, name);
        }

        ///GENMHASH:6B5394D9B9C62E3B4A3B037DD27B7A20:466DF29CB4850E0593B3C691F625BC2C
        public ISqlElasticPool GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return this.GetByParent(sqlServer, name);
        }

        ///GENMHASH:1F414E796475F1DA7286F29E3E27589D:1056648A6B4A4D9B6EA5F5AC88AE4C12
        public async override Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(groupName, parentName, name, cancellationToken);
        }

        ///GENMHASH:E3353FA0F9E79B667402107BE3CC7CC3:C2CAD38DE0065D9787A2B130E2E189DD
        public ICreatable<ISqlElasticPool> DefinedWithSqlServer(string resourceGroupName, string sqlServerName, string elasticPoolName, Region region)
        {
            ElasticPoolInner inner = new ElasticPoolInner();
            inner.Location = region.ToString();

            return new SqlElasticPoolImpl(
                elasticPoolName,
                inner,
                databasesImpl,
                Manager).WithExistingParentResource(resourceGroupName, sqlServerName);
        }

        ///GENMHASH:C32C5A59EBD92E91959156A49A8C1A95:36E87C79062474D6AB62B46DAD7396F9
        public async override Task<ISqlElasticPool> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await Inner.GetAsync(resourceGroup, parentName, name, cancellationToken));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:FF6BFE823C484002AD01D6D9749F22DA
        protected override SqlElasticPoolImpl WrapModel(string name)
        {
            ElasticPoolInner inner = new ElasticPoolInner();
            return new SqlElasticPoolImpl(
                name,
                inner,
                databasesImpl,
                Manager);
        }

        ///GENMHASH:65E1EEA76A912450419ABE12725FBF0C:C1932F9E97EA48EA7DFD2036427E4E31
        protected override ISqlElasticPool WrapModel(ElasticPoolInner inner)
        {
            return (inner != null) ? new SqlElasticPoolImpl(inner.Name, inner, databasesImpl, Manager) : null;
        }
    }
}
