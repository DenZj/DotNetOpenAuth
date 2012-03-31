﻿//-----------------------------------------------------------------------
// <copyright file="TokenEndpointProtocolException.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOpenAuth.OAuth2 {
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	using DotNetOpenAuth.Messaging;

	/// <summary>
	/// Describes an error generated by an Authorization Server's token endpoint.
	/// </summary>
	public class TokenEndpointProtocolException : ProtocolException {
		/// <summary>
		/// Initializes a new instance of the <see cref="TokenEndpointProtocolException"/> class.
		/// </summary>
		/// <param name="error">A single error code from <see cref="Protocol.AccessTokenRequestErrorCodes"/>.</param>
		/// <param name="description">A human-readable UTF-8 encoded text providing additional information, used to assist the client developer in understanding the error that occurred.</param>
		/// <param name="moreInformation">A URI identifying a human-readable web page with information about the error, used to provide the client developer with additional information about the error.</param>
		public TokenEndpointProtocolException(string error, string description = null, Uri moreInformation = null)
			: base(string.Format(CultureInfo.CurrentCulture, ClientAuthorizationStrings.TokenEndpointErrorFormat, error, description)) {
			Requires.NotNullOrEmpty(error, "error");

			this.Error = error;
			this.Description = description;
			this.MoreInformation = moreInformation;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TokenEndpointProtocolException"/> class.
		/// </summary>
		/// <param name="innerException">The inner exception.</param>
		public TokenEndpointProtocolException(Exception innerException)
			: base(Protocol.AccessTokenRequestErrorCodes.InvalidRequest, innerException) {
			this.Error = Protocol.AccessTokenRequestErrorCodes.InvalidRequest;
		}

		/// <summary>
		/// Gets a single error code from <see cref="Protocol.AccessTokenRequestErrorCodes"/>.
		/// </summary>
		public string Error { get; private set; }

		/// <summary>
		/// Gets a human-readable UTF-8 encoded text providing additional information, used to assist the client developer in understanding the error that occurred.
		/// </summary>
		public string Description { get; private set; }

		/// <summary>
		/// Gets a URI identifying a human-readable web page with information about the error, used to provide the client developer with additional information about the error.
		/// </summary>
		public Uri MoreInformation { get; private set; }
	}
}
