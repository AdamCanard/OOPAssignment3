using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Assignment3;
using Assignment3.Utility;
using System.Runtime.Intrinsics.X86;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            List<Type> knownTypes = new List<Type> { typeof(SLL) };
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>), knownTypes);
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, users);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            List<Type> knownTypes = new List<Type> { typeof(SLL) };
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>), knownTypes);
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (ILinkedListADT)serializer.ReadObject(stream);
            }
        }
    }
}