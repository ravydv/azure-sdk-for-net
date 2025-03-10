// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Media;

namespace Azure.ResourceManager.Media.Models
{
    /// <summary> A collection of AccountFilter items. </summary>
    internal partial class AccountFilterCollection
    {
        /// <summary> Initializes a new instance of AccountFilterCollection. </summary>
        internal AccountFilterCollection()
        {
            Value = new ChangeTrackingList<AccountFilterData>();
        }

        /// <summary> Initializes a new instance of AccountFilterCollection. </summary>
        /// <param name="value"> A collection of AccountFilter items. </param>
        /// <param name="odataNextLink"> A link to the next page of the collection (when the collection contains too many results to return in one response). </param>
        internal AccountFilterCollection(IReadOnlyList<AccountFilterData> value, string odataNextLink)
        {
            Value = value;
            OdataNextLink = odataNextLink;
        }

        /// <summary> A collection of AccountFilter items. </summary>
        public IReadOnlyList<AccountFilterData> Value { get; }
        /// <summary> A link to the next page of the collection (when the collection contains too many results to return in one response). </summary>
        public string OdataNextLink { get; }
    }
}
