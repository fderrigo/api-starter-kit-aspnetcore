/*
 * Ora esatta.
 *
 * #### Documentazione Il servizio Ora esatta ritorna l'ora del server in formato RFC5424 (syslog).  `2018-12-30T12:23:32Z`  ##### Sottosezioni E' possibile utilizzare - con criterio - delle sottosezioni.  #### Note  Il servizio non richiede autenticazione, ma va' usato rispettando gli header di throttling esposti in conformita' alle Linee Guida del Modello di interoperabilita'.  #### Informazioni tecniche ed esempi  Esempio:  ``` http http://localhost:8443/datetime/v1/echo {   'datetime': '2018-12-30T12:23:32Z' } ``` 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: filippo.derrigo@gmail.com

 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CoreSK.Models
{ 
    /// <summary>
    /// Un Timestamp in RFC5424
    /// </summary>
    [DataContract]
    public partial class Timestamps : IEquatable<Timestamps>
    { 
        /// <summary>
        /// Gets or Sets Timestamp
        /// </summary>
        /// <example>2022-12-09T16:50:35.588Z</example>
        [DataMember(Name="timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Timestamps {\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Timestamps)obj);
        }

        /// <summary>
        /// Returns true if Timestamps instances are equal
        /// </summary>
        /// <param name="other">Instance of Timestamps to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Timestamps other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Timestamp == other.Timestamp ||
                    Timestamp != null &&
                    Timestamp.Equals(other.Timestamp)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Timestamp != null)
                    hashCode = hashCode * 59 + Timestamp.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Timestamps left, Timestamps right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Timestamps left, Timestamps right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
