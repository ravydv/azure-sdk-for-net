// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Media.Models
{
    /// <summary> Represents a video track in the asset. </summary>
    public partial class VideoTrack : TrackBase
    {
        /// <summary> Initializes a new instance of VideoTrack. </summary>
        public VideoTrack()
        {
            OdataType = "#Microsoft.Media.VideoTrack";
        }

        /// <summary> Initializes a new instance of VideoTrack. </summary>
        /// <param name="odataType"> The discriminator for derived types. </param>
        internal VideoTrack(string odataType) : base(odataType)
        {
            OdataType = odataType ?? "#Microsoft.Media.VideoTrack";
        }
    }
}
