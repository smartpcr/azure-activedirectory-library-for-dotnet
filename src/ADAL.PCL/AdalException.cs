﻿//----------------------------------------------------------------------
// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
// Apache License 2.0
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//----------------------------------------------------------------------

using System;
using System.Globalization;

namespace Microsoft.IdentityModel.Clients.ActiveDirectory
{
    /// <summary>
    /// The exception type thrown when an error occurs during token acquisition.
    /// </summary>
    public class AdalException : Exception
    {
        internal enum ErrorFormat
        {
            Json,
            Other
        }

        /// <summary>
        ///  Initializes a new instance of the exception class.
        /// </summary>
        public AdalException()
            : base(AdalErrorMessage.Unknown)
        {
            this.ErrorCode = AdalError.Unknown;
        }

        /// <summary>
        ///  Initializes a new instance of the exception class with a specified
        ///  error code.
        /// </summary>
        /// <param name="errorCode">The error code returned by the service or generated by client. This is the code you can rely on for exception handling.</param>
        public AdalException(string errorCode)
            : base(GetErrorMessage(errorCode))
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        ///  Initializes a new instance of the exception class with a specified
        ///  error code and error message.
        /// </summary>
        /// <param name="errorCode">The error code returned by the service or generated by client. This is the code you can rely on for exception handling.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public AdalException(string errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        ///  Initializes a new instance of the exception class with a specified
        ///  error code and a reference to the inner exception that is the cause of
        ///  this exception.
        /// </summary>
        /// <param name="errorCode">The error code returned by the service or generated by client. This is the code you can rely on for exception handling.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified. It may especially contain the actual error message returned by the service.</param>
        public AdalException(string errorCode, Exception innerException)
            : base(GetErrorMessage(errorCode), innerException)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        ///  Initializes a new instance of the exception class with a specified
        ///  error code, error message and a reference to the inner exception that is the cause of
        ///  this exception.
        /// </summary>
        /// <param name="errorCode">The error code returned by the service or generated by client. This is the code you can rely on for exception handling.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified. It may especially contain the actual error message returned by the service.</param>
        public AdalException(string errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the protocol error code returned by the service or generated by client. This is the code you can rely on for exception handling.
        /// </summary>
        public string ErrorCode { get; private set; }

        /// <summary>
        /// Creates and returns a string representation of the current exception.
        /// </summary>
        /// <returns>A string representation of the current exception.</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format("\n\tErrorCode: {0}", this.ErrorCode);
        }

        protected static string GetErrorMessage(string errorCode)
        {
            string message;
            switch (errorCode)
            {
                case AdalError.InvalidCredentialType: 
                    message = AdalErrorMessage.InvalidCredentialType;
                    break;

                case AdalError.IdentityProtocolLoginUrlNull:
                    message = AdalErrorMessage.IdentityProtocolLoginUrlNull;
                    break;

                case AdalError.IdentityProtocolMismatch:
                    message = AdalErrorMessage.IdentityProtocolMismatch;
                    break;

                case AdalError.EmailAddressSuffixMismatch:
                    message = AdalErrorMessage.EmailAddressSuffixMismatch;
                    break;

                case AdalError.IdentityProviderRequestFailed:
                    message = AdalErrorMessage.IdentityProviderRequestFailed;
                    break;

                case AdalError.StsTokenRequestFailed:
                    message = AdalErrorMessage.StsTokenRequestFailed;
                    break;

                case AdalError.EncodedTokenTooLong:
                    message = AdalErrorMessage.EncodedTokenTooLong;
                    break;

                case AdalError.StsMetadataRequestFailed:
                    message = AdalErrorMessage.StsMetadataRequestFailed;
                    break;

                case AdalError.AuthorityNotInValidList:
                    message = AdalErrorMessage.AuthorityNotInValidList;
                    break;

                case AdalError.UnknownUserType:
                    message = AdalErrorMessage.UnknownUserType;
                    break;

                case AdalError.UnknownUser:
                    message = AdalErrorMessage.UnknownUser;
                    break;

                case AdalError.UserRealmDiscoveryFailed:
                    message = AdalErrorMessage.UserRealmDiscoveryFailed;
                    break;

                case AdalError.AccessingWsMetadataExchangeFailed:
                    message = AdalErrorMessage.AccessingMetadataDocumentFailed;
                    break;

                case AdalError.ParsingWsMetadataExchangeFailed:
                    message = AdalErrorMessage.ParsingMetadataDocumentFailed;
                    break;

                case AdalError.WsTrustEndpointNotFoundInMetadataDocument:
                    message = AdalErrorMessage.WsTrustEndpointNotFoundInMetadataDocument;
                    break;

                case AdalError.ParsingWsTrustResponseFailed:
                    message = AdalErrorMessage.ParsingWsTrustResponseFailed;
                    break;

                case AdalError.AuthenticationCanceled:
                    message = AdalErrorMessage.AuthenticationCanceled;
                    break;

                case AdalError.NetworkNotAvailable:
                    message = AdalErrorMessage.NetworkIsNotAvailable;
                    break;

                case AdalError.AuthenticationUiFailed:
                    message = AdalErrorMessage.AuthenticationUiFailed;
                    break;

                case AdalError.UserInteractionRequired:
                    message = AdalErrorMessage.UserInteractionRequired;
                    break;

                case AdalError.MissingFederationMetadataUrl:
                    message = AdalErrorMessage.MissingFederationMetadataUrl;
                    break;

                case AdalError.IntegratedAuthFailed:
                    message = AdalErrorMessage.IntegratedAuthFailed;
                    break;

                case AdalError.UnauthorizedResponseExpected:
                    message = AdalErrorMessage.UnauthorizedResponseExpected;
                    break;

                case AdalError.MultipleTokensMatched:
                    message = AdalErrorMessage.MultipleTokensMatched;
                    break;

                case AdalError.PasswordRequiredForManagedUserError:
                    message = AdalErrorMessage.PasswordRequiredForManagedUserError;
                    break;

                case AdalError.GetUserNameFailed:
                    message = AdalErrorMessage.GetUserNameFailed;
                    break;

                default:
                    message = AdalErrorMessage.Unknown;
                    break;
            }

            return String.Format(CultureInfo.InvariantCulture, "{0}: {1}", errorCode, message);
        }
    }
}
