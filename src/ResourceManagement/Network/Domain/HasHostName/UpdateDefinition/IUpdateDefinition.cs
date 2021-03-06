// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasHostName.UpdateDefinition
{
    /// <summary>
    /// The stage of a definition allowing to specify a host name.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithHostName<ReturnT> 
    {
        /// <summary>
        /// Specifies the host name to reference.
        /// </summary>
        /// <param name="hostName">An existing host name.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithHostName(string hostName);
    }
}