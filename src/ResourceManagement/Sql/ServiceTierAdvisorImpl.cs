// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ResourceManager.Fluent.Core.ResourceActions;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// Implementation for Azure SQL Database's service tier advisor.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TZXJ2aWNlVGllckFkdmlzb3JJbXBs
    internal partial class ServiceTierAdvisorImpl :
        IndexableRefreshableWrapper<IServiceTierAdvisor, ServiceTierAdvisorInner>,
        IServiceTierAdvisor
    {
        private ResourceId resourceId;
        private IDatabasesOperations databasesInner;
        private IReadOnlyList<ISloUsageMetricInterface> sloUsageMetrics;

        ///GENMHASH:0150BB5F92ED226BF84D3AC5255EFE3F:F8EEA9E1BE10E299F96C7CA9D025C464
        public string CurrentServiceLevelObjective()
        {
            return Inner.CurrentServiceLevelObjective.ToString();
        }

        ///GENMHASH:E7ABDAFE895DE30905D46D515062DB59:E469BC0EB728512D322663135CC847D6
        public string DatabaseName()
        {
            return this.resourceId.Parent.Name;
        }

        ///GENMHASH:65C1F2B4C0DC45A99F79FBA42145F773:8E1D9C140BE367F6B48088368DB3CAC2
        public double AvgDtu()
        {
            return Inner.AvgDtu.GetValueOrDefault();
        }

        ///GENMHASH:AA4563C382DF54B43A0F4309F62888BA:6A738B7F6FF6375CC7B92AF08D7B44FA
        public Guid OverallRecommendationServiceLevelObjectiveId()
        {
            return Inner.OverallRecommendationServiceLevelObjectiveId.GetValueOrDefault();
        }

        ///GENMHASH:DF4FB4A6806E7C331047A89BA1F0238A:2CD23C3554E161BCD1FB54EEC384AEF4
        public double MinDtu()
        {
            return Inner.MinDtu.GetValueOrDefault();
        }

        ///GENMHASH:773AEB91BBDF38D9C541399D2AC0907F:996C7874F5F74B384347C1A4C88C89CA
        public Guid DisasterPlanBasedRecommendationServiceLevelObjectiveId()
        {
            return Inner.DisasterPlanBasedRecommendationServiceLevelObjectiveId.GetValueOrDefault();
        }

        ///GENMHASH:7FD5A8D2A26E9E6B12E7585A7DBE1CE3:9055AAEF8F9A4DFD881586C59581634F
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetricInterface> ServiceLevelObjectiveUsageMetrics()
        {
            if (sloUsageMetrics == null)
            {
                Func<SloUsageMetric, ISloUsageMetricInterface> convertor
                    = (sloUsageMetricInner) => 
                    new SloUsageMetricImpl(sloUsageMetricInner);
                sloUsageMetrics = Inner.ServiceLevelObjectiveUsageMetrics.Select(inner => convertor(inner)).ToList();
            }

            return sloUsageMetrics;
        }

        ///GENMHASH:E1D13665116B8ECA351FF7B3C332BAF4:132F6DAA63B96E3D5A5059C74C281394
        public DateTime ObservationPeriodStart()
        {
            return Inner.ObservationPeriodStart.GetValueOrDefault();
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return Inner.Id;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:9FE42D967416923E070F823D07063A47
        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        ///GENMHASH:51288492BC30C9FE517ADAF1E48564C7:A677B0C455E56513C192E43F117D71E1
        internal ServiceTierAdvisorImpl(ServiceTierAdvisorInner innerObject, IDatabasesOperations databasesInner)
            : base(innerObject.Name, innerObject)
        {
            this.resourceId = ResourceId.FromString(Inner.Id);
            this.databasesInner = databasesInner;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:FF9942011B68E005578585933A8D42F2
        public string SqlServerName()
        {
            return this.resourceId.Parent.Parent.Name;
        }

        ///GENMHASH:F06969F30E65390822448213EEDFB046:5F1256734C53E9CBF330B552A20213C0
        public string DatabaseSizeBasedRecommendationServiceLevelObjective()
        {
            return Inner.DatabaseSizeBasedRecommendationServiceLevelObjective;
        }

        ///GENMHASH:595D9B167631FF51CC7B52AA73AD4F18:E2335FCB8EB0CCBB0FE160BCE40C1FE9
        public string OverallRecommendationServiceLevelObjective()
        {
            return Inner.OverallRecommendationServiceLevelObjective;
        }

        ///GENMHASH:EB92BB6EDC4B4487F80DD9429DEA5509:4DB04EC4CBC470E141A1F395C7CA1D8E
        public double Confidence()
        {
            return Inner.Confidence.GetValueOrDefault();
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:B7D07437BD9F8D06E149C9BD7B0F32C2
        protected override async Task<ServiceTierAdvisorInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            sloUsageMetrics = null;
            return await databasesInner.GetServiceTierAdvisorAsync(this.ResourceGroupName(), this.SqlServerName(),
                this.DatabaseName(), this.Name(), cancellationToken: cancellationToken);
        }

        ///GENMHASH:784C4BB3169D35BF6AAE0AF9F79505C7:115090F0342C88D04EA4B5C6E7311E9C
        public Guid UsageBasedRecommendationServiceLevelObjectiveId()
        {
            return Inner.CurrentServiceLevelObjectiveId.GetValueOrDefault();
        }

        ///GENMHASH:6A4CBDC24D036E91928ED09FA5C78F2E:6A7C8ED51763D88CD779061561661698
        public double MaxDtu()
        {
            return Inner.MaxDtu.GetValueOrDefault();
        }

        ///GENMHASH:C4B4BF3321B70686AA3906F2295146C1:C8E7AAD6A3E0CD79087919190171E915
        public DateTime ObservationPeriodEnd()
        {
            return Inner.ObservationPeriodEnd.GetValueOrDefault();
        }

        ///GENMHASH:2C118AADB9C4EED010A789927B901D6A:BF060DDEC8011AFD01DB638A2174B219
        public double ActiveTimeRatio()
        {
            return Inner.ActiveTimeRatio.GetValueOrDefault();
        }

        ///GENMHASH:DABDD303A33B139D98DC627CFC8471F1:859B6E99FC481ED0ECC4624CD2301BC5
        public Guid DatabaseSizeBasedRecommendationServiceLevelObjectiveId()
        {
            return Inner.DatabaseSizeBasedRecommendationServiceLevelObjectiveId.GetValueOrDefault();
        }

        ///GENMHASH:E8CFF2549263DFEF1D66E7C5A23E0B8B:115090F0342C88D04EA4B5C6E7311E9C
        public Guid CurrentServiceLevelObjectiveId()
        {
            return Inner.CurrentServiceLevelObjectiveId.GetValueOrDefault();
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:347C4A0DC579EE33AF5B9736F98AB6D3:BA5EA9151C53BD7F9DC1EF0ADC2C99DD
        public string DisasterPlanBasedRecommendationServiceLevelObjective()
        {
            return Inner.DisasterPlanBasedRecommendationServiceLevelObjective;
        }

        ///GENMHASH:8F2C0FD9ED92422E1653CD9B168DE74D:1022F2613B690C3B6549E375732B361D
        public double MaxSizeInGB()
        {
            return Inner.MaxSizeInGB.GetValueOrDefault();
        }

        ///GENMHASH:FEAD40466D37AC29DF1AA732E22DFE2A:4AC68885628AFFBD6798B2CAB843E711
        public string UsageBasedRecommendationServiceLevelObjective()
        {
            return Inner.UsageBasedRecommendationServiceLevelObjective;
        }
    }
}
