// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation of an application gateway backend.
    /// </summary>
    public interface IApplicationGatewayBackend  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ApplicationGatewayBackendAddressPoolInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.Network.Fluent.IHasBackendNics
    {
        /// <summary>
        /// Gets addresses on the backend of the application gateway.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ApplicationGatewayBackendAddress> Addresses { get; }

        /// <summary>
        /// Checks whether the specified IP address is referenced by this backend address pool.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>True if the specified IP address is referenced by this backend, else false.</return>
        bool ContainsIPAddress(string ipAddress);

        /// <summary>
        /// Checks whether the specified FQDN is referenced by this backend address pool.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>True if the specified FQDN is referenced by this backend, else false.</return>
        bool ContainsFqdn(string fqdn);
    }
}