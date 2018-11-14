using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SquaredInfinity.Foundation;
using SquaredInfinity.Foundation.Extensions;
using SquaredInfinity.Foundation.Serialization;
using SquaredInfinity.Foundation.Serialization.FlexiXml;
using SquaredInfinity.Foundation.Types.Description;

namespace SquaredInfinity.VSCommands.VscPackage
{
    public class FlexiXmlSerializer2 : FlexiXmlSerializer, ISerializer
    {
        internal static readonly XNamespace XmlNamespace = XNamespace.Get("http://schemas.squaredinfinity.com/serialization/flexixml");

        public FlexiXmlSerializer2()
        {
        }

        public SerializedDataInfo Serialize<T>(T obj)
        {
            return new SerializedDataInfo(Encoding.UTF8.GetBytes(base.Serialize((object)obj).ToString(SaveOptions.None)), Encoding.UTF8);
        }

        public T Deserialize<T>(SerializedDataInfo data)
        {
            return this.Deserialize<T>(((Encoding)data.Encoding).GetString((byte[])data.Bytes));
        }
    }
}

