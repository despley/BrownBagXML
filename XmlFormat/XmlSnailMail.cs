using System;

namespace XmlFormat
{
    internal class XmlSnailMail : IContactable
    {
        public string Message
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #region IContactable Members

        public bool Contact(string message)
        {
            throw new NotImplementedException();
        }

        #endregion

        public bool Contact()
        {
            throw new NotImplementedException();
        }
    }
}